using System.ComponentModel.DataAnnotations;

namespace ProviderCustomers.Models.Domain
{
    public class HostingPlan
    {
        public long Id { get; set; }
        [Required, StringLength(200)]
        public string Name { get; set; }
        public bool Paying { get; set; }
        public decimal Plan { get; set; }
    }
}