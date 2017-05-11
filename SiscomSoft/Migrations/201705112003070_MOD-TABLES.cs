namespace SiscomSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MODTABLES : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        pkCategoria = c.Int(nullable: false, identity: true),
                        sNombre = c.String(unicode: false),
                        sNomSubCat = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.pkCategoria);
            
            CreateTable(
                "dbo.CatalogosSAT",
                c => new
                    {
                        pkCatalogoSAT = c.Int(nullable: false, identity: true),
                        sUnidMed = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.pkCatalogoSAT);
            
            CreateTable(
                "dbo.InventariosEntradas",
                c => new
                    {
                        pkInventioEntrada = c.Int(nullable: false, identity: true),
                        dtFecha = c.DateTime(nullable: false, precision: 0),
                        sTipoPago = c.String(unicode: false),
                        sMoneda = c.String(unicode: false),
                        iNoFactura = c.Int(nullable: false),
                        dCantidad = c.Double(nullable: false),
                        sNomProducto = c.String(unicode: false),
                        dPrecio = c.Double(nullable: false),
                        iDescuento = c.Int(nullable: false),
                        iLote = c.Int(nullable: false),
                        dtCaducidad = c.DateTime(nullable: false, precision: 0),
                        bStatus = c.Boolean(nullable: false),
                        fkProveedor_pkCliente = c.Int(),
                    })
                .PrimaryKey(t => t.pkInventioEntrada)
                .ForeignKey("dbo.Clientes", t => t.fkProveedor_pkCliente)
                .Index(t => t.fkProveedor_pkCliente);
            
            CreateTable(
                "dbo.Precios",
                c => new
                    {
                        pkPrecios = c.Int(nullable: false, identity: true),
                        iPrePorcen = c.Int(nullable: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkPrecios);
            
            AddColumn("dbo.Empresas", "bStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Sucursales", "bStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Preferencias", "bStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Productos", "iDescuento", c => c.Int(nullable: false));
            AddColumn("dbo.Productos", "sFoto", c => c.String(unicode: false));
            AddColumn("dbo.Productos", "dtCaducidad", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.Productos", "iLote", c => c.Int(nullable: false));
            AddColumn("dbo.Productos", "fkCatalogoSAT_pkCatalogoSAT", c => c.Int());
            AddColumn("dbo.Productos", "fkCategoria_pkCategoria", c => c.Int());
            AddColumn("dbo.Productos", "fkInventarioEntrada_pkInventioEntrada", c => c.Int());
            AddColumn("dbo.Productos", "fkPrecio_pkPrecios", c => c.Int());
            CreateIndex("dbo.Productos", "fkCatalogoSAT_pkCatalogoSAT");
            CreateIndex("dbo.Productos", "fkCategoria_pkCategoria");
            CreateIndex("dbo.Productos", "fkInventarioEntrada_pkInventioEntrada");
            CreateIndex("dbo.Productos", "fkPrecio_pkPrecios");
            AddForeignKey("dbo.Productos", "fkCatalogoSAT_pkCatalogoSAT", "dbo.CatalogosSAT", "pkCatalogoSAT");
            AddForeignKey("dbo.Productos", "fkCategoria_pkCategoria", "dbo.Categorias", "pkCategoria");
            AddForeignKey("dbo.Productos", "fkInventarioEntrada_pkInventioEntrada", "dbo.InventariosEntradas", "pkInventioEntrada");
            AddForeignKey("dbo.Productos", "fkPrecio_pkPrecios", "dbo.Precios", "pkPrecios");
            DropColumn("dbo.Productos", "sCategoria");
            DropColumn("dbo.Productos", "sUnidadMed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Productos", "sUnidadMed", c => c.String(unicode: false));
            AddColumn("dbo.Productos", "sCategoria", c => c.String(unicode: false));
            DropForeignKey("dbo.Productos", "fkPrecio_pkPrecios", "dbo.Precios");
            DropForeignKey("dbo.Productos", "fkInventarioEntrada_pkInventioEntrada", "dbo.InventariosEntradas");
            DropForeignKey("dbo.InventariosEntradas", "fkProveedor_pkCliente", "dbo.Clientes");
            DropForeignKey("dbo.Productos", "fkCategoria_pkCategoria", "dbo.Categorias");
            DropForeignKey("dbo.Productos", "fkCatalogoSAT_pkCatalogoSAT", "dbo.CatalogosSAT");
            DropIndex("dbo.InventariosEntradas", new[] { "fkProveedor_pkCliente" });
            DropIndex("dbo.Productos", new[] { "fkPrecio_pkPrecios" });
            DropIndex("dbo.Productos", new[] { "fkInventarioEntrada_pkInventioEntrada" });
            DropIndex("dbo.Productos", new[] { "fkCategoria_pkCategoria" });
            DropIndex("dbo.Productos", new[] { "fkCatalogoSAT_pkCatalogoSAT" });
            DropColumn("dbo.Productos", "fkPrecio_pkPrecios");
            DropColumn("dbo.Productos", "fkInventarioEntrada_pkInventioEntrada");
            DropColumn("dbo.Productos", "fkCategoria_pkCategoria");
            DropColumn("dbo.Productos", "fkCatalogoSAT_pkCatalogoSAT");
            DropColumn("dbo.Productos", "iLote");
            DropColumn("dbo.Productos", "dtCaducidad");
            DropColumn("dbo.Productos", "sFoto");
            DropColumn("dbo.Productos", "iDescuento");
            DropColumn("dbo.Preferencias", "bStatus");
            DropColumn("dbo.Sucursales", "bStatus");
            DropColumn("dbo.Empresas", "bStatus");
            DropTable("dbo.Precios");
            DropTable("dbo.InventariosEntradas");
            DropTable("dbo.CatalogosSAT");
            DropTable("dbo.Categorias");
        }
    }
}
