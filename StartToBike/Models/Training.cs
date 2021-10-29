using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StartToBike.Models
{
    public class Training
    {
        public Training()
        {
            ApplicationUser = new HashSet<ApplicationUser>();
        }

        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }
        public bool Type { get; set; }

        public string Pros { get; set; }

        public DateTime Duration { get; set; }

        public int Difficulty { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }

    }
}