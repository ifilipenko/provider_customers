using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProviderCustomers.Models.Domain;

namespace ProviderCustomers.Models
{
    public class SiteListItemViewModel
    {
        public SiteListItemViewModel(Site site)
        {
            Id = site.Id;
            Address = site.Address;
            Description = site.Description;
            Rating = site.Rating;
            PlanName = site.Plan == null ? "Not specified" : site.Plan.Name;
            Logo = site.Logo == null ? null : "data:image/" + site.LogoType + ";base64," + Convert.ToBase64String(site.Logo);
        }

        [Key]
        public long Id { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public int Rating { get; set; }
        [DisplayName("Last edited")]
        public DateTime LastEdited { get; set; }

        [DisplayName("Hosting plan")]
        public string PlanName { get; set; }
        
        public string Logo { get; set; }
    }
}