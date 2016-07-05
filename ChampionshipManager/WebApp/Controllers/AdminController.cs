using BLL.DTO;
using BLL.Interfaces;
using BLL.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Filters;
using WebApp.Models.Admin;
using WebApp.Util;
using System.IO;
using WebApp.Util.Comparators;

namespace WebApp.Controllers
{
    [AuthenticationFilter(Role = "Admin")]
    public class AdminController : Controller
    {
        private string getAdminTournamentStatus(TournamentSearchDTO tour)
        {
            if (!tour.IsStarted)
            {
                return "Not Started";
            }
            else if (tour.IsStarted && !tour.IsFinished)
            {
                return "In Process";
            }
            else
            {
                return "Finished";
            }
        }

        private object getUserJsonObject(UserDTO user)
        {
            return new {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        private object getUserExJsonObject(UserDTO user)
        {
            return new
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Photo = user.Photo,
                IsDefaultPhoto = user.Photo == DEFAULT_AVATAR
            };
        }

        private readonly string DEFAULT_AVATAR = "/Files/Images/avatar.png";

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTournament(CreateTournamentViewModel model)
        {
            // initialize dto
            TournamentDTO tournament = new TournamentDTO()
            {
                Name = model.Name,
                IsFinished = false,
                IsStarted = false,
                SportKind = model.SportKind,
                ParticipateNumber = model.ParticipateNumber
            };

            // save image file
            string fileName = null;

            if (model.Logo == null)
            {
                tournament.Logo = "/Files/TournamentImages/turnirAVA.jpg";
            }
            else
            {
                IFileSaver fileSaver = DependencyResolver.Current.GetService<IFileSaver>();
                fileName = fileSaver.SaveFile(Server.MapPath("~/Files/TournamentImages/"), model.Logo);
                tournament.Logo = "/Files/TournamentImages/" + fileName;
            }

            ITournamentService service = DependencyResolver.Current.GetService<ITournamentService>();

            try
            {
                service.CreateItem(tournament);
            }
            catch (ValidationException ex)
            {
                if (fileName != null)
                {
                    System.IO.File.Delete(Server.MapPath("~/Files/TournamentImages/" + fileName));
                }
                return Json(new { Message = ex.FieldMessage });
            }
            return Json("Success");
        }

