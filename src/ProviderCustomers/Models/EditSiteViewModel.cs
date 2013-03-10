using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProviderCustomers.Models.Domain;

namespace ProviderCustomers.Models
{
    public class EditSiteViewModel
    {
        public EditSiteViewModel()
        {
        }

        public EditSiteViewModel(Site site)
        {
            Id          = site.Id;
            Address     = site.Address;
            Description = site.Description;
            Rating      = site.Rating;
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

        [Required, StringLength(200)]
        public string Address { get; set; }

        [Required, StringLength(4000)]
        public string Description { get; set; }

        public int Rating { get; set; }

        [DisplayName("Plan")]
        public long? PlanId { get; set; }

        public HttpPostedFileBase Logo { get; set; }

        public void SaveSite(Site site, IEnumerable<HostingPlan> allPlans)
        {
            site.Id          = Id;
            site.Address     = Address;
            site.Description = Description;
            site.Rating      = Rating;
            site.LastEdited  = DateTime.Now;
            site.Plan        = allPlans.SingleOrDefault(p => p.Id == PlanId);
            if (Logo != null)
            {
                site.SetLogo(Logo);
            }
        }
    }
}