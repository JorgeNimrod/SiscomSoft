namespace SiscomSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INICIAL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "fkSucursal_pkSucursal", c => c.Int());
            CreateIndex("dbo.Usuarios", "fkSucursal_pkSucursal");
            AddForeignKey("dbo.Usuarios", "fkSucursal_pkSucursal", "dbo.Sucursales", "pkSucursal");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "fkSucursal_pkSucursal", "dbo.Sucursales");
            DropIndex("dbo.Usuarios", new[] { "fkSucursal_pkSucursal" });
            DropColumn("dbo.Usuarios", "fkSucursal_pkSucursal");
        }
    }
}
