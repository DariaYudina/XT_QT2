﻿using Epam.TreeLayerArchitecture.AbstractDAL;
using Epam.TreeLayerArchitecture.ConfigDAL;
using Epam.TreeLayerArchitecture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TreeLayerArchitecture.UserBLL
{
    public static class UserBLL
    {
        public static IStorableUser MemoryStorageUser => Dependensies.MemoryStorageUser;

        public static bool AddUser(string name, DateTime birthDate)
        {          
            if ( MemoryStorageUser.AddUser(new User(name, birthDate)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void AddUser(User user)
        {
            MemoryStorageUser.AddUser(user);
        }
        public static bool DeleteUser(User user)
        {
            if (MemoryStorageUser.Delete(user.userId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static ICollection<User> GetAllUsers()
        {
            return MemoryStorageUser.GetAllUsers();
        }
    }
}
