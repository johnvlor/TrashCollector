using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Address
    {
        [Key]
        public int ID { get; set; }

        public string Street { get; set; }

        public string City { get; set; }       

        public string State { get; set; }

        [RegularExpression(@"\d{5}$", ErrorMessage = "Invalid Zip Code")]
        public string Zip { get; set; }

    }
}