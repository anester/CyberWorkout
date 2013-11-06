using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WorkoutData.Contracts;
using WorkoutLogic.Managers;

namespace WorkoutWebApp.Controllers
{
    public class AccountCheckModel
    {
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
    }

    public class AccountChecksController : ApiController
    {
        // GET api/accountchecks
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/accountchecks/5
        public bool Get(string fieldname, string fieldvalue)
        {
            AccountCheckManager mngr = new AccountCheckManager();
            if (fieldname.ToLower() == "email")
            {
                return mngr.EmailExists(fieldvalue);
            }
            else if (fieldname.ToLower() == "handle")
            {
                return mngr.HandleExists(fieldvalue);
            }

            return false;
        }

        // POST api/accountchecks
        public bool Post([FromBody]AccountCheckModel field)
        {
            AccountCheckManager mngr = new AccountCheckManager();
            if (field.FieldName.ToLower() == "email")
            {
                return mngr.EmailExists(field.FieldValue);
            }
            else if (field.FieldName.ToLower() == "handle")
            {
                return mngr.HandleExists(field.FieldValue);
            }

            return false;

        }

        // PUT api/accountchecks/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/accountchecks/5
        public void Delete(int id)
        {
        }
    }
}
