using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class AccountType
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Account Type")]
        public string Type { get; set; }
    }
}