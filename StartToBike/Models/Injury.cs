using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartToBike.Models
{
    public class Injury
    {
        public Injury()
        {
            ApplicationUser = new HashSet<ApplicationUser>();
        }

        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public string Picture { get; set; }
        public string Prevention { get; set; }
        public string Treatement { get; set; }
        
        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
    }
}