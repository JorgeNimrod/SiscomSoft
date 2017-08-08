namespace SiscomSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OFICIALBRUNO2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventario", "fkAlmacen_pkAlmacen", c => c.Int());
            CreateIndex("dbo.Inventario", "fkAlmacen_pkAlmacen");
            AddForeignKey("dbo.Inventario", "fkAlmacen_pkAlmacen", "dbo.Almacenes", "pkAlmacen");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventario", "fkAlmacen_pkAlmacen", "dbo.Almacenes");
            DropIndex("dbo.Inventario", new[] { "fkAlmacen_pkAlmacen" });
            DropColumn("dbo.Inventario", "fkAlmacen_pkAlmacen");
        }
    }
}
