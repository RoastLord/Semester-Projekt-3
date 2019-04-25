using HypersWebshop.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypersWebshop.BusinessLogic
{
    public class LoginController
    {
        DBLogin dBLogin;
        public LoginController()
        {
            dBLogin = new DBLogin();
            
        }

        public bool CheckLogin(string userName, string password)
        {
            bool check = false;

            string dbPassword = dBLogin.GetPassword(userName);
            if (password == dbPassword)
            {
                check = true;
            }

            return check;
        }

        public void LoginToDesktop()
        {

        }
    }
}
