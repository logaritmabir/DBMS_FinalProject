using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_Final
{
    class User
    {
        private string userName;
        private string password;


        public void setUserName(string uName)
        {
            userName = uName;
        }

        public string getUserName()
        {
            return userName;
        }

        public void setPassword(string pwd)
        {
            password = pwd;
        }

        public string getPassword()
        {
            return password;
        }
    }
}
