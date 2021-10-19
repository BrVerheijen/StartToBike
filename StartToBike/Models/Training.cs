using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartToBike.Models
{
    public class Training
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }
        public bool Type { get; set; }

        public string Pros { get; set; }

        public DateTime Duration { get; set; }

        public int Difficulty { get; set; }

        public ICollection<ApplicationUser> UserList { get; set; }

    }
}