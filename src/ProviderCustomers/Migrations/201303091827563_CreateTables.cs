namespace ProviderCustomers.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sites",
                c => new
                    {
                        Id          = c.Long(nullable: false, identity: true),
                        Address     = c.String(),
                        Description = c.String(),
                        Rating      = c.Int(nullable: false),
                        LastEdited  = c.DateTime(nullable: false),
                        Plan_Id     = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HostingPlans", t => t.Plan_Id)
                .Index(t => t.Plan_Id);

            CreateTable(
                "dbo.HostingPlans",
                c => new
                    {
                        Id     = c.Long(nullable: false, identity: true),
                        Name   = c.String(),
                        Paying = c.Boolean(nullable: false),
                        Plan   = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Sites", new[] { "Plan_Id" });
            DropForeignKey("dbo.Sites", "Plan_Id", "dbo.HostingPlans");
            DropTable("dbo.HostingPlans");
            DropTable("dbo.Sites");
        }
    }
}
