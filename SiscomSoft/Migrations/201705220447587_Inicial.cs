namespace SiscomSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
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
                        sNombre = c.String(unicode: false),
                        sDireccion = c.String(unicode: false),
                        sRFC = c.String(unicode: false),
                        sTelefono = c.String(unicode: false),
                        dtFecha = c.DateTime(nullable: false, precision: 0),
                        iCaja = c.Int(nullable: false),
                        sFolio = c.String(unicode: false),
                        sTurno = c.String(unicode: false),
                        sNomUsuario = c.String(unicode: false),
                        sRegion = c.String(unicode: false),
                        iCodigo = c.Int(nullable: false),
                        iCantidad = c.Int(nullable: false),
                        dCostoPro = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dPreVta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dImporte = c.Decimal(nullable: false, precision: 18, scale: 2),
                        iDescuento = c.Int(nullable: false),
                        iArticulo = c.Int(nullable: false),
                        bStatus = c.Boolean(nullable: false),
                        fkCatalogo_pkCatalogo = c.Int(),
                        fkCliente_pkCliente = c.Int(),
                        fkImpuestos_pkImpuesto = c.Int(),
                        fkEmpresa_pkEmpresa = c.Int(),
                        fkUsuario_pkUsuario = c.Int(),
                    })
                .PrimaryKey(t => t.pkFactura)
                .ForeignKey("dbo.Catalogos", t => t.fkCatalogo_pkCatalogo)
                .ForeignKey("dbo.Clientes", t => t.fkCliente_pkCliente)
                .ForeignKey("dbo.Impuestos", t => t.fkImpuestos_pkImpuesto)
                .ForeignKey("dbo.Empresas", t => t.fkEmpresa_pkEmpresa)
                .ForeignKey("dbo.Usuarios", t => t.fkUsuario_pkUsuario)
                .Index(t => t.fkCatalogo_pkCatalogo)
                .Index(t => t.fkCliente_pkCliente)
                .Index(t => t.fkImpuestos_pkImpuesto)
                .Index(t => t.fkEmpresa_pkEmpresa)
                .Index(t => t.fkUsuario_pkUsuario);
            
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
                "dbo.InventariosEntradas",
                c => new
                    {
                        pkInventioEntrada = c.Int(nullable: false, identity: true),
                        dtFecha = c.DateTime(nullable: false, precision: 0),
                        sTipoPago = c.String(unicode: false),
                        sMoneda = c.String(unicode: false),
                        iCantidad = c.Int(nullable: false),
                        sNomProducto = c.String(unicode: false),
                        dPrecio = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                "dbo.Precios",
                c => new
                    {
                        pkPrecios = c.Int(nullable: false, identity: true),
                        iPrePorcen = c.Int(nullable: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkPrecios);
            
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
                        fkCertificado_pkCertificado = c.Int(),
                        fkSucursal_pkSucursal = c.Int(),
                    })
                .PrimaryKey(t => t.pkEmpresa)
                .ForeignKey("dbo.Certificados", t => t.fkCertificado_pkCertificado)
                .ForeignKey("dbo.Sucursales", t => t.fkSucursal_pkSucursal)
                .Index(t => t.fkCertificado_pkCertificado)
                .Index(t => t.fkSucursal_pkSucursal);
            
            CreateTable(
                "dbo.Certificados",
                c => new
                    {
                        pkCertificado = c.Int(nullable: false, identity: true),
                        sCSD = c.String(unicode: false),
                        sCertificado = c.String(unicode: false),
                        sKey = c.String(unicode: false),
                        sContraseña = c.String(unicode: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkCertificado);
            
            CreateTable(
                "dbo.Sucursales",
                c => new
                    {
                        pkSucursal = c.Int(nullable: false, identity: true),
                        sNombre = c.String(unicode: false),
                        iStatus = c.Int(nullable: false),
                        iNumCertifi = c.Int(nullable: false),
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
                "dbo.Permisos",
                c => new
                    {
                        pkPermiso = c.Int(nullable: false, identity: true),
                        sNombre = c.String(nullable: false, unicode: false),
                        sComentario = c.String(nullable: false, unicode: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkPermiso);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "fkRol_pkRol", "dbo.Roles");
            DropForeignKey("dbo.PermisosNegadosRol", "fkRol_pkRol", "dbo.Roles");
            DropForeignKey("dbo.PermisosNegadosRol", "fkPermiso_pkPermiso", "dbo.Permisos");
            DropForeignKey("dbo.Facturas", "fkUsuario_pkUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Sucursales", "fkPreferencia_pkPreferencia", "dbo.Preferencias");
            DropForeignKey("dbo.Empresas", "fkSucursal_pkSucursal", "dbo.Sucursales");
            DropForeignKey("dbo.Empresas", "fkCertificado_pkCertificado", "dbo.Certificados");
            DropForeignKey("dbo.Facturas", "fkEmpresa_pkEmpresa", "dbo.Empresas");
            DropForeignKey("dbo.InventariosEntradas", "fkProducto_pkProducto", "dbo.Productos");
            DropForeignKey("dbo.Productos", "fkPrecio_pkPrecios", "dbo.Precios");
            DropForeignKey("dbo.Productos", "fkImpuesto_pkImpuesto", "dbo.Impuestos");
            DropForeignKey("dbo.Facturas", "fkImpuestos_pkImpuesto", "dbo.Impuestos");
            DropForeignKey("dbo.Productos", "fkCategoria_pkCategoria", "dbo.Categorias");
            DropForeignKey("dbo.Productos", "fkCatalogo_pkCatalogo", "dbo.Catalogos");
            DropForeignKey("dbo.InventariosEntradas", "fkFactura_pkFactura", "dbo.Facturas");
            DropForeignKey("dbo.InventariosEntradas", "fkCliente_pkCliente", "dbo.Clientes");
            DropForeignKey("dbo.Facturas", "fkCliente_pkCliente", "dbo.Clientes");
            DropForeignKey("dbo.Facturas", "fkCatalogo_pkCatalogo", "dbo.Catalogos");
            DropIndex("dbo.PermisosNegadosRol", new[] { "fkRol_pkRol" });
            DropIndex("dbo.PermisosNegadosRol", new[] { "fkPermiso_pkPermiso" });
            DropIndex("dbo.Usuarios", new[] { "fkRol_pkRol" });
            DropIndex("dbo.Sucursales", new[] { "fkPreferencia_pkPreferencia" });
            DropIndex("dbo.Empresas", new[] { "fkSucursal_pkSucursal" });
            DropIndex("dbo.Empresas", new[] { "fkCertificado_pkCertificado" });
            DropIndex("dbo.Productos", new[] { "fkPrecio_pkPrecios" });
            DropIndex("dbo.Productos", new[] { "fkImpuesto_pkImpuesto" });
            DropIndex("dbo.Productos", new[] { "fkCategoria_pkCategoria" });
            DropIndex("dbo.Productos", new[] { "fkCatalogo_pkCatalogo" });
            DropIndex("dbo.InventariosEntradas", new[] { "fkProducto_pkProducto" });
            DropIndex("dbo.InventariosEntradas", new[] { "fkFactura_pkFactura" });
            DropIndex("dbo.InventariosEntradas", new[] { "fkCliente_pkCliente" });
            DropIndex("dbo.Facturas", new[] { "fkUsuario_pkUsuario" });
            DropIndex("dbo.Facturas", new[] { "fkEmpresa_pkEmpresa" });
            DropIndex("dbo.Facturas", new[] { "fkImpuestos_pkImpuesto" });
            DropIndex("dbo.Facturas", new[] { "fkCliente_pkCliente" });
            DropIndex("dbo.Facturas", new[] { "fkCatalogo_pkCatalogo" });
            DropTable("dbo.Permisos");
            DropTable("dbo.PermisosNegadosRol");
            DropTable("dbo.Roles");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Preferencias");
            DropTable("dbo.Sucursales");
            DropTable("dbo.Certificados");
            DropTable("dbo.Empresas");
            DropTable("dbo.Precios");
            DropTable("dbo.Impuestos");
            DropTable("dbo.Categorias");
            DropTable("dbo.Productos");
            DropTable("dbo.InventariosEntradas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Facturas");
            DropTable("dbo.Catalogos");
        }
    }
}
