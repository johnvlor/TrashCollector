using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Pickup
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Pick Up Day")]
        public string Day { get; set; }

        [Display(Name = "New Pick Up Day")]
        public string AlternateDay { get; set; }
    }
}