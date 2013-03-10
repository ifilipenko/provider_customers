namespace ProviderCustomers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetValidationRules : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sites", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Sites", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sites", "Description", c => c.String());
            AlterColumn("dbo.Sites", "Address", c => c.String());
        }
    }
}
