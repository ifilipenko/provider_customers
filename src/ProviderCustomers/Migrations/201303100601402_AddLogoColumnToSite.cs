namespace ProviderCustomers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLogoColumnToSite : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sites", "Logo", c => c.Binary());
            AddColumn("dbo.Sites", "LogoType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sites", "LogoType");
            DropColumn("dbo.Sites", "Logo");
        }
    }
}
