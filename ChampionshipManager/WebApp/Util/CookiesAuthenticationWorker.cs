using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Util
{
    public static class CookiesAuthenticationWorker
    {
        private const string cookiesKey = "Championship_Manager_Authorize";

        public static void SaveToCookies(ref HttpResponseBase response, UserDTO user)
        {
            IUserService userService = DependencyResolver.Current.GetService<IUserService>();
            string token = userService.GetTokenForUser(user);
            response.AppendCookie(new HttpCookie(cookiesKey, token));
        }

        public static UserDTO RestoreFromCookies(HttpRequestBase Request)
        {
            IUserService userService = DependencyResolver.Current.GetService<IUserService>();

            HttpCookie token = Request.Cookies.Get(cookiesKey);

            if (token == null)
            {
                return null;
            }
            string tokenString = token.Value;

            UserDTO restoredUser = userService.GetUserByToken(tokenString);

            return restoredUser;
        }

        public static void DeleteFromCookies(ref HttpResponseBase Response)
        {
            if (Response.Cookies[cookiesKey] != null)
            {
                Response.Cookies.Remove(cookiesKey);
            }
        }
    }
}