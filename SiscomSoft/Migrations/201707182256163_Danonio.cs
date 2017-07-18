namespace SiscomSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Danonio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Almacenes",
                c => new
                    {
                        pkAlmacen = c.Int(nullable: false, identity: true),
                        sFolio = c.String(unicode: false),
                        sNumFactura = c.String(unicode: false),
                        sMoneda = c.String(unicode: false),
                        dTipoCambio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        iTipoCompra = c.Int(nullable: false),
                        dtFechaMovimiento = c.DateTime(nullable: false, precision: 0),
                        bStatus = c.Boolean(nullable: false),
                        fkCliente_pkCliente = c.Int(),
                    })
                .PrimaryKey(t => t.pkAlmacen)
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
                "dbo.Facturas",
                c => new
                    {
                        pkFactura = c.Int(nullable: false, identity: true),
                        sTipoCambio = c.String(unicode: false),
                        dtFecha = c.DateTime(nullable: false, precision: 0),
                        sFolio = c.String(unicode: false),
                        sComentario = c.String(unicode: false),
                        bStatus = c.Boolean(nullable: false),
                        Empresa_pkEmpresa = c.Int(),
                        Catalogo_pkCatalogo = c.Int(),
                        Impuesto_pkImpuesto = c.Int(),
                        fkCliente_pkCliente = c.Int(),
                        fkSucursal_pkSucursal = c.Int(),
                        fkUsuario_pkUsuario = c.Int(),
                    })
                .PrimaryKey(t => t.pkFactura)
                .ForeignKey("dbo.Empresas", t => t.Empresa_pkEmpresa)
                .ForeignKey("dbo.Catalogos", t => t.Catalogo_pkCatalogo)
                .ForeignKey("dbo.Impuestos", t => t.Impuesto_pkImpuesto)
                .ForeignKey("dbo.Clientes", t => t.fkCliente_pkCliente)
                .ForeignKey("dbo.Sucursales", t => t.fkSucursal_pkSucursal)
                .ForeignKey("dbo.Usuarios", t => t.fkUsuario_pkUsuario)
                .Index(t => t.Empresa_pkEmpresa)
                .Index(t => t.Catalogo_pkCatalogo)
                .Index(t => t.Impuesto_pkImpuesto)
                .Index(t => t.fkCliente_pkCliente)
                .Index(t => t.fkSucursal_pkSucursal)
                .Index(t => t.fkUsuario_pkUsuario);
            
            CreateTable(
                "dbo.DetalleFacturacion",
                c => new
                    {
                        pkDetalleFacturacion = c.Int(nullable: false, identity: true),
                        sDescripcion = c.String(unicode: false),
                        sClave = c.String(unicode: false),
                        iCantidad = c.Int(nullable: false),
                        dPreUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        bStatus = c.Boolean(nullable: false),
                        fkFactura_pkFactura = c.Int(),
                        fkProducto_pkProducto = c.Int(),
                    })
                .PrimaryKey(t => t.pkDetalleFacturacion)
                .ForeignKey("dbo.Facturas", t => t.fkFactura_pkFactura)
                .ForeignKey("dbo.Productos", t => t.fkProducto_pkProducto)
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
                        dPreVenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        sFoto = c.String(unicode: false),
                        dtCaducidad = c.DateTime(nullable: false, precision: 0),
                        iLote = c.Int(nullable: false),
                        bStatus = c.Boolean(nullable: false),
                        fkCatalogo_pkCatalogo = c.Int(),
                        fkCategoria_pkCategoria = c.Int(),
                        fkPrecio_pkPrecios = c.Int(),
                    })
                .PrimaryKey(t => t.pkProducto)
                .ForeignKey("dbo.Catalogos", t => t.fkCatalogo_pkCatalogo)
                .ForeignKey("dbo.Categorias", t => t.fkCategoria_pkCategoria)
                .ForeignKey("dbo.Precios", t => t.fkPrecio_pkPrecios)
                .Index(t => t.fkCatalogo_pkCatalogo)
                .Index(t => t.fkCategoria_pkCategoria)
                .Index(t => t.fkPrecio_pkPrecios);
            
            CreateTable(
                "dbo.DescuentosProducto",
                c => new
                    {
                        pkDescuentoProducto = c.Int(nullable: false, identity: true),
                        bStatus = c.Boolean(nullable: false),
                        fkDescuento_pkDescuento = c.Int(),
                        fkProducto_pkProducto = c.Int(),
                    })
                .PrimaryKey(t => t.pkDescuentoProducto)
                .ForeignKey("dbo.Descuentos", t => t.fkDescuento_pkDescuento)
                .ForeignKey("dbo.Productos", t => t.fkProducto_pkProducto)
                .Index(t => t.fkDescuento_pkDescuento)
                .Index(t => t.fkProducto_pkProducto);
            
            CreateTable(
                "dbo.Descuentos",
                c => new
                    {
                        pkDescuento = c.Int(nullable: false, identity: true),
                        dTasaDesc = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dTasaDescEx = c.Decimal(nullable: false, precision: 18, scale: 2),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkDescuento);
            
            CreateTable(
                "dbo.DetalleVentas",
                c => new
                    {
                        pkDetalleVenta = c.Int(nullable: false, identity: true),
                        sDescripcion = c.String(unicode: false),
                        iCantidad = c.Int(nullable: false),
                        dPreUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        bStatus = c.Boolean(nullable: false),
                        fkProducto_pkProducto = c.Int(),
                        fkVenta_pkVenta = c.Int(),
                    })
                .PrimaryKey(t => t.pkDetalleVenta)
                .ForeignKey("dbo.Productos", t => t.fkProducto_pkProducto)
                .ForeignKey("dbo.Ventas", t => t.fkVenta_pkVenta)
                .Index(t => t.fkProducto_pkProducto)
                .Index(t => t.fkVenta_pkVenta);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        pkVenta = c.Int(nullable: false, identity: true),
                        dtFechaVenta = c.DateTime(nullable: false, precision: 0),
                        dCambio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        sTipoPago = c.String(unicode: false),
                        sMoneda = c.String(unicode: false),
                        bStatus = c.Boolean(nullable: false),
                        iTurno = c.Int(nullable: false),
                        iCaja = c.Int(nullable: false),
                        fkCliente_pkCliente = c.Int(),
                        fkFactura_pkFactura = c.Int(),
                        fkUsuario_pkUsuario = c.Int(),
                    })
                .PrimaryKey(t => t.pkVenta)
                .ForeignKey("dbo.Clientes", t => t.fkCliente_pkCliente)
                .ForeignKey("dbo.Facturas", t => t.fkFactura_pkFactura)
                .ForeignKey("dbo.Usuarios", t => t.fkUsuario_pkUsuario)
                .Index(t => t.fkCliente_pkCliente)
                .Index(t => t.fkFactura_pkFactura)
                .Index(t => t.fkUsuario_pkUsuario);
            
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
                        fkSucursal_pkSucursal = c.Int(),
                    })
                .PrimaryKey(t => t.pkUsuario)
                .ForeignKey("dbo.Roles", t => t.fkRol_pkRol)
                .ForeignKey("dbo.Sucursales", t => t.fkSucursal_pkSucursal)
                .Index(t => t.fkRol_pkRol)
                .Index(t => t.fkSucursal_pkSucursal);
            
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
                "dbo.Catalogos",
                c => new
                    {
                        pkCatalogo = c.Int(nullable: false, identity: true),
                        sUDM = c.String(unicode: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkCatalogo);
            
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
                "dbo.DetalleAlmacen",
                c => new
                    {
                        pkDetalle = c.Int(nullable: false, identity: true),
                        sDescripcion = c.String(unicode: false),
                        iCantidad = c.Int(nullable: false),
                        dCosto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        bStatus = c.Boolean(nullable: false),
                        fkAlmacen_pkAlmacen = c.Int(),
                        fkProducto_pkProducto = c.Int(),
                        Precio_pkPrecios = c.Int(),
                        Impuesto_pkImpuesto = c.Int(),
                    })
                .PrimaryKey(t => t.pkDetalle)
                .ForeignKey("dbo.Almacenes", t => t.fkAlmacen_pkAlmacen)
                .ForeignKey("dbo.Productos", t => t.fkProducto_pkProducto)
                .ForeignKey("dbo.Precios", t => t.Precio_pkPrecios)
                .ForeignKey("dbo.Impuestos", t => t.Impuesto_pkImpuesto)
                .Index(t => t.fkAlmacen_pkAlmacen)
                .Index(t => t.fkProducto_pkProducto)
                .Index(t => t.Precio_pkPrecios)
                .Index(t => t.Impuesto_pkImpuesto);
            
            CreateTable(
                "dbo.ImpuestosProducto",
                c => new
                    {
                        pkDetalleProducto = c.Int(nullable: false, identity: true),
                        bStatus = c.Boolean(nullable: false),
                        fkImpuesto_pkImpuesto = c.Int(),
                        fkProducto_pkProducto = c.Int(),
                    })
                .PrimaryKey(t => t.pkDetalleProducto)
                .ForeignKey("dbo.Impuestos", t => t.fkImpuesto_pkImpuesto)
                .ForeignKey("dbo.Productos", t => t.fkProducto_pkProducto)
                .Index(t => t.fkImpuesto_pkImpuesto)
                .Index(t => t.fkProducto_pkProducto);
            
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
                "dbo.Inventario",
                c => new
                    {
                        pkInventario = c.Int(nullable: false, identity: true),
                        sFolio = c.String(unicode: false),
                        dtFecha = c.DateTime(nullable: false, precision: 0),
                        sTipoMov = c.String(unicode: false),
                        iExistencia = c.Int(nullable: false),
                        dLastCosto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dPreVenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        fkProducto_pkProducto = c.Int(),
                        fkUsuario_pkUsuario = c.Int(),
                    })
                .PrimaryKey(t => t.pkInventario)
                .ForeignKey("dbo.Productos", t => t.fkProducto_pkProducto)
                .ForeignKey("dbo.Usuarios", t => t.fkUsuario_pkUsuario)
                .Index(t => t.fkProducto_pkProducto)
                .Index(t => t.fkUsuario_pkUsuario);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InventariosEntradas", "fkProducto_pkProducto", "dbo.Productos");
            DropForeignKey("dbo.InventariosEntradas", "fkFactura_pkFactura", "dbo.Facturas");
            DropForeignKey("dbo.InventariosEntradas", "fkCliente_pkCliente", "dbo.Clientes");
            DropForeignKey("dbo.Facturas", "fkUsuario_pkUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Facturas", "fkSucursal_pkSucursal", "dbo.Sucursales");
            DropForeignKey("dbo.Facturas", "fkCliente_pkCliente", "dbo.Clientes");
            DropForeignKey("dbo.DetalleFacturacion", "fkProducto_pkProducto", "dbo.Productos");
            DropForeignKey("dbo.Inventario", "fkUsuario_pkUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Inventario", "fkProducto_pkProducto", "dbo.Productos");
            DropForeignKey("dbo.ImpuestosProducto", "fkProducto_pkProducto", "dbo.Productos");
            DropForeignKey("dbo.ImpuestosProducto", "fkImpuesto_pkImpuesto", "dbo.Impuestos");
            DropForeignKey("dbo.Facturas", "Impuesto_pkImpuesto", "dbo.Impuestos");
            DropForeignKey("dbo.DetalleAlmacen", "Impuesto_pkImpuesto", "dbo.Impuestos");
            DropForeignKey("dbo.Productos", "fkPrecio_pkPrecios", "dbo.Precios");
            DropForeignKey("dbo.DetalleAlmacen", "Precio_pkPrecios", "dbo.Precios");
            DropForeignKey("dbo.DetalleAlmacen", "fkProducto_pkProducto", "dbo.Productos");
            DropForeignKey("dbo.DetalleAlmacen", "fkAlmacen_pkAlmacen", "dbo.Almacenes");
            DropForeignKey("dbo.Productos", "fkCategoria_pkCategoria", "dbo.Categorias");
            DropForeignKey("dbo.Productos", "fkCatalogo_pkCatalogo", "dbo.Catalogos");
            DropForeignKey("dbo.Facturas", "Catalogo_pkCatalogo", "dbo.Catalogos");
            DropForeignKey("dbo.Ventas", "fkUsuario_pkUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "fkSucursal_pkSucursal", "dbo.Sucursales");
            DropForeignKey("dbo.Sucursales", "fkPreferencia_pkPreferencia", "dbo.Preferencias");
            DropForeignKey("dbo.Sucursales", "fkEmpresa_pkEmpresa", "dbo.Empresas");
            DropForeignKey("dbo.Facturas", "Empresa_pkEmpresa", "dbo.Empresas");
            DropForeignKey("dbo.Sucursales", "fkCertificado_pkCertificado", "dbo.Certificados");
            DropForeignKey("dbo.Usuarios", "fkRol_pkRol", "dbo.Roles");
            DropForeignKey("dbo.PermisosNegadosRol", "fkRol_pkRol", "dbo.Roles");
            DropForeignKey("dbo.PermisosNegadosRol", "fkPermiso_pkPermiso", "dbo.Permisos");
            DropForeignKey("dbo.Ventas", "fkFactura_pkFactura", "dbo.Facturas");
            DropForeignKey("dbo.Ventas", "fkCliente_pkCliente", "dbo.Clientes");
            DropForeignKey("dbo.DetalleVentas", "fkVenta_pkVenta", "dbo.Ventas");
            DropForeignKey("dbo.DetalleVentas", "fkProducto_pkProducto", "dbo.Productos");
            DropForeignKey("dbo.DescuentosProducto", "fkProducto_pkProducto", "dbo.Productos");
            DropForeignKey("dbo.DescuentosProducto", "fkDescuento_pkDescuento", "dbo.Descuentos");
            DropForeignKey("dbo.DetalleFacturacion", "fkFactura_pkFactura", "dbo.Facturas");
            DropForeignKey("dbo.Almacenes", "fkCliente_pkCliente", "dbo.Clientes");
            DropIndex("dbo.InventariosEntradas", new[] { "fkProducto_pkProducto" });
            DropIndex("dbo.InventariosEntradas", new[] { "fkFactura_pkFactura" });
            DropIndex("dbo.InventariosEntradas", new[] { "fkCliente_pkCliente" });
            DropIndex("dbo.Inventario", new[] { "fkUsuario_pkUsuario" });
            DropIndex("dbo.Inventario", new[] { "fkProducto_pkProducto" });
            DropIndex("dbo.ImpuestosProducto", new[] { "fkProducto_pkProducto" });
            DropIndex("dbo.ImpuestosProducto", new[] { "fkImpuesto_pkImpuesto" });
            DropIndex("dbo.DetalleAlmacen", new[] { "Impuesto_pkImpuesto" });
            DropIndex("dbo.DetalleAlmacen", new[] { "Precio_pkPrecios" });
            DropIndex("dbo.DetalleAlmacen", new[] { "fkProducto_pkProducto" });
            DropIndex("dbo.DetalleAlmacen", new[] { "fkAlmacen_pkAlmacen" });
            DropIndex("dbo.Sucursales", new[] { "fkPreferencia_pkPreferencia" });
            DropIndex("dbo.Sucursales", new[] { "fkEmpresa_pkEmpresa" });
            DropIndex("dbo.Sucursales", new[] { "fkCertificado_pkCertificado" });
            DropIndex("dbo.PermisosNegadosRol", new[] { "fkRol_pkRol" });
            DropIndex("dbo.PermisosNegadosRol", new[] { "fkPermiso_pkPermiso" });
            DropIndex("dbo.Usuarios", new[] { "fkSucursal_pkSucursal" });
            DropIndex("dbo.Usuarios", new[] { "fkRol_pkRol" });
            DropIndex("dbo.Ventas", new[] { "fkUsuario_pkUsuario" });
            DropIndex("dbo.Ventas", new[] { "fkFactura_pkFactura" });
            DropIndex("dbo.Ventas", new[] { "fkCliente_pkCliente" });
            DropIndex("dbo.DetalleVentas", new[] { "fkVenta_pkVenta" });
            DropIndex("dbo.DetalleVentas", new[] { "fkProducto_pkProducto" });
            DropIndex("dbo.DescuentosProducto", new[] { "fkProducto_pkProducto" });
            DropIndex("dbo.DescuentosProducto", new[] { "fkDescuento_pkDescuento" });
            DropIndex("dbo.Productos", new[] { "fkPrecio_pkPrecios" });
            DropIndex("dbo.Productos", new[] { "fkCategoria_pkCategoria" });
            DropIndex("dbo.Productos", new[] { "fkCatalogo_pkCatalogo" });
            DropIndex("dbo.DetalleFacturacion", new[] { "fkProducto_pkProducto" });
            DropIndex("dbo.DetalleFacturacion", new[] { "fkFactura_pkFactura" });
            DropIndex("dbo.Facturas", new[] { "fkUsuario_pkUsuario" });
            DropIndex("dbo.Facturas", new[] { "fkSucursal_pkSucursal" });
            DropIndex("dbo.Facturas", new[] { "fkCliente_pkCliente" });
            DropIndex("dbo.Facturas", new[] { "Impuesto_pkImpuesto" });
            DropIndex("dbo.Facturas", new[] { "Catalogo_pkCatalogo" });
            DropIndex("dbo.Facturas", new[] { "Empresa_pkEmpresa" });
            DropIndex("dbo.Almacenes", new[] { "fkCliente_pkCliente" });
            DropTable("dbo.InventariosEntradas");
            DropTable("dbo.Inventario");
            DropTable("dbo.Impuestos");
            DropTable("dbo.ImpuestosProducto");
            DropTable("dbo.DetalleAlmacen");
            DropTable("dbo.Precios");
            DropTable("dbo.Categorias");
            DropTable("dbo.Catalogos");
            DropTable("dbo.Preferencias");
            DropTable("dbo.Empresas");
            DropTable("dbo.Certificados");
            DropTable("dbo.Sucursales");
            DropTable("dbo.Permisos");
            DropTable("dbo.PermisosNegadosRol");
            DropTable("dbo.Roles");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Ventas");
            DropTable("dbo.DetalleVentas");
            DropTable("dbo.Descuentos");
            DropTable("dbo.DescuentosProducto");
            DropTable("dbo.Productos");
            DropTable("dbo.DetalleFacturacion");
            DropTable("dbo.Facturas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Almacenes");
        }
    }
}
