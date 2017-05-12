namespace SiscomSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDTABLEFACTURA : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        pkFactura = c.Int(nullable: false, identity: true),
                        sTipCambio = c.String(unicode: false),
                        fkCliente = c.Int(nullable: false),
                        sNombre = c.String(unicode: false),
                        sDireccion = c.String(unicode: false),
                        sRFC = c.String(unicode: false),
                        sTelefono = c.String(unicode: false),
                        dtFecha = c.DateTime(nullable: false, precision: 0),
                        bStatus = c.Boolean(nullable: false),
                        iCaja = c.Int(nullable: false),
                        iFolio = c.Int(nullable: false),
                        sTurno = c.String(unicode: false),
                        sVendedor = c.String(unicode: false),
                        sRegion = c.String(unicode: false),
                        iCodigo = c.Int(nullable: false),
                        iCantidad = c.Int(nullable: false),
                        sUDM = c.String(unicode: false),
                        dCostoPro = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dPreVta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dImporte = c.Decimal(nullable: false, precision: 18, scale: 2),
                        sImpuestos = c.String(unicode: false),
                        iDescuento = c.Int(nullable: false),
                        iArticulo = c.Int(nullable: false),
                        fkEmpresa_pkEmpresa = c.Int(),
                    })
                .PrimaryKey(t => t.pkFactura)
                .ForeignKey("dbo.Empresas", t => t.fkEmpresa_pkEmpresa)
                .Index(t => t.fkEmpresa_pkEmpresa);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facturas", "fkEmpresa_pkEmpresa", "dbo.Empresas");
            DropIndex("dbo.Facturas", new[] { "fkEmpresa_pkEmpresa" });
            DropTable("dbo.Facturas");
        }
    }
}
