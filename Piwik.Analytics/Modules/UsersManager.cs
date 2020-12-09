// Copyright (c) Roland Pop All rights reserved.
// Licensed under the BSD 2-clause "Simplified" License. See License.txt in the project root for license information.

using Piwik.Analytics.Parameters;
using System;
using System.Collections.Generic;

/// <summary>
/// Piwik - Open source web analytics
/// For more information, see http://piwik.org
/// </summary>
namespace Piwik.Analytics.Modules
{
    /// <summary>
    /// Service Gateway for Piwik UsersManager Module API
    /// For more information, see http://developer.piwik.org/api-reference/reporting-api#SitesManager
    /// </summary>
    /// 
    /// <remarks>
    /// This Analytics API is tested against Piwik 2.16.5
    /// </remarks> 
    public class UsersManager : PiwikAnalytics
    {
        private const string PLUGIN = "UsersManager";

        public enum UserAccess
        {
            noaccess,
            view,
            admin
        }

        protected override string getPlugin()
        {
            return PLUGIN;
        }

        /// <summary>
        /// Set a piwik user preference
        /// </summary>
        /// <param name="userLogin"></param>
        /// <param name="preferenceName"></param>
        /// <param name="preferenceValue"></param>
        /// <returns>Dictionary<string, List<object> containing the result message</returns>
        public Dictionary<string, List<object>> setUserPreference(
            string userLogin,
            string preferenceName,
            object preferenceValue)
        {

            SimpleParameter valueParameter = null;
            Type pType = preferenceValue.GetType();
            switch (pType.Name)
            {
                case "String":
                    valueParameter = new SimpleParameter("preferenceValue", (string)preferenceValue);
                    break;
                case "Int32":
                    valueParameter = new SimpleParameter("preferenceValue", (int)preferenceValue);
                    break;
                default:
                    throw new Exception("preferenceValue must be int or string");
            }

            Parameter[] parameters =
            {
                new SimpleParameter("userLogin", userLogin),
                new SimpleParameter("preferenceName", preferenceName),
                valueParameter
            };

            return this.sendRequest<Dictionary<string, List<object>>>("setUserPreference", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Get a piwik user preference
        /// </summary>
        /// <param name="userLogin"></param>
        /// <param name="preferenceName"></param>
        /// <returns>Dictionary<string, List<object> containing the user preference</returns>
        public object getUserPreference(
            string userLogin,
            string preferenceName)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userLogin", userLogin),
                new SimpleParameter("preferenceName", preferenceName)
            };

