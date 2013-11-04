using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WorkoutData;
using WorkoutData.Contracts;

namespace WorkoutLogic.Managers
{
    public enum LoginResponse
    {
        Success,
        InvalidLogin,
        PasswordExpired
    }

    public class LoginManager : BaseManager
    {
        public LoginManager(ICyberWorkoutWebSession websession)
            : base(websession)
        {
        }

        public bool IsLoggedIn()
        {
            return WebSession.UserLogin != null;
        }

        public LoginResponse DoLogin(string loginemail, string password)
        {
            string hashedpasswordstr = encodePassword(password);

            var login = Context.Logins.FirstOrDefault(l => l.EmailAddress == loginemail && l.Password == hashedpasswordstr);
            if (login == null)
            {
                return LoginResponse.InvalidLogin;
            }
            WebSession.CurrentLogin = login;

            var person = Context.Persons.FirstOrDefault(p => p.LoginId == login.LoginId);
            WebSession.LoggedInUser = person;
            WebSession.LoggedInTime = DateTime.Now;

            return LoginResponse.Success;
        }

        public bool CreateUser(string email, string password, string handle, string firstname, string lastname, DateTime? dob)
        {

            try
            {
                Login login = new Login()
                {
                    EmailAddress = email,
                    Password = encodePassword(password),
                    Roles = "User"
                };

                Person person = new Person()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Handle = handle,
                    BirthDate = dob
                };

                Context.Logins.Add(login);
                Context.SaveChanges();
                person.LoginId = login.LoginId;
                Context.Persons.Add(person);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        private static string encodePassword(string password)
        {
            byte[] encodedpass = Encoding.UTF8.GetBytes(password);
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            Byte[] hashed = sha1.ComputeHash(encodedpass);
            string hashedpasswordstr = Encoding.UTF8.GetString(hashed);
            return hashedpasswordstr;
        }
    }
}
