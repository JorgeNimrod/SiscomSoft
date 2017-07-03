namespace SiscomSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INICIAL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InventariosEntradas", "dPreUnitario", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.InventariosEntradas", "dPrecio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InventariosEntradas", "dPrecio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.InventariosEntradas", "dPreUnitario");
        }
    }
}
