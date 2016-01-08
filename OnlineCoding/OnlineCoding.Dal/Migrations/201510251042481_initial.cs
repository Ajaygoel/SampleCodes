using System.Data.Entity.Migrations;

namespace OnlineCoding.Dal.Migrations
{
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompilerClients",
                c => new
                {
                    Id = c.Int(false, true),
                    ClientName = c.String(),
                    ClientIpAddress = c.String(),
                    ConnectedOn = c.DateTime(false),
                    DisconnectedOn = c.DateTime(false),
                    IsConnected = c.String()
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.CompileResults",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(),
                    IsCompiledSuccesfully = c.Boolean(false),
                    CompiledOn = c.DateTime(false)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.TestResults",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(),
                    IsSuccessful = c.Boolean(false),
                    ResultDescription = c.String()
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.TestResults");
            DropTable("dbo.CompileResults");
            DropTable("dbo.CompilerClients");
        }
    }
}