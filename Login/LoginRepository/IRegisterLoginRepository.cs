﻿using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.LoginRepository
{
    public interface IRegisterLoginRepository
    {
        bool Registration(UserLoginDetails regDetails);
        object Login(string userId, string password);
    }
}
