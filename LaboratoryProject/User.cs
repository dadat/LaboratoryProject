using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryProject
{
    class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public DateTime dateRegistered { get; set; }
        public bool isActive { get; set; }
    }
}
