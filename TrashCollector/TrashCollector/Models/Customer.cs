using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        public string UserID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public Address Address { get; set; }
        public int AddressID { get; set; }

        public AccountType AccountType { get; set; }
        [Display(Name = "Account Type")]
        public int AccountTypeID { get; set; }

        public IEnumerable<AccountType> AccountTypes { get; set; }

        public Pickup Pickup { get; set; }
        [Display(Name = "Schedule a Pickup Day")]
        public int PickupID { get; set; }

        public IEnumerable<Pickup> Pickups { get; set; }

    }
}