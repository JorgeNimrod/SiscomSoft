namespace SiscomSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INICIAL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productos", "dPreVenta", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Ventas", "iTurno", c => c.Int(nullable: false));
            AddColumn("dbo.Ventas", "iCaja", c => c.Int(nullable: false));
            AddColumn("dbo.Ventas", "fkUsuario_pkUsuario", c => c.Int());
            CreateIndex("dbo.Ventas", "fkUsuario_pkUsuario");
            AddForeignKey("dbo.Ventas", "fkUsuario_pkUsuario", "dbo.Usuarios", "pkUsuario");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ventas", "fkUsuario_pkUsuario", "dbo.Usuarios");
            DropIndex("dbo.Ventas", new[] { "fkUsuario_pkUsuario" });
            DropColumn("dbo.Ventas", "fkUsuario_pkUsuario");
            DropColumn("dbo.Ventas", "iCaja");
            DropColumn("dbo.Ventas", "iTurno");
            DropColumn("dbo.Productos", "dPreVenta");
        }
    }
}
