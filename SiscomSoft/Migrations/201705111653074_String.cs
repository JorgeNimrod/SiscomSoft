namespace SiscomSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class String : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productos", "sUnidadMed", c => c.String(unicode: false));
            DropColumn("dbo.Productos", "iUnidadMed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Productos", "iUnidadMed", c => c.Int(nullable: false));
            DropColumn("dbo.Productos", "sUnidadMed");
        }
    }
}
