namespace OnlineCoding.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompileResults", "CompilerClient_Id", c => c.Int());
            AddColumn("dbo.TestResults", "CompilerClient_Id", c => c.Int());
            CreateIndex("dbo.CompileResults", "CompilerClient_Id");
            CreateIndex("dbo.TestResults", "CompilerClient_Id");
            AddForeignKey("dbo.CompileResults", "CompilerClient_Id", "dbo.CompilerClients", "Id");
            AddForeignKey("dbo.TestResults", "CompilerClient_Id", "dbo.CompilerClients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestResults", "CompilerClient_Id", "dbo.CompilerClients");
            DropForeignKey("dbo.CompileResults", "CompilerClient_Id", "dbo.CompilerClients");
            DropIndex("dbo.TestResults", new[] { "CompilerClient_Id" });
            DropIndex("dbo.CompileResults", new[] { "CompilerClient_Id" });
            DropColumn("dbo.TestResults", "CompilerClient_Id");
            DropColumn("dbo.CompileResults", "CompilerClient_Id");
        }
    }
}
