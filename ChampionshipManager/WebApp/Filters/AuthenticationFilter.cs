using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using WebApp.Util;

namespace WebApp.Filters
{
    public class AuthenticationFilter : FilterAttribute, IAuthenticationFilter
    {
        private const string cookiesKey = "Championship_Manager_Authorize";
        private IUserService userService = DependencyResolver.Current.GetService<IUserService>();

        public AuthenticationFilter()
        {
        }

        public string Role { get; set; } = null; 

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            UserDTO user = (UserDTO)filterContext.HttpContext.Session["User"];

            if (user != null)
            {
                if (Role != null && user.Role != Role)
                {
                    filterContext.Result = new HttpNotFoundResult();
                    return;
                }
                return; // everything ok
            }

            // check cookies
            UserDTO restoredUser = CookiesAuthenticationWorker.RestoreFromCookies(filterContext.HttpContext.Request);

            if (restoredUser != null)
            {
                if (Role != null && restoredUser.Role != Role)
                {
                    filterContext.Result = new HttpNotFoundResult();
                    return;
                }
                filterContext.HttpContext.Session["User"] = restoredUser;
                return; // everything ok
            }
            else
            {
                filterContext.Result = new RedirectResult("/Account/Login");
                return;
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            // all logic in onAuthentication
        }
    }
}