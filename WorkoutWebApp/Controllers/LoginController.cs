using SimpleList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WorkoutLogic.Managers;
using WorkoutData.Contracts;

namespace WorkoutWebApp.Controllers
{
    public class LoginController : Controller
    {
        public ICyberWorkoutWebSession WebSession { get; set; }
        public LoginManager Manager { get; set; }

        public LoginController()
        {
            WebSession = new CyberWorkoutSession();
            Manager = new LoginManager(WebSession);
        }

        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin(WorkoutData.Login login)
        {
            var res = Manager.DoLogin(login.EmailAddress, login.Password);
            if (res == LoginResponse.Success)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Create");
        }

        //
        // GET: /Login/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Login/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Login/Create

        [HttpPost]
        public ActionResult Create(WorkoutData.Person person)
        {
            try
            {
                Manager.CreateUser(person.PersonLogin.EmailAddress, person.PersonLogin.Password,
                    person.Handle, person.FirstName, person.LastName, person.BirthDate);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Login/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Login/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Login/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Login/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
