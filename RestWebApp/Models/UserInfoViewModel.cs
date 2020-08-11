﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWebApp.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public short JobId { get; set; }
        public byte? JobLevel { get; set; }
        public int PubId { get; set; }
        public DateTime HireDate { get; set; }
        public string Token { get; set; }
        
    }

    public class UserInfoViewModel
    {
        public  User _user { get; set; }
    }
}
