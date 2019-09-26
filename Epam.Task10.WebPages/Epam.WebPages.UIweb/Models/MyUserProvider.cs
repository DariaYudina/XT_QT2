﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Epam.WebPages.UIweb.Models
{
    public enum Roles
    {
        Admin,
        User
    }
    public class MyUserProvider : RoleProvider
    {
        public override string[] GetRolesForUser(string username)
        {
            switch (username)
            {
                case "admin":
                    return new[] { "Admin", "User" };
                case "anton":
                    return new[] { "User" };
                default: return new string[] { };
            }
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            if (username == "admin" && roleName == "Admin")
                return true;
            else return false;
        }
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }


        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}