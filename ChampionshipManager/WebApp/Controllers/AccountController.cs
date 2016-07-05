using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.Account;
using System.IO;
using BLL.Interfaces;
using BLL.Validators;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        private IUserService userService = DependencyResolver.Current.GetService<IUserService>();
        private const string COOKIES_KEY = "Championship_Manager_Authorize";
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            UserDTO user = new UserDTO()
            {
                Email = model.Login,
                Password = model.Password
            };

            UserDTO dbUser = userService.Login(user);
            if (dbUser == null)
            {
                ModelState.AddModelError("", "Пользователь с таким логином и паролем не найден в базе.");
                return View();
            }

            if (model.RememberMe)
            {
                string token = userService.GetTokenForUser(dbUser);
                Response.Cookies.Add(new HttpCookie(COOKIES_KEY, token));
            }

            Session["User"] = dbUser;

            if (!dbUser.IsEmailVerified)
            {
                return RedirectToAction("WaitForEmailVerify");
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (model.ConfirmPassword != model.Password)
            {
                ModelState.AddModelError("ConfirmPassword", "Password doesn't match");
                return View();
            }

            string[] fio = model.FullName.Split(' ', '\t');

            // save photo
            string name = Guid.NewGuid().ToString().Substring(0, 10);
            string path = "";
            if (model.Photo == null)
            {
                ModelState.AddModelError("Photo", "User must load photo to site while registrating.");
                return View();
            }
            else
            {
                path = Path.Combine(Server.MapPath("~/Files/Images/"), model.Photo.FileName);
                name = model.Photo.FileName;
                while(System.IO.File.Exists(path))
                {
                    string extension = model.Photo.FileName.Split('.').Last();
                    name = Guid.NewGuid().ToString().Substring(0, 10) + extension;
                    path = Path.Combine(Server.MapPath("~/Files/Images/"), name);
                }

                model.Photo.SaveAs(path);
            }

            UserDTO user = new UserDTO()
            {
                Email = model.Email,
                Name = fio[0],
                Patronymic = fio[1],
                Surname = fio[2],
                Comment = model.Comment,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                Photo = "/Files/Images/" + name,
                Role = "user"
            };

            try
            {
                userService.Register(user);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(null, ex.Message);
                System.IO.File.Delete(path);
                return View();
            }

            Session["User"] = user;

            return RedirectToAction("WaitForEmailVerify");
        }

        [ActionName("Profile")]
        public ActionResult ProfileAction()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProfileLogin(string Login, string Password)
        {
            UserDTO user = new UserDTO()
            {
                Email = Login,
                Password = Password
            };

            UserDTO dbUser = userService.Login(user);

            if (dbUser == null)
            {
                return Json(new { Message = "Пользователь не найден." }, JsonRequestBehavior.AllowGet);
            }

            return PartialView(dbUser);
        }

        [HttpPost]
        public ActionResult ProfileEdit(RegisterViewModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return Json(new { Message = "Password's doesn't match." }, JsonRequestBehavior.AllowGet);
            }

            string name = null;
            string path = "";

            if (model.Photo != null) { 
                path = Path.Combine(Server.MapPath("~/Files/Images/"), model.Photo.FileName);
                name = model.Photo.FileName;
                while (System.IO.File.Exists(path))
                {
                    string extension = model.Photo.FileName.Split('.').Last();
                    name = Guid.NewGuid().ToString().Substring(0, 10) + extension;
                    path = Path.Combine(Server.MapPath("~/Files/Images/"), name);
                }

                model.Photo.SaveAs(path);
            }

            IUserService service = DependencyResolver.Current.GetService<IUserService>();


            UserDTO sessionUser = (UserDTO)Session["User"];

            sessionUser.Email = model.Email;

            if (model.FullName != null)
            {
                string[] fio = model.FullName.Split(' ');
                sessionUser.Name = fio[0];
                sessionUser.Patronymic = fio[1];
                sessionUser.Surname = fio[2];
            }

            sessionUser.Comment = model.Comment;

            if (model.Password != null)
            {
                sessionUser.Password = model.Password;
            }

            if (model.PhoneNumber != null)
            {
                sessionUser.PhoneNumber = model.PhoneNumber;
            }

            if (name != null)
            {
                sessionUser.Photo = "/Files/Images/" + name;
            }

            try
            {
                service.UpdateItem(sessionUser);
            }
            catch (ValidationException ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Message = "Действие успешно", Success = true }, JsonRequestBehavior.AllowGet);
        }

        #region email verification

        public ActionResult WaitForEmailVerify()
        {
            return View();
        }

        public ActionResult VerifyEmail(string token, string email)
        {
            IUserService service = DependencyResolver.Current.GetService<IUserService>();
            UserDTO user = service.Find(u => u.Email == email).FirstOrDefault();

            if (!service.VerifyEmailToken(token, user))
            {
                return HttpNotFound();
            }

            user.IsEmailVerified = true;

            // validating exception is impossible
            service.UpdateItem(user);

            Session["User"] = user;

            return View();
        }

        #endregion

        #region password restoration

        public ActionResult RestorePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RestorePassword(string email)
        {
            IUserService service = DependencyResolver.Current.GetService<IUserService>();

            UserDTO user = service.Find(u => u.Email == email).FirstOrDefault();

            if (user == null)
            {
                ModelState.AddModelError("Email", "Пользователь с таким электронным адресом не найден");
                return View();
            }

            service.SendRestoreMail(user);

            return View("RestoreMailSended");
        }

        public ActionResult RestorePasswordComplete(string token, string email)
        {
            IUserService service = DependencyResolver.Current.GetService<IUserService>();
            UserDTO user = service.Find(u => u.Email == email).FirstOrDefault();

            if (!service.VerifyEmailToken(token, user))
            {
                return HttpNotFound();
            }

            Session["UserRestore"] = user;

            return View();
        }

        [HttpPost]
        [ActionName("RestorePasswordComplete")]
        public ActionResult RestorePasswordCompletePost(string Password, string Confirmation)
        {
            if (Password != Confirmation)
            {
                ModelState.AddModelError("Password", "Пароли не совпадають");
                return View();
            }

            UserDTO user = (UserDTO)Session["UserRestore"];

            user.Password = Password;

            IUserService service = DependencyResolver.Current.GetService<IUserService>();

            try
            {
                service.UpdateItem(user);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("Password", ex.Message);
                return View();
            }

            Session["User"] = user;

            return RedirectToAction("Index", "Tournament");
        }

        #endregion

        #region logout

        public ActionResult LogOut()
        {
            if (Session["User"] == null)
            {
                return HttpNotFound();
            }

            Session.Remove("User");

            if (Response.Cookies[COOKIES_KEY] != null)
            {
                Response.Cookies.Remove(COOKIES_KEY);
            }

            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}