using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq;

namespace WorkoutWeb
{

    public class CyberWorkoutSession : WorkoutData.Contracts.ICyberWorkoutWebSession
    {
        public const string CURRENTLOGINKEY = "CURRENTLOGIN";
        public const string CURRENTUSERKEY = "CURRENTUSER";
        public const string LOGGEDINTIMEKEY = "TIMELOGGEDIN";

        private System.Web.SessionState.HttpSessionState Session
        {
            get
            {
                return HttpContext.Current.Session;
            }
        }

        private T get<T>(string key)
        {
            if (Session[key] == null)
            {
                return default(T);
            }
            return (T)Session[key];
        }

        private void set<T>(string key, T value)
        {
            if (Session[key] == null)
            {
                Session.Add(key, value);
            }
            else
            {
                Session[key] = value;
            }
        }

        public string CurrentLoginName
        {
            get { return LoggedInUser == null ? "" : LoggedInUser.Handle; }
            set { }
        }

        public string CurrentLoginEmail
        {
            get { return CurrentLogin == null ? "" : CurrentLogin.EmailAddress; }
            set { }
        }

        public WorkoutData.Login CurrentLogin
        {
            get { return get<WorkoutData.Login>(CURRENTLOGINKEY); }
            set { set(CURRENTLOGINKEY, value); }
        }

        public WorkoutData.Person LoggedInUser
        {
            get { return get<WorkoutData.Person>(CURRENTUSERKEY); }
            set { set(CURRENTUSERKEY, value); }
        }

        public DateTime LoggedInTime
        {
            get { return get<DateTime>(LOGGEDINTIMEKEY); }
            set { set(LOGGEDINTIMEKEY, value); }
        }

        public WorkoutData.Login UserLogin
        {
            get
            {
                return CurrentLogin;
            }
            set
            {
                CurrentLogin = value;
            }
        }

        public string[] UserRoles
        {
            get
            {
                return string.IsNullOrEmpty(UserLogin.Roles) ? new string[] { } : UserLogin.Roles.Split(',');
            }
        }
    }
}