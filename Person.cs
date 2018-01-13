using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Person
    {
        private string password;
        private string iD;
        public string ID
        {
            get { return iD; }
            set { iD = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public Person()
        {
            ID = null;
            Password = null;
        }
        public Person(string id,string Pasword)
        {
            ID = id;
            Password = Pasword;
        }
        public Person(string Pasword)
        {
            Password = Pasword;
        }
    }
}
