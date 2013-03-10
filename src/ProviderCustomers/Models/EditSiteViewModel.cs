using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using ProviderCustomers.Models.Domain;

namespace ProviderCustomers.Models
{
    public class EditSiteViewModel
    {
        public EditSiteViewModel()
        {
        }

        public EditSiteViewModel(IEnumerable<HostingPlan> plans)
        {
            Plans = plans.ToDictionary(x => x.Id, x => x.Name);
        }

        public EditSiteViewModel(Site site, IEnumerable<HostingPlan> plans)
            : this(plans)
        {
            Id          = site.Id;
            Address     = site.Address;
            Description = site.Description;
            Rating      = site.Rating;
            LastEdited  = site.LastEdited;
            if (site.Plan != null)
            {
                PlanId = site.Plan.Id;
            }
        }

        [Editable(false)]
        public bool IsNew
        {
            get { return Id == 0; }
        }

        [Key, HiddenInput]
        public long Id { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Description { get; set; }

        public int Rating { get; set; }

        [DisplayName("Last edited")]
        public DateTime LastEdited { get; set; }

        [Required, DisplayName("Plan")]
        public long PlanId { get; set; }

        public Dictionary<long, string> Plans { get; set; }

        public void SaveSite(Site site, IEnumerable<HostingPlan> allPlans)
        {
            site.Id          = Id;
            site.Address     = Address;
            site.Description = Description;
            site.Rating      = Rating;
            site.LastEdited  = LastEdited;
            site.Plan        = allPlans.Single(p => p.Id == PlanId);
        }
    }
}