using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using StartToBike.Models;

namespace StartToBike.Models
{
    public class Route
    {
        public Route()
        {
            ApplicationUser = new HashSet<ApplicationUser>();
        }
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string Length { get; set; }
        public int Difficulty { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUser { get; set;}

    }
}