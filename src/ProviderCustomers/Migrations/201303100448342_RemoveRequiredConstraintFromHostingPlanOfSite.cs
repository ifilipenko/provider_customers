namespace ProviderCustomers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredConstraintFromHostingPlanOfSite : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sites", "Plan_Id", "dbo.HostingPlans");
            DropIndex("dbo.Sites", new[] { "Plan_Id" });
            AlterColumn("dbo.Sites", "Plan_Id", c => c.Long());
            AddForeignKey("dbo.Sites", "Plan_Id", "dbo.HostingPlans", "Id");
            CreateIndex("dbo.Sites", "Plan_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Sites", new[] { "Plan_Id" });
            DropForeignKey("dbo.Sites", "Plan_Id", "dbo.HostingPlans");
            AlterColumn("dbo.Sites", "Plan_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.Sites", "Plan_Id");
            AddForeignKey("dbo.Sites", "Plan_Id", "dbo.HostingPlans", "Id", cascadeDelete: true);
        }
    }
}
