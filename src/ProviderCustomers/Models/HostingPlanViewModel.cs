using ProviderCustomers.Models.Domain;

namespace ProviderCustomers.Models
{
    public class HostingPlanViewModel
    {
        public HostingPlanViewModel(long? id, string name)
        {
            Id = id;
            Name = name;
        }

        public HostingPlanViewModel(HostingPlan plan)
        {
            Id = plan.Id;
            Name = string.Format("{0}, ${1}", plan.Name, plan.Plan);
        }

        public long? Id { get; set; }
        public string Name { get; set; }
    }
}