namespace SiscomSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catalogos",
                c => new
                    {
                        pkCatalogo = c.Int(nullable: false, identity: true),
                        sUDM = c.String(unicode: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkCatalogo);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        pkFactura = c.Int(nullable: false, identity: true),
                        sTipoCambio = c.String(unicode: false),
                        sNomCliente = c.String(unicode: false),
                        sDireccion = c.String(unicode: false),
                        sRFC = c.String(unicode: false),
                        sTelefono = c.String(unicode: false),
                        dtFecha = c.DateTime(nullable: false, precision: 0),
                        sFolio = c.String(unicode: false),
                        sNomVendedor = c.String(unicode: false),
                        iClavePro = c.Int(nullable: false),
                        iCantidad = c.Int(nullable: false),
                        dCostoPro = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dPreVta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dImporte = c.Decimal(nullable: false, precision: 18, scale: 2),
                        iDescuento = c.Int(nullable: false),
                        sComentario = c.String(unicode: false),
                        bStatus = c.Boolean(nullable: false),
                        fkCatalogo_pkCatalogo = c.Int(),
                        fkEmpresa_pkEmpresa = c.Int(),
                        fkImpuestos_pkImpuesto = c.Int(),
                        Cliente_pkCliente = c.Int(),
                    })
                .PrimaryKey(t => t.pkFactura)
                .ForeignKey("dbo.Catalogos", t => t.fkCatalogo_pkCatalogo)
                .ForeignKey("dbo.Empresas", t => t.fkEmpresa_pkEmpresa)
                .ForeignKey("dbo.Impuestos", t => t.fkImpuestos_pkImpuesto)
                .ForeignKey("dbo.Clientes", t => t.Cliente_pkCliente)
                .Index(t => t.fkCatalogo_pkCatalogo)
                .Index(t => t.fkEmpresa_pkEmpresa)
                .Index(t => t.fkImpuestos_pkImpuesto)
                .Index(t => t.Cliente_pkCliente);
            
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        pkEmpresa = c.Int(nullable: false, identity: true),
                        sRazonSocial = c.String(unicode: false),
                        sNomComercial = c.String(unicode: false),
                        sNomContacto = c.String(unicode: false),
                        sRegFiscal = c.String(unicode: false),
                        sTelefono = c.String(unicode: false),
                        sCorreo = c.String(unicode: false),
                        sPais = c.String(unicode: false),
                        sEstado = c.String(unicode: false),
                        sMunicipio = c.String(unicode: false),
                        sColonia = c.String(unicode: false),
                        sLocalidad = c.String(unicode: false),
                        sCalle = c.String(unicode: false),
                        iNumExterior = c.Int(nullable: false),
                        iNumInterir = c.Int(nullable: false),
                        iCodPostal = c.Int(nullable: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkEmpresa);
            
            CreateTable(
                "dbo.Sucursales",
                c => new
                    {
                        pkSucursal = c.Int(nullable: false, identity: true),
                        sNombre = c.String(unicode: false),
                        iStatus = c.Int(nullable: false),
                        sNoCertifi = c.String(unicode: false),
                        sPais = c.String(unicode: false),
                        sEstado = c.String(unicode: false),
                        sMunicipio = c.String(unicode: false),
                        sColonia = c.String(unicode: false),
                        sLocalidad = c.String(unicode: false),
                        sCalle = c.String(unicode: false),
                        iNumExterior = c.Int(nullable: false),
                        iNumInterior = c.Int(nullable: false),
                        iCodPostal = c.Int(nullable: false),
                        sMoneda = c.String(unicode: false),
                        sTipoCambio = c.String(unicode: false),
                        fkCertificado_pkCertificado = c.Int(),
                        fkEmpresa_pkEmpresa = c.Int(),
                        fkPreferencia_pkPreferencia = c.Int(),
                    })
                .PrimaryKey(t => t.pkSucursal)
                .ForeignKey("dbo.Certificados", t => t.fkCertificado_pkCertificado)
                .ForeignKey("dbo.Empresas", t => t.fkEmpresa_pkEmpresa)
                .ForeignKey("dbo.Preferencias", t => t.fkPreferencia_pkPreferencia)
                .Index(t => t.fkCertificado_pkCertificado)
                .Index(t => t.fkEmpresa_pkEmpresa)
                .Index(t => t.fkPreferencia_pkPreferencia);
            
            CreateTable(
                "dbo.Certificados",
                c => new
                    {
                        pkCertificado = c.Int(nullable: false, identity: true),
                        sArchCer = c.String(unicode: false),
                        sArchkey = c.String(unicode: false),
                        sContrasena = c.String(unicode: false),
                        sNoCertifi = c.String(unicode: false),
                        sValidoDe = c.String(unicode: false),
                        sValidoHasta = c.String(unicode: false),
                        sRutaArch = c.String(unicode: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkCertificado);
            
            CreateTable(
                "dbo.Preferencias",
                c => new
                    {
                        pkPreferencia = c.Int(nullable: false, identity: true),
                        sLogotipo = c.String(unicode: false),
                        bForImpreso = c.Boolean(nullable: false),
                        sNumSerie = c.String(unicode: false),
                        bEnvFactura = c.Boolean(nullable: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkPreferencia);
            
            CreateTable(
                "dbo.Impuestos",
                c => new
                    {
                        pkImpuesto = c.Int(nullable: false, identity: true),
                        sTipoImpuesto = c.String(unicode: false),
                        sImpuesto = c.String(unicode: false),
                        dTasaImpuesto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkImpuesto);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        pkProducto = c.Int(nullable: false, identity: true),
                        iClaveProd = c.Int(nullable: false),
                        sDescripcion = c.String(unicode: false),
                        sMarca = c.String(unicode: false),
                        dCosto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        iDescuento = c.Int(nullable: false),
                        sFoto = c.String(unicode: false),
                        dtCaducidad = c.DateTime(nullable: false, precision: 0),
                        iLote = c.Int(nullable: false),
                        bStatus = c.Boolean(nullable: false),
                        fkCatalogo_pkCatalogo = c.Int(),
                        fkCategoria_pkCategoria = c.Int(),
                        fkImpuesto_pkImpuesto = c.Int(),
                        fkPrecio_pkPrecios = c.Int(),
                    })
                .PrimaryKey(t => t.pkProducto)
                .ForeignKey("dbo.Catalogos", t => t.fkCatalogo_pkCatalogo)
                .ForeignKey("dbo.Categorias", t => t.fkCategoria_pkCategoria)
                .ForeignKey("dbo.Impuestos", t => t.fkImpuesto_pkImpuesto)
                .ForeignKey("dbo.Precios", t => t.fkPrecio_pkPrecios)
                .Index(t => t.fkCatalogo_pkCatalogo)
                .Index(t => t.fkCategoria_pkCategoria)
                .Index(t => t.fkImpuesto_pkImpuesto)
                .Index(t => t.fkPrecio_pkPrecios);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        pkCategoria = c.Int(nullable: false, identity: true),
                        sNombre = c.String(unicode: false),
                        sNomSubCat = c.String(unicode: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkCategoria);
            
            CreateTable(
                "dbo.Precios",
                c => new
                    {
                        pkPrecios = c.Int(nullable: false, identity: true),
                        iPrePorcen = c.Int(nullable: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkPrecios);
            
            CreateTable(
                "dbo.InventariosEntradas",
                c => new
                    {
                        pkInventioEntrada = c.Int(nullable: false, identity: true),
                        dtFecha = c.DateTime(nullable: false, precision: 0),
                        sTipoPago = c.String(unicode: false),
                        sMoneda = c.String(unicode: false),
                        sTipoCambio = c.String(unicode: false),
                        iCantidad = c.Int(nullable: false),
                        sNomProducto = c.String(unicode: false),
                        dPreUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        iDescuento = c.Int(nullable: false),
                        iLote = c.Int(nullable: false),
                        dtCaducidad = c.DateTime(nullable: false, precision: 0),
                        bStatus = c.Boolean(nullable: false),
                        fkCliente_pkCliente = c.Int(),
                        fkFactura_pkFactura = c.Int(),
                        fkProducto_pkProducto = c.Int(),
                    })
                .PrimaryKey(t => t.pkInventioEntrada)
                .ForeignKey("dbo.Clientes", t => t.fkCliente_pkCliente)
                .ForeignKey("dbo.Facturas", t => t.fkFactura_pkFactura)
                .ForeignKey("dbo.Productos", t => t.fkProducto_pkProducto)
                .Index(t => t.fkCliente_pkCliente)
                .Index(t => t.fkFactura_pkFactura)
                .Index(t => t.fkProducto_pkProducto);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        pkCliente = c.Int(nullable: false, identity: true),
                        sRfc = c.String(unicode: false),
                        sRazonSocial = c.String(unicode: false),
                        iPersona = c.Int(nullable: false),
                        sCurp = c.String(unicode: false),
                        sNombre = c.String(unicode: false),
                        sPais = c.String(unicode: false),
                        iCodPostal = c.Int(nullable: false),
                        sEstado = c.String(unicode: false),
                        sMunicipio = c.String(unicode: false),
                        sLocalidad = c.String(unicode: false),
                        sColonia = c.String(unicode: false),
                        sCalle = c.String(unicode: false),
                        iNumExterior = c.Int(nullable: false),
                        iNumInterior = c.Int(nullable: false),
                        sTelFijo = c.String(unicode: false),
                        sTelMovil = c.String(unicode: false),
                        sCorreo = c.String(unicode: false),
                        sReferencia = c.String(unicode: false),
                        sTipoPago = c.String(unicode: false),
                        sNumCuenta = c.String(unicode: false),
                        sConPago = c.String(unicode: false),
                        sTipoCliente = c.String(unicode: false),
                        iStatus = c.Int(nullable: false),
                        sLogo = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.pkCliente);
            
            CreateTable(
                "dbo.Permisos",
                c => new
                    {
                        pkPermiso = c.Int(nullable: false, identity: true),
                        sNombre = c.String(nullable: false, unicode: false),
                        sComentario = c.String(nullable: false, unicode: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkPermiso);
            
            CreateTable(
                "dbo.PermisosNegadosRol",
                c => new
                    {
                        pkPermisoNegadoRol = c.Int(nullable: false, identity: true),
                        bStatus = c.Boolean(nullable: false),
                        fkPermiso_pkPermiso = c.Int(nullable: false),
                        fkRol_pkRol = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.pkPermisoNegadoRol)
                .ForeignKey("dbo.Permisos", t => t.fkPermiso_pkPermiso, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.fkRol_pkRol, cascadeDelete: true)
                .Index(t => t.fkPermiso_pkPermiso)
                .Index(t => t.fkRol_pkRol);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        pkRol = c.Int(nullable: false, identity: true),
                        sNombre = c.String(nullable: false, unicode: false),
                        sComentario = c.String(nullable: false, unicode: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkRol);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        pkUsuario = c.Int(nullable: false, identity: true),
                        sRfc = c.String(unicode: false),
                        sUsuario = c.String(nullable: false, unicode: false),
                        sNombre = c.String(nullable: false, unicode: false),
                        sContrasena = c.String(nullable: false, unicode: false),
                        sPin = c.String(nullable: false, unicode: false),
                        sNumero = c.String(nullable: false, unicode: false),
                        sCorreo = c.String(nullable: false, unicode: false),
                        sComentario = c.String(nullable: false, unicode: false),
                        bStatus = c.Boolean(nullable: false),
                        fkRol_pkRol = c.Int(),
                    })
                .PrimaryKey(t => t.pkUsuario)
                .ForeignKey("dbo.Roles", t => t.fkRol_pkRol)
                .Index(t => t.fkRol_pkRol);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PermisosNegadosRol", "fkRol_pkRol", "dbo.Roles");
            DropForeignKey("dbo.Usuarios", "fkRol_pkRol", "dbo.Roles");
            DropForeignKey("dbo.PermisosNegadosRol", "fkPermiso_pkPermiso", "dbo.Permisos");
            DropForeignKey("dbo.InventariosEntradas", "fkProducto_pkProducto", "dbo.Productos");
            DropForeignKey("dbo.InventariosEntradas", "fkFactura_pkFactura", "dbo.Facturas");
            DropForeignKey("dbo.InventariosEntradas", "fkCliente_pkCliente", "dbo.Clientes");
            DropForeignKey("dbo.Facturas", "Cliente_pkCliente", "dbo.Clientes");
            DropForeignKey("dbo.Productos", "fkPrecio_pkPrecios", "dbo.Precios");
            DropForeignKey("dbo.Productos", "fkImpuesto_pkImpuesto", "dbo.Impuestos");
            DropForeignKey("dbo.Productos", "fkCategoria_pkCategoria", "dbo.Categorias");
            DropForeignKey("dbo.Productos", "fkCatalogo_pkCatalogo", "dbo.Catalogos");
            DropForeignKey("dbo.Facturas", "fkImpuestos_pkImpuesto", "dbo.Impuestos");
            DropForeignKey("dbo.Sucursales", "fkPreferencia_pkPreferencia", "dbo.Preferencias");
            DropForeignKey("dbo.Sucursales", "fkEmpresa_pkEmpresa", "dbo.Empresas");
            DropForeignKey("dbo.Sucursales", "fkCertificado_pkCertificado", "dbo.Certificados");
            DropForeignKey("dbo.Facturas", "fkEmpresa_pkEmpresa", "dbo.Empresas");
            DropForeignKey("dbo.Facturas", "fkCatalogo_pkCatalogo", "dbo.Catalogos");
            DropIndex("dbo.Usuarios", new[] { "fkRol_pkRol" });
            DropIndex("dbo.PermisosNegadosRol", new[] { "fkRol_pkRol" });
            DropIndex("dbo.PermisosNegadosRol", new[] { "fkPermiso_pkPermiso" });
            DropIndex("dbo.InventariosEntradas", new[] { "fkProducto_pkProducto" });
            DropIndex("dbo.InventariosEntradas", new[] { "fkFactura_pkFactura" });
            DropIndex("dbo.InventariosEntradas", new[] { "fkCliente_pkCliente" });
            DropIndex("dbo.Productos", new[] { "fkPrecio_pkPrecios" });
            DropIndex("dbo.Productos", new[] { "fkImpuesto_pkImpuesto" });
            DropIndex("dbo.Productos", new[] { "fkCategoria_pkCategoria" });
            DropIndex("dbo.Productos", new[] { "fkCatalogo_pkCatalogo" });
            DropIndex("dbo.Sucursales", new[] { "fkPreferencia_pkPreferencia" });
            DropIndex("dbo.Sucursales", new[] { "fkEmpresa_pkEmpresa" });
            DropIndex("dbo.Sucursales", new[] { "fkCertificado_pkCertificado" });
            DropIndex("dbo.Facturas", new[] { "Cliente_pkCliente" });
            DropIndex("dbo.Facturas", new[] { "fkImpuestos_pkImpuesto" });
            DropIndex("dbo.Facturas", new[] { "fkEmpresa_pkEmpresa" });
            DropIndex("dbo.Facturas", new[] { "fkCatalogo_pkCatalogo" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Roles");
            DropTable("dbo.PermisosNegadosRol");
            DropTable("dbo.Permisos");
            DropTable("dbo.Clientes");
            DropTable("dbo.InventariosEntradas");
            DropTable("dbo.Precios");
            DropTable("dbo.Categorias");
            DropTable("dbo.Productos");
            DropTable("dbo.Impuestos");
            DropTable("dbo.Preferencias");
            DropTable("dbo.Certificados");
            DropTable("dbo.Sucursales");
            DropTable("dbo.Empresas");
            DropTable("dbo.Facturas");
            DropTable("dbo.Catalogos");
        }
    }
}
