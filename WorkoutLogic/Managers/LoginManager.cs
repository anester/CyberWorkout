using System;
using System.Collections.Generic;
using System.IO;
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

        public bool DoLogout()
        {
            WebSession.CurrentLogin = null;
            WebSession.LoggedInTime = DateTime.MinValue;
            return true;
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

        public const string DEFAULT_KEY = "0P9ln81asdf#%dog1w8as2g2ABY7V0d=";
        public const string DEFAULT_SEED = "dIOh4fhx5iL6JzGw6b2B1yp56jxShQqw";

        private static string encodePassword(string password)
        {
            byte[] salt = Encoding.UTF8.GetBytes(DEFAULT_SEED);
            byte[] initVector = Encoding.UTF8.GetBytes(DEFAULT_KEY);
            ICryptoTransform encryptor;

            byte[] encodedpass = Encoding.UTF8.GetBytes(password);
            RijndaelManaged aes = new RijndaelManaged() { BlockSize = 256, KeySize = 256 };
            encryptor = aes.CreateEncryptor(salt, initVector);

            using (MemoryStream memStr = new MemoryStream())
            {
                CryptoStream crypto = new CryptoStream(memStr, encryptor, CryptoStreamMode.Write);
                crypto.Write(encodedpass, 0, encodedpass.Length);
                crypto.FlushFinalBlock();
                Byte[] hashed = memStr.ToArray();
                string hashedpasswordstr = Convert.ToBase64String(hashed);
                
                return hashedpasswordstr;
            }
        }
    }
}
