namespace calumetbase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Long(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Creator = c.String(),
                        DateOrTime = c.String(nullable: false),
                        Link = c.String(),
                        Comments = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.EventID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}
