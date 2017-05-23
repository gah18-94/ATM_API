﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATM_API.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public ICollection<AccountDetailsModel> AccountDetails { get; set; }
    }
}
