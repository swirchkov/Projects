namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class participaterequestmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParticipateRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TournamentId = c.Int(nullable: false),
                        Accepted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tournaments", t => t.TournamentId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TournamentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParticipateRequests", "UserId", "dbo.Users");
            DropForeignKey("dbo.ParticipateRequests", "TournamentId", "dbo.Tournaments");
            DropIndex("dbo.ParticipateRequests", new[] { "TournamentId" });
            DropIndex("dbo.ParticipateRequests", new[] { "UserId" });
            DropTable("dbo.ParticipateRequests");
        }
    }
}
