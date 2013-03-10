using System.ComponentModel;

namespace ProviderCustomers.Models.Domain
{
    public class HostingPlan
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Paying { get; set; }
        public decimal Plan { get; set; }
    }
}