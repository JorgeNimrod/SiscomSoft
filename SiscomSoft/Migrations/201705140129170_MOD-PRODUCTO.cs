namespace SiscomSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MODPRODUCTO : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productos", "iClaveProd", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productos", "iClaveProd");
        }
    }
}
