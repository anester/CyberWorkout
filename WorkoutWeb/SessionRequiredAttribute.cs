using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WorkoutLogic.Managers;

namespace WorkoutWeb
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CustomAuthorizationAttribute : Attribute
    {
        public string Role { get; set; }
    }

    public class SessionRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            CyberWorkoutSession websession = new CyberWorkoutSession();
            LoginManager manager = new LoginManager(websession);
            
            if (!manager.IsLoggedIn())
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    // For AJAX link call, the redirect is done from the javascript on session timeout.
                    filterContext.Result = new JsonResult { Data = "TimeOut" };
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary { { "area", "" }, { "controller", "Login" }, { "action", "Index" } }
                    );
                }
            }
            else
            {
                Type controllertype = filterContext.ActionDescriptor.ControllerDescriptor.ControllerType;
                string[] roles = controllertype.GetCustomAttributes(typeof(CustomAuthorizationAttribute), false)
                                               .OfType<CustomAuthorizationAttribute>()
                                               .Select(c => c.Role)
                                               .ToArray();
                if (roles.Length > 0 && !roles.Contains("All"))
                {
                    if (websession.UserRoles.Where(ur => roles.Contains(ur)).FirstOrDefault() == null)
                    {
                        filterContext.Result = new RedirectToRouteResult(
                            new RouteValueDictionary { { "area", "" }, { "controller", "Home" }, { "action", "Index" } }
                        );
                    }
                }
            }
        }
    }
}
