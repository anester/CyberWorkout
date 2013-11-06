using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkoutData.Contracts;


namespace WorkoutWeb
{
    public class BaseController : Controller
    {

    }

    [SessionRequired]
    public class SecureController<T> : BaseController
        where T : IBaseManager
    {
        public T Manager { get; set; }
        public ICyberWorkoutWebSession WorkoutWebSession { get; set; }

        public SecureController()
        {
            WorkoutWebSession = new CyberWorkoutSession();
            Manager = (T)Activator.CreateInstance(typeof(T), WorkoutWebSession);
        }

        protected override void OnAuthentication(System.Web.Mvc.Filters.AuthenticationContext filterContext)
        {
            base.OnAuthentication(filterContext);
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (WorkoutWebSession.UserLogin != null)
            {
                ViewBag.User = WorkoutWebSession.UserLogin.EmailAddress;
            }
            base.OnActionExecuting(filterContext);
        }

    }
}
