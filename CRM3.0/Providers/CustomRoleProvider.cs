using CRM3._0.DAO;
using CRM3._0.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace CRM3._0.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        private string applicationName;

        public override string ApplicationName
        {
            get
            {
                return applicationName;
            }
            set
            {
                applicationName = value;
            }
        }

        /// <summary>
        /// Initialize.
        /// </summary>
        /// <param name="usernames"></param>
        /// <param name="roleNames"></param>
        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }
            if (name == null || name.Length == 0)
            {
                name = "CustomRoleProvider";
            }
            if (String.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "Custom Role Provider");
            }
            base.Initialize(name, config);
            applicationName = GetConfigValue(config["applicationName"],
                System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
        }

        /// <summary>
        /// Add users to roles.
        /// </summary>
        /// <param name="usernames"></param>
        /// <param name="roleNames"></param>
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            try
            {
                using (ApplicationContext _db = new ApplicationContext())
                {
                    foreach (string username in usernames)
                    {
                        UserProfile user = (from u in _db.UserProfiles
                                            where u.Username == username && u.StatusId == 0
                                            select u).FirstOrDefault();
                        if (user != null)
                        {
                            var AllDbRoles = (from r in _db.UserRoles select r).ToList();
                            List<UserRole> UserRoles = new List<UserRole>();
                            foreach (var role in AllDbRoles)
                            {
                                foreach (string roleName in roleNames)
                                {
                                    if (role.Name == roleName)
                                    {
                                        UserRoles.Add(role);
                                        continue;
                                    }
                                }
                            }
                            if (UserRoles.Count > 0)
                            {
                                foreach (UserRole role in UserRoles)
                                {
                                    UserInRole UIR = (from uir in _db.UserInRoles
                                                      where uir.UserId == user.id && uir.RoleId == role.id
                                                      select uir).FirstOrDefault();
                                    if (UIR == null)
                                    {
                                        UIR = new UserInRole();
                                        UIR.UserId = user.id;
                                        UIR.User = user;
                                        UIR.RoleId = role.id;
                                        UIR.Role = role;
                                        UIR.CreatedOn = DateTime.Now;
                                        UIR.DeletedOn = null;
                                        _db.UserInRoles.Add(UIR);
                                        _db.SaveChanges();
                                    }
                                    else
                                    {
                                        UIR.DeletedOn = null;
                                        _db.SaveChanges();
                                    }
                                }
                            }

                        }
                    }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// Create new role.
        /// </summary>
        /// <param name="roleName"></param>
        public override void CreateRole(string roleName)
        {
            try
            {
                using (ApplicationContext _db = new ApplicationContext())
                {
                    UserRole role = new UserRole();
                    role.Name = roleName;
                    _db.UserRoles.Add(role);
                    _db.SaveChanges();
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// Delete role.
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="throwOnPopulatedRole"></param>
        /// <returns>true if role is successfully deleted</returns>
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            bool ret = false;
            using (ApplicationContext _db = new ApplicationContext())
            {
                try
                {
                    UserRole role = (from r in _db.UserRoles
                                     where r.Name == roleName
                                     select r).SingleOrDefault();
                    if (role != null)
                    {
                        _db.UserRoles.Remove(role);
                        _db.SaveChanges();
                        ret = true;
                    }
                }
                catch
                {
                    ret = false;
                }
            }
            return ret;
        }

        /// <summary>
        /// Find users in role.
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="usernameToMatch"></param>
        /// <returns></returns>
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            List<string> users = new List<string>();
            using (ApplicationContext _db = new ApplicationContext())
            {
                try
                {
                    var usersInRole = from uir in _db.UserInRoles
                                      where uir.Role.Name == roleName && uir.User.Username == usernameToMatch
                                      select uir;
                    if (usersInRole != null)
                    {
                        foreach (var userInRole in usersInRole)
                        {
                            users.Add(userInRole.User.Username);
                        }
                    }
                }
                catch
                {

                }
            }
            return users.ToArray();
        }

        /// <summary>
        /// Get all roles.
        /// </summary>
        /// <returns></returns>
        public override string[] GetAllRoles()
        {
            List<string> roles = new List<string>();
            using (ApplicationContext _db = new ApplicationContext())
            {
                try
                {
                    var dbRoles = from r in _db.UserRoles
                                  select r;
                    foreach (var role in dbRoles)
                    {
                        roles.Add(role.Name);
                    }
                }
                catch
                {

                }
            }
            return roles.ToArray();
        }

        /// <summary>
        /// Get all roles for a specific user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public override string[] GetRolesForUser(string username)
        {
            List<string> roles = new List<string>();
            using (ApplicationContext _db = new ApplicationContext())
            {
                try
                {
                    var dbRoles = from r in _db.UserInRoles
                                  where r.User.Username == username
                                  select r;
                    foreach (var role in dbRoles)
                    {
                        roles.Add(role.Role.Name);
                    }
                }
                catch
                {

                }
            }
            return roles.ToArray();
        }

        /// <summary>
        /// Get all users that belong to a role.
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public override string[] GetUsersInRole(string roleName)
        {
            List<string> users = new List<string>();
            using (ApplicationContext _db = new ApplicationContext())
            {
                try
                {
                    var usersInRole = from uir in _db.UserInRoles
                                      where uir.Role.Name == roleName
                                      select uir;
                    if (usersInRole != null)
                    {
                        foreach (var userInRole in usersInRole)
                        {
                            users.Add(userInRole.User.Username);
                        }
                    }
                }
                catch
                {

                }
            }
            return users.ToArray();
        }

        /// <summary>
        /// Checks if user belongs to a given role.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public override bool IsUserInRole(string username, string roleName)
        {
            bool isValid = false;
            using (ApplicationContext _db = new ApplicationContext())
            {
                try
                {
                    var usersInRole = from uir in _db.UserInRoles
                                      where uir.User.Username == username && uir.Role.Name == roleName
                                      select uir;
                    if (usersInRole != null)
                    {
                        isValid = true;
                    }
                }
                catch
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usernames"></param>
        /// <param name="roleNames"></param>
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            try
            {
                using (ApplicationContext _db = new ApplicationContext())
                {
                    foreach (string username in usernames)
                    {
                        UserProfile user = (from u in _db.UserProfiles
                                            where u.Username == username && u.StatusId == 0
                                            select u).FirstOrDefault();
                        if (user != null)
                        {
                            var AllDbRoles = (from r in _db.UserRoles select r).ToList();
                            List<int> RemoveRoleIds = new List<int>();
                            foreach (var role in AllDbRoles)
                            {
                                foreach (string roleName in roleNames)
                                {
                                    if (role.Name == roleName)
                                    {
                                        RemoveRoleIds.Add(role.id);
                                        continue;
                                    }
                                }
                            }

                            if (RemoveRoleIds.Count > 0)
                            {
                                foreach (var roleId in RemoveRoleIds)
                                {
                                    UserInRole UIR = (from uir in _db.UserInRoles
                                                      where uir.UserId == user.id && uir.RoleId == roleId
                                                      select uir).FirstOrDefault();
                                    if (UIR != null)
                                    {
                                        UIR.CreatedOn = DateTime.Now;
                                        UIR.DeletedOn = DateTime.Now;
                                        _db.SaveChanges();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// Check if role exists.
        /// </summary>
        /// <param name="configValue"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public override bool RoleExists(string roleName)
        {
            bool isValid = false;
            using (ApplicationContext _db = new ApplicationContext())
            {
                if (_db.UserRoles.Any(r => r.Name == roleName))
                {
                    isValid = true;
                }
            }
            return isValid;
        }

        /// <summary>
        /// Get config value.
        /// </summary>
        /// <param name="configValue"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private string GetConfigValue(string configValue, string defaultValue)
        {
            if (String.IsNullOrEmpty(configValue))
            {
                return defaultValue;
            }
            return configValue;
        }
    }
}