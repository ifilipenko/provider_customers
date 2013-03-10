namespace ProviderCustomers.Models
{
    public class HostingPlanViewModel
    {
        public HostingPlanViewModel(long? id, string name)
        {
            Id = id;
            Name = name;
        }

        public long? Id { get; set; }
        public string Name { get; set; }
    }
}