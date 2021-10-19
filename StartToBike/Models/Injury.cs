using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartToBike.Models
{
    public class Injury
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public string Picture { get; set; }
        public string Prevention { get; set; }
        public string Treatement { get; set; }
        public ICollection<ApplicationUser> UserList { get; set; }
    }
}