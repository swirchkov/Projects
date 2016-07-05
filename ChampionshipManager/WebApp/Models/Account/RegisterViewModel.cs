﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Account
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public HttpPostedFileBase Photo { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Comment { get; set; }
    }
}