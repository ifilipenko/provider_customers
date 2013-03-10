using ProviderCustomers.Models;
using ProviderCustomers.Models.Domain;

namespace ProviderCustomers.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ProviderCustomersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProviderCustomersContext context)
        {
            context.HostingPlans.AddOrUpdate(p => p.Name,
                                             new HostingPlan {Name = "Free", Paying = false, Plan = 0},
                                             new HostingPlan {Name = "VIP", Paying = true, Plan = 45}
                );
        }
    }
}
