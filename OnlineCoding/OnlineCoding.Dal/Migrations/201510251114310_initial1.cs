using System.Data.Entity.Migrations;

namespace OnlineCoding.Dal.Migrations
{
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompilerClients", "TimeStamp", c => c.DateTime(false));
            AddColumn("dbo.CompileResults", "TimeStamp", c => c.DateTime(false));
            AddColumn("dbo.TestResults", "TimeStamp", c => c.DateTime(false));
        }

        public override void Down()
        {
            DropColumn("dbo.TestResults", "TimeStamp");
            DropColumn("dbo.CompileResults", "TimeStamp");
            DropColumn("dbo.CompilerClients", "TimeStamp");
        }
    }
}