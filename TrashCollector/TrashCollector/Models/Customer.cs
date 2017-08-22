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

        [ForeignKey("ApplicationUser")]       
        public string UserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public Address Address { get; set; }
        public int AddressID { get; set; }
        
        public Pickup Pickup { get; set; }
        [Display(Name = "Schedule a Pickup Day")]
        public int? PickupID { get; set; }

        public IEnumerable<Pickup> Pickups { get; set; }

        public Billing Billing { get; set; }
        public int BillingID { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Reason")]
        public string Comment { get; set; }
    }
}