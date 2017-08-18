using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Billing
    {
        [Key]
        public int ID {get; set;}

        public double Charges { get; set; }

    }
}