            return this.sendRequest<object>("getUserPreference", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Get all piwik users with the given list of logins
        /// </summary>
        /// <param name="userLogins"></param>
        /// <returns>List<object> containing Dictionary<string, List<object>s of users objects</returns>
        public List<object> getUsers(
            string[] userLogins = null)
        {
            List<Parameter> parameters = new List<Parameter>();
            if (userLogins != null)
                parameters.Add(new SimpleParameter("userLogins", String.Join(",", userLogins)));

            return this.sendRequest<List<object>>("getUsers", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Get user logins of all registered piwik users
        /// </summary>
        /// <returns>List<object> containing user logins</returns>
        public List<object> getUsersLogin()
        {
            return this.sendRequest<List<object>>("getUsersLogin", new List<Parameter>());
        }

        /// <summary>
        /// Get all piwik users and their sites where they have the given access level
        /// </summary>
        /// <param name="access"></param>
        /// <returns>Dictionary<string, List<object>s of users containing List<object> of site ids</returns>
        public Dictionary<string, List<object>> getUsersSitesFromAccess(
            UserAccess access)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("access", access.ToString())
            };

            return this.sendRequest<Dictionary<string, List<object>>>("getUsersSitesFromAccess", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Get all piwik users and their access level for the piwik site with the given id
        /// </summary>
        /// <param name="idSite"></param>
        /// <returns>List<object> of Dictionary<string, List<object>s containing user logins and their access level</returns>
        public List<object> getUsersAccessFromSite(
            int idSite)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite)
            };

            return this.sendRequest<List<object>>("getUsersAccessFromSite", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Get all piwik users which have the given access to the piwik site with the given id
        /// </summary>
        /// <param name="idSite"></param>
        /// <param name="access"></param>
        /// <returns>List<object> of user objects</returns>
        public List<object> getUsersWithSiteAccess(
            int idSite,
            UserAccess access)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new SimpleParameter("access", access.ToString())
            };

            return this.sendRequest<List<object>>("getUsersWithSiteAccess ", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Get all sites and the specific access level (view or admin) where the given user has access to
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns>List<object> of Dictionary<string, List<object>s containing idSite and access</returns>
        public List<object> getSitesAccessFromUser(
            string userLogin)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userLogin", userLogin)
            };

            return this.sendRequest<List<object>>("getSitesAccessFromUser  ", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Get a piwik user by login
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns>List<object> containing Dictionary<string, List<object>s of users objects</returns>
        public List<object> getUser(
            string userLogin)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userLogin", userLogin)
            };

            return this.sendRequest<List<object>>("getUser", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Get a piwik user by email
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns>List<object> containing Dictionary<string, List<object>s of users objects</returns>
        public List<object> getUserByEmail(
            string userEmail)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userEmail", userEmail)
            };

            return this.sendRequest<List<object>>("getUserByEmail", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Add a piwik user
        /// </summary>
        /// <param name="userLogin"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="alias"></param>
        /// <returns>Dictionary<string, List<object> containing the result message</returns>
        public Dictionary<string, List<object>> addUser(
            string userLogin,
            string password,
            string email,
            string alias = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userLogin", userLogin),
                new SimpleParameter("password", password),
                new SimpleParameter("email", email),
                new SimpleParameter("alias", alias)
            };

            return this.sendRequest<Dictionary<string, List<object>>>("addUser", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Define if a piwik user with the given login has super user access
        /// </summary>
        /// <param name="userLogin"></param>
        /// <param name="hasSuperUserAccess"></param>
        /// <returns>List<object> containing Dictionary<string, List<object>s of users objects</returns>
        public Dictionary<string, List<object>> setSuperUserAccess(
            string userLogin,
            bool hasSuperUserAccess)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userLogin", userLogin),
                new SimpleParameter("hasSuperUserAccess", hasSuperUserAccess)
            };

            return this.sendRequest<Dictionary<string, List<object>>>("setSuperUserAccess", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Check if the current piwik user has super user access
        /// </summary>
        /// <returns>True if the current user has super user access</returns>
        public bool hasSuperUserAccess()
        {
            return this.sendRequest<bool>("hasSuperUserAccess", new List<Parameter>());
        }

        /// <summary>
        /// Get all piwik users which have super user access
        /// </summary>
        /// <returns>List<object> containing Dictionary<string, List<object>s of users objects</returns>
        public List<object> getUsersHavingSuperUserAccess()
        {
            return this.sendRequest<List<object>>("getUsersHavingSuperUserAccess", new List<Parameter>());
        }

        /// <summary>
        /// Update a piwik user
        /// </summary>
        /// <param name="userLogin"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="alias"></param>
        /// <returns>Dictionary<string, List<object> containing the result message</returns>
        public Dictionary<string, List<object>> updateUser(
            string userLogin,
            string password = null,
            string email = null,
            string alias = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userLogin", userLogin),
                new SimpleParameter("password", password),
                new SimpleParameter("email", email),
                new SimpleParameter("alias", alias)
            };

            return this.sendRequest<Dictionary<string, List<object>>>("updateUser", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Delete a piwik user
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns>Dictionary<string, List<object> containing the result message</returns>
        public Dictionary<string, List<object>> deleteUser(
            string userLogin)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userLogin", userLogin)
            };

            return this.sendRequest<Dictionary<string, List<object>>>("deleteUser", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Check if a piwik user with given login exists
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        public bool userExists(
            string userLogin)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userLogin", userLogin)
            };

            return this.sendRequest<bool>("userExists", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Check if a piwik user with given email exists
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public bool userEmailExists(
            string userEmail)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userEmail", userEmail)
            };

            return this.sendRequest<bool>("userEmailExists", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Get the login for a piwik user with a given email
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public string getUserLoginFromUserEmail(
            string userEmail)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userEmail", userEmail)
            };

            return this.sendRequest<string>("getUserLoginFromUserEmail", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Set the access of a piwik user on a list of site ids
        /// </summary>
        /// <param name="userLogin"></param>
        /// <param name="access"></param>
        /// <param name="idSites"></param>
        /// <returns>Dictionary<string, List<object> containing the result message</returns>
        public Dictionary<string, List<object>> setUserAccess(
            string userLogin,
            UserAccess access,
            int[] idSites)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userLogin", userLogin),
                new SimpleParameter("access", access.ToString()),
                new SimpleParameter("idSites", String.Join(",", idSites))
            };

            return this.sendRequest<Dictionary<string, List<object>>>("setUserAccess", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Calculates the token auth by using a user login and a md5 hashed password
        /// </summary>
        /// <param name="userLogin"></param>
        /// <param name="md5Password"></param>
        /// <returns>A calculated token auth string</returns>
        public string getTokenAuth(
            string userLogin,
            string md5Password)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userLogin", userLogin),
                new SimpleParameter("md5Password", md5Password)
            };

            return this.sendRequest<string>("getTokenAuth", new List<Parameter>(parameters));
        }
    }
}
