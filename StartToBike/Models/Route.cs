using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StartToBike.Models;

namespace StartToBike.Models
{
    public class Route
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string Length { get; set; }
        public int Difficulty { get; set; }

        public ICollection<ApplicationUser> UserList { get; set;}

    }
}