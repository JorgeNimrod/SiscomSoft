namespace SiscomSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "iPin", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "iPin");
        }
    }
}
