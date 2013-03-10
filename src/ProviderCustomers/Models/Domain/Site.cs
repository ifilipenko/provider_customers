using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProviderCustomers.Models.Domain
{
    public class Site
    {
        [Key, HiddenInput]
        public long Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Description { get; set; }
        
        public int Rating { get; set; }
        [DisplayName("Last edited")]
        public DateTime LastEdited { get; set; }

        public HostingPlan Plan { get; set; }

        [DisplayName("Hosting plan")]
        public string PlanName
        {
            get { return Plan == null ? "Not specified" : Plan.Name; }
        }
    }
}