        public ActionResult SearchTournamentJson(string query)
        {
            if (String.IsNullOrWhiteSpace(query))
            {
                return HttpNotFound();
            }
            ITournamentService service = DependencyResolver.Current.GetService<ITournamentService>();

            return Json(service.SearchTournamentsByQuery(query, (UserDTO)Session["User"]).Select(t => new {
                Id = t.Id,
                Name = t.Name,
                Logo = t.Logo,
                CurrentParticipateNumber = t.CurrentParticipateNumber,
                RequiredParticipateNumber = t.RequiredParticipateNumber,
                Status = t.Status.ToString(),
                IsStarted = t.IsStarted
            }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult FirstTournaments()
        {
            ITournamentService service = DependencyResolver.Current.GetService<ITournamentService>();

            return Json(service.SearchTournamentsByQuery("", (UserDTO)Session["User"]).Select(t => new {
                Id = t.Id,
                Name = t.Name,
                Logo = t.Logo,
                CurrentParticipateNumber = t.CurrentParticipateNumber,
                RequiredParticipateNumber = t.RequiredParticipateNumber,
                Status = getAdminTournamentStatus(t),
                IsStarted = t.IsStarted,
                IsFinished = t.IsFinished
            }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTournamentUsers(int Id)
        {
            ITournamentService service = DependencyResolver.Current.GetService<ITournamentService>();

            TournamentDTO tournament = service.Find(t => t.Id == Id).FirstOrDefault();

            if (tournament == null)
            {
                return HttpNotFound();
            }

            return Json(new
            {
                Participates = tournament.Participates.Select(u => new {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    Photo = u.Photo
                }),
                Requests = tournament.ParticipateRequests.Select(u => new {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    Photo = u.Photo
                })
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AcceptRequest(int userId, int tournamentId)
        {
            ITournamentParticipateService participateService = DependencyResolver.Current.GetService<ITournamentParticipateService>();

            try
            {
                participateService.AcceptParticipateRequest(userId, tournamentId);
            }
            catch (ValidationException)
            {
                // possible if requests sended by not browser way
                return HttpNotFound();
            }

            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeclineRequest(int userId, int tournamentId)
        {
            ITournamentParticipateService tourService = DependencyResolver.Current.GetService<ITournamentParticipateService>();

            try
            {
                tourService.DeclineParticipateRequest(userId, tournamentId);
            }
            catch (ValidationException)
            {
                // possible if requests sended by not browser way
                return HttpNotFound();
            }

            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        public ActionResult RemoveFromTournament(int userId, int tournamentId)
        {
            ITournamentParticipateService participateService = DependencyResolver.Current.GetService<ITournamentParticipateService>();

            try
            {
                participateService.RemoveFromTournament(userId, tournamentId);
            }
            catch (ValidationException)
            {
                // warning invalid situation
                return HttpNotFound();
            }

            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        public ActionResult StartTournament(int Id)
        {
            ITournamentService tourService = DependencyResolver.Current.GetService<ITournamentService>();
            TournamentDTO tour = tourService.Find(t => t.Id == Id).FirstOrDefault();

            if (tour == null || tour.IsStarted)
            {
                // warning cause data is invalid but it cann't be passed throw user interface
                return HttpNotFound();
            }

            tour.IsStarted = true;

            try
            {
                tourService.UpdateItem(tour);
            }
            catch (ValidationException)
            {
                return HttpNotFound();
            }

            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTournamentGames(int id)
        {
            ITournamentService service = DependencyResolver.Current.GetService<ITournamentService>();

            TournamentDTO tournament = service.Find(t => t.Id == id).FirstOrDefault();
            return Json(tournament.Games.OrderBy(g => g.Start).Select(g => new
            {
                Id = g.Id,
                TournamentId = g.TournamentId,
                WinnerId = g.WinnerId,
                ResultView = g.ResultView,
                Start = g.Start.ToString(),
                StartDate = new
                {
                    Year = g.Start.Year,
                    Month = g.Start.Month,
                    Day = g.Start.Day,
                    Hours = g.Start.Hour,
                    Minutes = g.Start.Minute
                },
                User1 = getUserJsonObject(g.Participates.FirstOrDefault()),
                User2 = getUserJsonObject(g.Participates.LastOrDefault())
            }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTournamentParticipates(int id)
        {
            ITournamentService service = DependencyResolver.Current.GetService<ITournamentService>();

            TournamentDTO tournament = service.Find(t => t.Id == id).FirstOrDefault();

            return Json(tournament.Participates.Select(u => getUserJsonObject(u)), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateGame(CreateGameViewModel model)
        {
            DateTime start;

            if (model.Year.HasValue && model.Month.HasValue && model.Day.HasValue && model.Hour.HasValue && model.Minute.HasValue)
            {
                start = new DateTime(model.Year.Value, model.Month.Value + 1, model.Day.Value, model.Hour.Value, model.Minute.Value, 0);
            }
            else
            {
                start = DateTime.Now.AddDays(7);
            }

            string result;
            int winnerId = 0;

            if (model.FirstScore.HasValue && model.SecondScore.HasValue)
            {
                result = $" { model.FirstScore } : { model.SecondScore } ";

                winnerId = model.FirstScore > model.SecondScore ? model.User1Id :
                    model.SecondScore == model.FirstScore ? 0 : model.User2Id;
            }
            else
            {
                result = "";
            }

            GameDTO game = new GameDTO()
            {
                ResultView = result,
                Start = start,
                TournamentId = model.TournamentId
            };

            IGameService service = DependencyResolver.Current.GetService<IGameService>();
            IUserService userService = DependencyResolver.Current.GetService<IUserService>();
            try
            {
                service.CreateItem(game, new List<UserDTO>() {
                    userService.Find(u => u.Id == model.User1Id).FirstOrDefault(),
                    userService.Find(u => u.Id == model.User2Id).FirstOrDefault(),
                });
            }
            catch (ValidationException ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
            }

            game = service.Find(g => g.Start == start && g.TournamentId == model.TournamentId && g.ResultView == $" { model.FirstScore } : { model.SecondScore } ").FirstOrDefault();

            return Json(new
            {
                Id = game.Id,
                TournamentId = game.TournamentId,
                WinnerId = game.WinnerId,
                ResultView = game.ResultView,
                Start = game.Start.ToString(),
                StartDate = new
                {
                    Year = game.Start.Year,
                    Month = game.Start.Month,
                    Day = game.Start.Day,
                    Hours = game.Start.Hour,
                    Minutes = game.Start.Minute
                },
                User1 = getUserJsonObject(game.Participates.First()),
                User2 = getUserJsonObject(game.Participates.Last())
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EditGame(int gameId, CreateGameViewModel model)
        {
            IGameService gameService = DependencyResolver.Current.GetService<IGameService>();

            GameDTO dbGame = gameService.Find(g => g.Id == gameId).FirstOrDefault();

            if (model.FirstScore.HasValue && model.SecondScore.HasValue)
            {
                dbGame.ResultView = $" { model.FirstScore } : { model.SecondScore } ";

                dbGame.WinnerId = model.FirstScore > model.SecondScore ? model.User1Id :
                    model.SecondScore == model.FirstScore ? 0 : model.User2Id;
            }

            if (model.Year.HasValue && model.Month.HasValue && model.Day.HasValue && model.Hour.HasValue && model.Minute.HasValue)
            {
                dbGame.Start = new DateTime(model.Year.Value, model.Month.Value + 1, model.Day.Value, model.Hour.Value, model.Minute.Value, 0);
            }

            try
            {
                gameService.UpdateItem(dbGame);
            }
            catch (ValidationException ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
            }

            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteGame(int gameId)
        {
            IGameService gameService = DependencyResolver.Current.GetService<IGameService>();

            try
            {
                gameService.DeleteItem(gameId);
            }
            catch (ValidationException ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
            }

            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        #region Users 

        public ActionResult GetFirstUsers()
        {
            IUserService userService = DependencyResolver.Current.GetService<IUserService>();

            IEnumerable<UserDTO> users = userService.Find(t => true).Take(10);

            return Json(users.Select(u => getUserExJsonObject(u)), JsonRequestBehavior.AllowGet);
        }

        public ActionResult FilterByPattern(string query)
        {
            IUserService userService = DependencyResolver.Current.GetService<IUserService>();

            IEnumerable<UserDTO> users = userService.Find(u => u.Name.Contains(query)).Concat(userService.Find(u => u.Surname.Contains(query))).Concat(userService.Find(u => u.Patronymic.Contains(query))).GroupBy(u => u.Id).Select(g => g.First());

            return Json(users.Select(u => getUserExJsonObject(u)), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeletePhoto(int userId)
        {
            IUserService userService = DependencyResolver.Current.GetService<IUserService>();

            UserDTO user = userService.Find(u => u.Id == userId).FirstOrDefault();

            if (user.Photo == DEFAULT_AVATAR)
            {
                // can't be done with normal using user interface
                return HttpNotFound();
            }

            System.IO.File.Delete(Server.MapPath("~" + user.Photo));
            user.Photo = DEFAULT_AVATAR;

            try
            {
                userService.UpdateItem(user);
            }
            catch (ValidationException ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }

            return Json(user.Photo, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EditProfile(UserAdminEditViewModel model)
        {
            IUserService userService = DependencyResolver.Current.GetService<IUserService>();
            UserDTO user = userService.Find(u => u.Id == model.Id).FirstOrDefault();

            user.Name = model.Name;
            user.Patronymic = model.Patronymic;
            user.PhoneNumber = model.PhoneNumber;
            user.Surname = model.Surname;
            user.Email = model.Email;

            try
            {
                userService.UpdateItem(user);
            }
            catch (ValidationException ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
            }

            return Json("Действие успешно.", JsonRequestBehavior.AllowGet);
        }

        #endregion  
    }
}