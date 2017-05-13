namespace SiscomSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusCertificado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Certificados", "bStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Certificados", "bStatus");
        }
    }
}
