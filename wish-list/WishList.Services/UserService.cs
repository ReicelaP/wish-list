﻿using System.Linq;
using WishList.Core.Models;

namespace WishList.Services
{
    public class UserService
    {
        public string GetNames(UserList list)
        {
            var result = list.Users.Select(u => u.Name).ToArray();
            return string.Join(", ", result);
        }
    }
}