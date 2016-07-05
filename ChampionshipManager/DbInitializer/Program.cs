using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL.Interfaces;
using Autofac;
using BLL.DTO;
using BLL.Util;

namespace DbInitializer
{
    class Program
    {
        static void Main(string[] args)
        {
            //IUserService userService = AutofacBLLContainer.Container.Resolve<IUserService>();

            //UserDTO user = new UserDTO()
            //{
            //    Name = "admin",
            //    Surname = "admins",
            //    Password = "123456",
            //    Patronymic = "adminer",
            //    Comment = "admin com",
            //    Email = "admin@gmail.com",
            //    PhoneNumber = "099111",
            //    Photo = "/Images/",
            //    Role = "Admin"
            //};

            //userService.Register(user);

            //string login = "tournamentmanager676";
            //string password = "86c0ea87a2f";

            //string a = Guid.NewGuid().ToString().Replace('-', 'a').Substring(0,12);

            //Console.WriteLine("registered ...");

            string deliver = "swirchkov@gmail.com";
            string title = "Registration";
            string body = "Congratulates you with registration on site. Follow next link.";

            EmailSender.SendMessage(title, body, deliver);

        }
    }
}
