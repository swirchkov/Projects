namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tokenaddedmigation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthehticationTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Token = c.String(),
                        Expires = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuthehticationTokens", "UserId", "dbo.Users");
            DropIndex("dbo.AuthehticationTokens", new[] { "UserId" });
            DropTable("dbo.AuthehticationTokens");
        }
    }
}
