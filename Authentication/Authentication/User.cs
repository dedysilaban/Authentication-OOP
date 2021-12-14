using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication
{
    class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string password { get; set; }

        public User()
        {

        }

        public User(string namaDepan, string namaBelakang, string usern, string pass) 
        {
            this.FirstName = namaDepan;
            this.LastName = namaBelakang;
            this.UserName = usern;
            this.password = pass;

        }

    }
}
