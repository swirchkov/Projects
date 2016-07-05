using BLL.DTO;
using BLL.Interfaces;
using BLL.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Filters;
using WebApp.Models.Tournament;

namespace WebApp.Controllers
{
    public class TournamentController : Controller
    {
        private bool checkTournamentForStatus(TournamentDTO t, string status, UserDTO user)
        {
            switch (status)
            {
                case "Sended Request":
                    if (t.IsStarted || t.IsFinished)
                    {
                        return false;
                    }
                    return t.ParticipateRequests.FirstOrDefault(u => u.Id == user.Id) != null;

                case "Not Started":

                    if (t.IsStarted || t.IsFinished)
                    {
                        return false;
                    }

                    return t.Participates.FirstOrDefault(u => u.Id == user.Id) != null;

                case "In Process":

                    if (!t.IsStarted || t.IsFinished)
                    {
                        return false;
                    }

                    return t.Participates.FirstOrDefault(u => u.Id == user.Id) != null;

                case "Finished":

                    if (!t.IsStarted || !t.IsFinished)
                    {
                        return false;
                    }

                    return t.Participates.FirstOrDefault(u => u.Id == user.Id) != null;

            }
            throw new ArgumentException("Invalid tournament status");
        }

        [AuthenticationFilter]
        // GET: Tournament
        public ActionResult Index()
        {

            return View();
        }

        [AuthenticationFilter]
        public ActionResult TournamentsByStatus(string status)
        {
            ITournamentService tourService = DependencyResolver.Current.GetService<ITournamentService>();

            UserDTO user = (UserDTO)Session["User"];
            IEnumerable<TournamentDTO> tournaments = tourService.Find(t => checkTournamentForStatus(t, status, user));

            IEnumerable<TournamentViewModel> models = tournaments.Select(t => new TournamentViewModel()
            {
                Id = t.Id,
                Name = t.Name,
                GamesCount = t.Games.Count(),
                PointNumber = t.Games.Sum(g => g.WinnerId == user.Id ? 2 : g.WinnerId == 0 ? 1 : 0 )
            });

            ViewBag.Status = status;
            return PartialView(models);
        }

        [AuthenticationFilter]
        public ActionResult TournamentInfoByCategory(int tournamentId, string category)
        {
            switch (category)
            {
                case "Games":
                    return RedirectToAction("TournamentGames", new { tournamentId = tournamentId });
                case "Participates":
                    return RedirectToAction("TournamentParticipates", new { tournamentId = tournamentId });
                case "Statistics":
                    return RedirectToAction("TournamentStatistic", new { tournamentId = tournamentId });
                default:
                    return HttpNotFound();
            }
        }

        [AuthenticationFilter]
        public ActionResult TournamentGames(int tournamentId)
        {
            IGameService gameService = DependencyResolver.Current.GetService<IGameService>();

            IEnumerable<GameDTO> games = gameService.Find(g => g.TournamentId == tournamentId).OrderBy(g => g.Start);

            return PartialView(games);
        }

        [AuthenticationFilter]
        public ActionResult TournamentStatistic(int tournamentId)
        {
            ITournamentService service = DependencyResolver.Current.GetService<ITournamentService>();

            TournamentTableDTO table = service.GetTournamentTable(tournamentId);

            return PartialView(table);
        }

        [AuthenticationFilter]
        public ActionResult TournamentParticipates(int tournamentId)
        {
            ITournamentService service = DependencyResolver.Current.GetService<ITournamentService>();
            TournamentDTO tournament = service.Find(t => t.Id == tournamentId).FirstOrDefault();
            TournamentParticipateViewModel model = new TournamentParticipateViewModel()
            {
                Id = tournament.Id,
                IsFinished = tournament.IsFinished,
                IsStarted = tournament.IsStarted,
                ParticipateRequests = tournament.ParticipateRequests
            };

            model.Participates = tournament.Participates.Select(u => new ParticipateViewModel()
            {
                Id = u.Id,
                Name = u.Name,
                Surname = u.Surname,
                Email = u.Email,
                Photo = u.Photo,
                PointNumber = tournament.Games.Sum(g =>
                {
                    // if it's not user game
                    if (!g.Participates.Select(user => user.Id).Contains(u.Id))
                    {
                        return 0;
                    }

                    // count points cause we know user is game participate
                    return g.WinnerId == u.Id ? 2 : g.WinnerId == 0 ? 1 : 0;

                })
            });

            if (tournament.IsStarted)
            {
                model.Participates = model.Participates.OrderByDescending(user => user.PointNumber);
            }

            return PartialView(model);
        } 

        [AuthenticationFilter]
        public ActionResult Search(string query)
        {
            if (String.IsNullOrWhiteSpace(query))
            {
                return HttpNotFound();
            }

            Session["query"] = query;

            ITournamentService service = DependencyResolver.Current.GetService<ITournamentService>();

            IEnumerable<TournamentSearchDTO> tournaments = service.SearchTournamentsByQuery(query, (UserDTO)Session["User"]);

            return View(tournaments);
        }

        [AuthenticationFilter]
        public ActionResult ParticipateTournament(int tournamentId)
        {
            ITournamentParticipateService service = DependencyResolver.Current.GetService<ITournamentParticipateService>();
            UserDTO user = (UserDTO)Session["User"];

            try
            {
                service.CreateParticipateRequest(user.Id, tournamentId);
            }
            catch (ValidationException ex)
            {
                return Json(ex);
            }

            return Json("ok");
        }

    }
}