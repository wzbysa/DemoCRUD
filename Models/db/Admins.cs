using System;
using System.Collections.Generic;

namespace DEMOCRUD.Models.db
{
    public partial class Admins
    {
        public Admins()
        {
           
        }

        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string  Phone{ get; set;  }
        public DateTime Created { get; set; }
        
    }
}
