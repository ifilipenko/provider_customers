namespace ProviderCustomers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatabaseConstraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sites", "Address", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Sites", "Description", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.HostingPlans", "Name", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HostingPlans", "Name", c => c.String());
            AlterColumn("dbo.Sites", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Sites", "Address", c => c.String(nullable: false));
        }
    }
}
