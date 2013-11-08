using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkoutLogic.Managers;
using WorkoutWeb;

namespace WorkoutWebApp.Controllers
{
    public class AccountController : SecureController<AccountManager>
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }

    }
}
