using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Worker
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //public Address Address { get; set; }
        //public int AddressID { get; set; }

        [Display (Name = "Zip Code")]
        [RegularExpression(@"\d{5}$", ErrorMessage = "Invalid Zip Code")]
        public string Zip { get; set; }

        //public AccountType AccountType { get; set; }
        //[Display(Name = "Account Type")]
        //public int AccountTypeID { get; set; }

        //public IEnumerable<AccountType> AccountTypes { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}