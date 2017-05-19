namespace SiscomSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INICIAL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CatalogosSAT",
                c => new
                    {
                        pkCatalogoSAT = c.Int(nullable: false, identity: true),
                        sUnidMed = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.pkCatalogoSAT);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        pkProducto = c.Int(nullable: false, identity: true),
                        iClaveProd = c.Int(nullable: false),
                        sDescripcion = c.String(unicode: false),
                        sMarca = c.String(unicode: false),
                        dPrecio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dCosto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        iDescuento = c.Int(nullable: false),
                        sFoto = c.String(unicode: false),
                        dtCaducidad = c.DateTime(nullable: false, precision: 0),
                        iLote = c.Int(nullable: false),
                        bStatus = c.Boolean(nullable: false),
                        fkCatalogoSAT_pkCatalogoSAT = c.Int(),
                        fkCategoria_pkCategoria = c.Int(),
                        fkImpuesto_pkImpuesto = c.Int(),
                        fkInventarioEntrada_pkInventioEntrada = c.Int(),
                        fkPrecio_pkPrecios = c.Int(),
                    })
                .PrimaryKey(t => t.pkProducto)
                .ForeignKey("dbo.CatalogosSAT", t => t.fkCatalogoSAT_pkCatalogoSAT)
                .ForeignKey("dbo.Categorias", t => t.fkCategoria_pkCategoria)
                .ForeignKey("dbo.Impuestos", t => t.fkImpuesto_pkImpuesto)
                .ForeignKey("dbo.InventariosEntradas", t => t.fkInventarioEntrada_pkInventioEntrada)
                .ForeignKey("dbo.Precios", t => t.fkPrecio_pkPrecios)
                .Index(t => t.fkCatalogoSAT_pkCatalogoSAT)
                .Index(t => t.fkCategoria_pkCategoria)
                .Index(t => t.fkImpuesto_pkImpuesto)
                .Index(t => t.fkInventarioEntrada_pkInventioEntrada)
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
                "dbo.Impuestos",
                c => new
                    {
                        pkImpuesto = c.Int(nullable: false, identity: true),
                        sTipoImpuesto = c.String(unicode: false),
                        sImpuesto = c.String(unicode: false),
                        dTasaImpuesto = c.Double(nullable: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkImpuesto);
            
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
                        fkCliente_pkCliente = c.Int(),
                    })
                .PrimaryKey(t => t.pkInventioEntrada)
                .ForeignKey("dbo.Clientes", t => t.fkCliente_pkCliente)
                .Index(t => t.fkCliente_pkCliente);
            
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
                        sEstCliente = c.String(unicode: false),
                        sReferencia = c.String(unicode: false),
                        sTipoPAgo = c.String(unicode: false),
                        sNumCuenta = c.String(unicode: false),
                        sCondPAgo = c.String(unicode: false),
                        sTipoCliente = c.String(unicode: false),
                        sLogo = c.String(unicode: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkCliente);
            
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
                "dbo.Certificados",
                c => new
                    {
                        pkCertificado = c.Int(nullable: false, identity: true),
                        sCSD = c.String(nullable: false, unicode: false),
                        sCertificado = c.String(nullable: false, unicode: false),
                        sLLave = c.String(nullable: false, unicode: false),
                        sContraseña = c.String(nullable: false, unicode: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkCertificado);
            
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        pkEmpresa = c.Int(nullable: false, identity: true),
                        sRazonSocial = c.String(nullable: false, unicode: false),
                        sNomComercial = c.String(nullable: false, unicode: false),
                        sNomContacto = c.String(nullable: false, unicode: false),
                        sRegComercial = c.String(nullable: false, unicode: false),
                        sTelefono = c.String(nullable: false, unicode: false),
                        sCorreo = c.String(nullable: false, unicode: false),
                        sPais = c.String(nullable: false, unicode: false),
                        sEstado = c.String(nullable: false, unicode: false),
                        sMunicipio = c.String(nullable: false, unicode: false),
                        sColonia = c.String(nullable: false, unicode: false),
                        sLocalidad = c.String(unicode: false),
                        sCalle = c.String(nullable: false, unicode: false),
                        iNumExterior = c.Int(nullable: false),
                        iNumInterir = c.Int(nullable: false),
                        iCodPostal = c.Int(nullable: false),
                        bStatus = c.Boolean(nullable: false),
                        fkCertificado_pkCertificado = c.Int(),
                        fkSucursal_pkSucursal = c.Int(),
                    })
                .PrimaryKey(t => t.pkEmpresa)
                .ForeignKey("dbo.Certificados", t => t.fkCertificado_pkCertificado)
                .ForeignKey("dbo.Sucursales", t => t.fkSucursal_pkSucursal)
                .Index(t => t.fkCertificado_pkCertificado)
                .Index(t => t.fkSucursal_pkSucursal);
            
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
            
            CreateTable(
                "dbo.Sucursales",
                c => new
                    {
                        pkSucursal = c.Int(nullable: false, identity: true),
                        sNombre = c.String(unicode: false),
                        sEstSucursal = c.String(unicode: false),
                        iNumCertificado = c.Int(nullable: false),
                        sPais = c.String(unicode: false),
                        sEstado = c.String(unicode: false),
                        sMunicipio = c.String(unicode: false),
                        sColonia = c.String(unicode: false),
                        sLocalidad = c.String(unicode: false),
                        sCalle = c.String(unicode: false),
                        iNumExterior = c.Int(nullable: false),
                        iNumInterior = c.Int(nullable: false),
                        iCodPostal = c.Int(nullable: false),
                        bStatus = c.Boolean(nullable: false),
                        fkPreferencia_pkPreferencia = c.Int(),
                    })
                .PrimaryKey(t => t.pkSucursal)
                .ForeignKey("dbo.Preferencias", t => t.fkPreferencia_pkPreferencia)
                .Index(t => t.fkPreferencia_pkPreferencia);
            
            CreateTable(
                "dbo.Preferencias",
                c => new
                    {
                        pkPreferencia = c.Int(nullable: false, identity: true),
                        sLogotipo = c.String(unicode: false),
                        sForImpreso = c.String(unicode: false),
                        sNumSerie = c.String(unicode: false),
                        sEnvFactura = c.String(unicode: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkPreferencia);
            
            CreateTable(
                "dbo.Permisos",
                c => new
                    {
                        pkPermiso = c.Int(nullable: false, identity: true),
                        sModulo = c.String(nullable: false, unicode: false),
                        sComentario = c.String(unicode: false),
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
                        sComentario = c.String(unicode: false),
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
            DropForeignKey("dbo.Sucursales", "fkPreferencia_pkPreferencia", "dbo.Preferencias");
            DropForeignKey("dbo.Empresas", "fkSucursal_pkSucursal", "dbo.Sucursales");
            DropForeignKey("dbo.Empresas", "fkCertificado_pkCertificado", "dbo.Certificados");
            DropForeignKey("dbo.Facturas", "fkEmpresa_pkEmpresa", "dbo.Empresas");
            DropForeignKey("dbo.Productos", "fkPrecio_pkPrecios", "dbo.Precios");
            DropForeignKey("dbo.Productos", "fkInventarioEntrada_pkInventioEntrada", "dbo.InventariosEntradas");
            DropForeignKey("dbo.InventariosEntradas", "fkCliente_pkCliente", "dbo.Clientes");
            DropForeignKey("dbo.Productos", "fkImpuesto_pkImpuesto", "dbo.Impuestos");
            DropForeignKey("dbo.Productos", "fkCategoria_pkCategoria", "dbo.Categorias");
            DropForeignKey("dbo.Productos", "fkCatalogoSAT_pkCatalogoSAT", "dbo.CatalogosSAT");
            DropIndex("dbo.Usuarios", new[] { "fkRol_pkRol" });
            DropIndex("dbo.PermisosNegadosRol", new[] { "fkRol_pkRol" });
            DropIndex("dbo.PermisosNegadosRol", new[] { "fkPermiso_pkPermiso" });
            DropIndex("dbo.Sucursales", new[] { "fkPreferencia_pkPreferencia" });
            DropIndex("dbo.Facturas", new[] { "fkEmpresa_pkEmpresa" });
            DropIndex("dbo.Empresas", new[] { "fkSucursal_pkSucursal" });
            DropIndex("dbo.Empresas", new[] { "fkCertificado_pkCertificado" });
            DropIndex("dbo.InventariosEntradas", new[] { "fkCliente_pkCliente" });
            DropIndex("dbo.Productos", new[] { "fkPrecio_pkPrecios" });
            DropIndex("dbo.Productos", new[] { "fkInventarioEntrada_pkInventioEntrada" });
            DropIndex("dbo.Productos", new[] { "fkImpuesto_pkImpuesto" });
            DropIndex("dbo.Productos", new[] { "fkCategoria_pkCategoria" });
            DropIndex("dbo.Productos", new[] { "fkCatalogoSAT_pkCatalogoSAT" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Roles");
            DropTable("dbo.PermisosNegadosRol");
            DropTable("dbo.Permisos");
            DropTable("dbo.Preferencias");
            DropTable("dbo.Sucursales");
            DropTable("dbo.Facturas");
            DropTable("dbo.Empresas");
            DropTable("dbo.Certificados");
            DropTable("dbo.Precios");
            DropTable("dbo.Clientes");
            DropTable("dbo.InventariosEntradas");
            DropTable("dbo.Impuestos");
            DropTable("dbo.Categorias");
            DropTable("dbo.Productos");
            DropTable("dbo.CatalogosSAT");
        }
    }
}
