namespace SiscomSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INICIAL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Almacenes",
                c => new
                    {
                        idAlmacen = c.Int(nullable: false, identity: true),
                        sFolio = c.String(unicode: false),
                        sNumFactura = c.String(unicode: false),
                        sMoneda = c.String(unicode: false),
                        sDescripcion = c.String(unicode: false),
                        dTipoCambio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        sTipoCompra = c.String(unicode: false),
                        dtFechaCompra = c.DateTime(nullable: false, precision: 0),
                        dtFechaMovimiento = c.DateTime(nullable: false, precision: 0),
                        bStatus = c.Boolean(nullable: false),
                        cliente_id_idCliente = c.Int(),
                    })
                .PrimaryKey(t => t.idAlmacen)
                .ForeignKey("dbo.Clientes", t => t.cliente_id_idCliente)
                .Index(t => t.cliente_id_idCliente);
            
            CreateTable(
                "dbo.Capa",
                c => new
                    {
                        idCapa = c.Int(nullable: false, identity: true),
                        dtFecha = c.DateTime(nullable: false, precision: 0),
                        dTipoCambio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        iNumeroLote = c.Int(nullable: false),
                        dCantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dCosto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dtFechaCaducidad = c.DateTime(nullable: false, precision: 0),
                        dtFechaFabricacion = c.DateTime(nullable: false, precision: 0),
                        almacen_id_idAlmacen = c.Int(),
                        producto_id_idProducto = c.Int(),
                    })
                .PrimaryKey(t => t.idCapa)
                .ForeignKey("dbo.Almacenes", t => t.almacen_id_idAlmacen)
                .ForeignKey("dbo.Productos", t => t.producto_id_idProducto)
                .Index(t => t.almacen_id_idAlmacen)
                .Index(t => t.producto_id_idProducto);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        idProducto = c.Int(nullable: false, identity: true),
                        iClaveProd = c.Int(nullable: false),
                        sDescripcion = c.String(unicode: false),
                        sMarca = c.String(unicode: false),
                        dCosto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dPreVenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        sFoto = c.String(unicode: false),
                        dtCaducidad = c.DateTime(nullable: false, precision: 0),
                        iLote = c.Int(nullable: false),
                        bStatus = c.Boolean(nullable: false),
                        catalogo_id_idCatalogo = c.Int(),
                        categoria_id_idCategoria = c.Int(),
                        precio_id_idPrecios = c.Int(),
                    })
                .PrimaryKey(t => t.idProducto)
                .ForeignKey("dbo.Catalogos", t => t.catalogo_id_idCatalogo)
                .ForeignKey("dbo.Categorias", t => t.categoria_id_idCategoria)
                .ForeignKey("dbo.Precios", t => t.precio_id_idPrecios)
                .Index(t => t.catalogo_id_idCatalogo)
                .Index(t => t.categoria_id_idCategoria)
                .Index(t => t.precio_id_idPrecios);
            
            CreateTable(
                "dbo.Catalogos",
                c => new
                    {
                        idCatalogo = c.Int(nullable: false, identity: true),
                        sUDM = c.String(unicode: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idCatalogo);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        idCategoria = c.Int(nullable: false, identity: true),
                        sNombre = c.String(unicode: false),
                        sNomSubCat = c.String(unicode: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idCategoria);
            
            CreateTable(
                "dbo.DescuentosProducto",
                c => new
                    {
                        idDescuentoProducto = c.Int(nullable: false, identity: true),
                        bStatus = c.Boolean(nullable: false),
                        descuento_id_idDescuento = c.Int(),
                        producto_id_idProducto = c.Int(),
                    })
                .PrimaryKey(t => t.idDescuentoProducto)
                .ForeignKey("dbo.Descuentos", t => t.descuento_id_idDescuento)
                .ForeignKey("dbo.Productos", t => t.producto_id_idProducto)
                .Index(t => t.descuento_id_idDescuento)
                .Index(t => t.producto_id_idProducto);
            
            CreateTable(
                "dbo.Descuentos",
                c => new
                    {
                        idDescuento = c.Int(nullable: false, identity: true),
                        dTasaDesc = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dTasaDescEx = c.Decimal(nullable: false, precision: 18, scale: 2),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idDescuento);
            
            CreateTable(
                "dbo.DetalleAlmacen",
                c => new
                    {
                        idDetalle = c.Int(nullable: false, identity: true),
                        sDescripcion = c.String(unicode: false),
                        iCantidad = c.Int(nullable: false),
                        dCosto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        bStatus = c.Boolean(nullable: false),
                        almacen_id_idAlmacen = c.Int(),
                        producto_id_idProducto = c.Int(),
                    })
                .PrimaryKey(t => t.idDetalle)
                .ForeignKey("dbo.Almacenes", t => t.almacen_id_idAlmacen)
                .ForeignKey("dbo.Productos", t => t.producto_id_idProducto)
                .Index(t => t.almacen_id_idAlmacen)
                .Index(t => t.producto_id_idProducto);
            
            CreateTable(
                "dbo.DetalleFacturacion",
                c => new
                    {
                        idDetalleFacturacion = c.Int(nullable: false, identity: true),
                        sDescripcion = c.String(unicode: false),
                        sClave = c.String(unicode: false),
                        iCantidad = c.Int(nullable: false),
                        dPreUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        bStatus = c.Boolean(nullable: false),
                        factura_id_idFactura = c.Int(),
                        producto_id_idProducto = c.Int(),
                    })
                .PrimaryKey(t => t.idDetalleFacturacion)
                .ForeignKey("dbo.Facturas", t => t.factura_id_idFactura)
                .ForeignKey("dbo.Productos", t => t.producto_id_idProducto)
                .Index(t => t.factura_id_idFactura)
                .Index(t => t.producto_id_idProducto);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        idFactura = c.Int(nullable: false, identity: true),
                        sTipoCambio = c.String(unicode: false),
                        dtFecha = c.DateTime(nullable: false, precision: 0),
                        sFolio = c.String(unicode: false),
                        sComentario = c.String(unicode: false),
                        bStatus = c.Boolean(nullable: false),
                        cliente_id_idCliente = c.Int(),
                        sucursal_id_idSucursal = c.Int(),
                        usuario_id_idUsuario = c.Int(),
                        Impuesto_idImpuesto = c.Int(),
                    })
                .PrimaryKey(t => t.idFactura)
                .ForeignKey("dbo.Clientes", t => t.cliente_id_idCliente)
                .ForeignKey("dbo.Sucursales", t => t.sucursal_id_idSucursal)
                .ForeignKey("dbo.Usuarios", t => t.usuario_id_idUsuario)
                .ForeignKey("dbo.Impuestos", t => t.Impuesto_idImpuesto)
                .Index(t => t.cliente_id_idCliente)
                .Index(t => t.sucursal_id_idSucursal)
                .Index(t => t.usuario_id_idUsuario)
                .Index(t => t.Impuesto_idImpuesto);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        idCliente = c.Int(nullable: false, identity: true),
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
                .PrimaryKey(t => t.idCliente);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        idVenta = c.Int(nullable: false, identity: true),
                        dtFechaVenta = c.DateTime(nullable: false, precision: 0),
                        dCambio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        sTipoPago = c.String(unicode: false),
                        sMoneda = c.String(unicode: false),
                        bStatus = c.Boolean(nullable: false),
                        iTurno = c.Int(nullable: false),
                        iCaja = c.Int(nullable: false),
                        sFolio = c.String(unicode: false),
                        cliente_id_idCliente = c.Int(),
                        factura_id_idFactura = c.Int(),
                        usuario_id_idUsuario = c.Int(),
                    })
                .PrimaryKey(t => t.idVenta)
                .ForeignKey("dbo.Clientes", t => t.cliente_id_idCliente)
                .ForeignKey("dbo.Facturas", t => t.factura_id_idFactura)
                .ForeignKey("dbo.Usuarios", t => t.usuario_id_idUsuario)
                .Index(t => t.cliente_id_idCliente)
                .Index(t => t.factura_id_idFactura)
                .Index(t => t.usuario_id_idUsuario);
            
            CreateTable(
                "dbo.DetallePeriodos",
                c => new
                    {
                        idDetallePeriodo = c.Int(nullable: false, identity: true),
                        bStatus = c.Boolean(nullable: false),
                        periodo_id_idPeriodo = c.Int(),
                        venta_id_idVenta = c.Int(),
                    })
                .PrimaryKey(t => t.idDetallePeriodo)
                .ForeignKey("dbo.Periodos", t => t.periodo_id_idPeriodo)
                .ForeignKey("dbo.Ventas", t => t.venta_id_idVenta)
                .Index(t => t.periodo_id_idPeriodo)
                .Index(t => t.venta_id_idVenta);
            
            CreateTable(
                "dbo.Periodos",
                c => new
                    {
                        idPeriodo = c.Int(nullable: false, identity: true),
                        dtInicio = c.DateTime(nullable: false, precision: 0),
                        dtFinal = c.DateTime(nullable: false, precision: 0),
                        sFolio = c.String(unicode: false),
                        iTurno = c.Int(nullable: false),
                        sCaja = c.String(unicode: false),
                        dFondo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        bStatus = c.Boolean(nullable: false),
                        usuario_id_idUsuario = c.Int(),
                    })
                .PrimaryKey(t => t.idPeriodo)
                .ForeignKey("dbo.Usuarios", t => t.usuario_id_idUsuario)
                .Index(t => t.usuario_id_idUsuario);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        idUsuario = c.Int(nullable: false, identity: true),
                        sRfc = c.String(unicode: false),
                        sUsuario = c.String(nullable: false, unicode: false),
                        sNombre = c.String(nullable: false, unicode: false),
                        sContrasena = c.String(nullable: false, unicode: false),
                        sPin = c.String(nullable: false, unicode: false),
                        sNumero = c.String(nullable: false, unicode: false),
                        sCorreo = c.String(nullable: false, unicode: false),
                        sComentario = c.String(nullable: false, unicode: false),
                        bStatus = c.Boolean(nullable: false),
                        rol_id_idRol = c.Int(),
                        sucursal_id_idSucursal = c.Int(),
                    })
                .PrimaryKey(t => t.idUsuario)
                .ForeignKey("dbo.Roles", t => t.rol_id_idRol)
                .ForeignKey("dbo.Sucursales", t => t.sucursal_id_idSucursal)
                .Index(t => t.rol_id_idRol)
                .Index(t => t.sucursal_id_idSucursal);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        idRol = c.Int(nullable: false, identity: true),
                        sNombre = c.String(nullable: false, unicode: false),
                        sComentario = c.String(nullable: false, unicode: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idRol);
            
            CreateTable(
                "dbo.PermisosNegadosRol",
                c => new
                    {
                        idPermisoNegadoRol = c.Int(nullable: false, identity: true),
                        bStatus = c.Boolean(nullable: false),
                        permiso_id_idPermiso = c.Int(nullable: false),
                        rol_id_idRol = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idPermisoNegadoRol)
                .ForeignKey("dbo.Permisos", t => t.permiso_id_idPermiso, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.rol_id_idRol, cascadeDelete: true)
                .Index(t => t.permiso_id_idPermiso)
                .Index(t => t.rol_id_idRol);
            
            CreateTable(
                "dbo.Permisos",
                c => new
                    {
                        idPermiso = c.Int(nullable: false, identity: true),
                        sNombre = c.String(nullable: false, unicode: false),
                        sComentario = c.String(nullable: false, unicode: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idPermiso);
            
            CreateTable(
                "dbo.Sucursales",
                c => new
                    {
                        idSucursal = c.Int(nullable: false, identity: true),
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
                        certificado_id_idCertificado = c.Int(),
                        empresa_id_idEmpresa = c.Int(),
                        preferencia_id_idPreferencia = c.Int(),
                    })
                .PrimaryKey(t => t.idSucursal)
                .ForeignKey("dbo.Certificados", t => t.certificado_id_idCertificado)
                .ForeignKey("dbo.Empresas", t => t.empresa_id_idEmpresa)
                .ForeignKey("dbo.Preferencias", t => t.preferencia_id_idPreferencia)
                .Index(t => t.certificado_id_idCertificado)
                .Index(t => t.empresa_id_idEmpresa)
                .Index(t => t.preferencia_id_idPreferencia);
            
            CreateTable(
                "dbo.Certificados",
                c => new
                    {
                        idCertificado = c.Int(nullable: false, identity: true),
                        sArchCer = c.String(unicode: false),
                        sArchkey = c.String(unicode: false),
                        sContrasena = c.String(unicode: false),
                        sNoCertifi = c.String(unicode: false),
                        sValidoDe = c.String(unicode: false),
                        sValidoHasta = c.String(unicode: false),
                        sRutaArch = c.String(unicode: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idCertificado);
            
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        idEmpresa = c.Int(nullable: false, identity: true),
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
                .PrimaryKey(t => t.idEmpresa);
            
            CreateTable(
                "dbo.Preferencias",
                c => new
                    {
                        idPreferencia = c.Int(nullable: false, identity: true),
                        sLogotipo = c.String(unicode: false),
                        bForImpreso = c.Boolean(nullable: false),
                        sNumSerie = c.String(unicode: false),
                        bEnvFactura = c.Boolean(nullable: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idPreferencia);
            
            CreateTable(
                "dbo.DetalleVentas",
                c => new
                    {
                        idDetalleVenta = c.Int(nullable: false, identity: true),
                        sDescripcion = c.String(unicode: false),
                        dCantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dPreUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        bStatus = c.Boolean(nullable: false),
                        producto_id_idProducto = c.Int(),
                        Venta_idVenta = c.Int(),
                    })
                .PrimaryKey(t => t.idDetalleVenta)
                .ForeignKey("dbo.Productos", t => t.producto_id_idProducto)
                .ForeignKey("dbo.Ventas", t => t.Venta_idVenta)
                .Index(t => t.producto_id_idProducto)
                .Index(t => t.Venta_idVenta);
            
            CreateTable(
                "dbo.DetalleInventario",
                c => new
                    {
                        pkDetalleInventario = c.Int(nullable: false, identity: true),
                        dCantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dLastCosto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dPreVenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        producto_id_idProducto = c.Int(),
                        Inventario_idInventario = c.Int(),
                    })
                .PrimaryKey(t => t.pkDetalleInventario)
                .ForeignKey("dbo.Productos", t => t.producto_id_idProducto)
                .ForeignKey("dbo.Inventario", t => t.Inventario_idInventario)
                .Index(t => t.producto_id_idProducto)
                .Index(t => t.Inventario_idInventario);
            
            CreateTable(
                "dbo.Existencias",
                c => new
                    {
                        idExistencia = c.Int(nullable: false, identity: true),
                        dCantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dSalida = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dBaja = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dExistencia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        almacen_id_idAlmacen = c.Int(),
                        producto_id_idProducto = c.Int(),
                    })
                .PrimaryKey(t => t.idExistencia)
                .ForeignKey("dbo.Almacenes", t => t.almacen_id_idAlmacen)
                .ForeignKey("dbo.Productos", t => t.producto_id_idProducto)
                .Index(t => t.almacen_id_idAlmacen)
                .Index(t => t.producto_id_idProducto);
            
            CreateTable(
                "dbo.ImpuestosProducto",
                c => new
                    {
                        idDetalleProducto = c.Int(nullable: false, identity: true),
                        bStatus = c.Boolean(nullable: false),
                        impuesto_id_idImpuesto = c.Int(),
                        producto_id_idProducto = c.Int(),
                    })
                .PrimaryKey(t => t.idDetalleProducto)
                .ForeignKey("dbo.Impuestos", t => t.impuesto_id_idImpuesto)
                .ForeignKey("dbo.Productos", t => t.producto_id_idProducto)
                .Index(t => t.impuesto_id_idImpuesto)
                .Index(t => t.producto_id_idProducto);
            
            CreateTable(
                "dbo.Impuestos",
                c => new
                    {
                        idImpuesto = c.Int(nullable: false, identity: true),
                        sTipoImpuesto = c.String(unicode: false),
                        sImpuesto = c.String(unicode: false),
                        dTasaImpuesto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idImpuesto);
            
            CreateTable(
                "dbo.Precios",
                c => new
                    {
                        idPrecios = c.Int(nullable: false, identity: true),
                        iPrePorcen = c.Int(nullable: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idPrecios);
            
            CreateTable(
                "dbo.Inventario",
                c => new
                    {
                        idInventario = c.Int(nullable: false, identity: true),
                        sFolio = c.String(unicode: false),
                        dtFecha = c.DateTime(nullable: false, precision: 0),
                        sTipoMov = c.String(unicode: false),
                        bStatus = c.Boolean(nullable: false),
                        almacen_id_idAlmacen = c.Int(),
                        usuario_id_idUsuario = c.Int(),
                    })
                .PrimaryKey(t => t.idInventario)
                .ForeignKey("dbo.Almacenes", t => t.almacen_id_idAlmacen)
                .ForeignKey("dbo.Usuarios", t => t.usuario_id_idUsuario)
                .Index(t => t.almacen_id_idAlmacen)
                .Index(t => t.usuario_id_idUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventario", "usuario_id_idUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.DetalleInventario", "Inventario_idInventario", "dbo.Inventario");
            DropForeignKey("dbo.Inventario", "almacen_id_idAlmacen", "dbo.Almacenes");
            DropForeignKey("dbo.Capa", "producto_id_idProducto", "dbo.Productos");
            DropForeignKey("dbo.Productos", "precio_id_idPrecios", "dbo.Precios");
            DropForeignKey("dbo.ImpuestosProducto", "producto_id_idProducto", "dbo.Productos");
            DropForeignKey("dbo.ImpuestosProducto", "impuesto_id_idImpuesto", "dbo.Impuestos");
            DropForeignKey("dbo.Facturas", "Impuesto_idImpuesto", "dbo.Impuestos");
            DropForeignKey("dbo.Existencias", "producto_id_idProducto", "dbo.Productos");
            DropForeignKey("dbo.Existencias", "almacen_id_idAlmacen", "dbo.Almacenes");
            DropForeignKey("dbo.DetalleInventario", "producto_id_idProducto", "dbo.Productos");
            DropForeignKey("dbo.DetalleFacturacion", "producto_id_idProducto", "dbo.Productos");
            DropForeignKey("dbo.Facturas", "usuario_id_idUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.DetalleFacturacion", "factura_id_idFactura", "dbo.Facturas");
            DropForeignKey("dbo.Ventas", "usuario_id_idUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Ventas", "factura_id_idFactura", "dbo.Facturas");
            DropForeignKey("dbo.DetalleVentas", "Venta_idVenta", "dbo.Ventas");
            DropForeignKey("dbo.DetalleVentas", "producto_id_idProducto", "dbo.Productos");
            DropForeignKey("dbo.DetallePeriodos", "venta_id_idVenta", "dbo.Ventas");
            DropForeignKey("dbo.Periodos", "usuario_id_idUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "sucursal_id_idSucursal", "dbo.Sucursales");
            DropForeignKey("dbo.Sucursales", "preferencia_id_idPreferencia", "dbo.Preferencias");
            DropForeignKey("dbo.Facturas", "sucursal_id_idSucursal", "dbo.Sucursales");
            DropForeignKey("dbo.Sucursales", "empresa_id_idEmpresa", "dbo.Empresas");
            DropForeignKey("dbo.Sucursales", "certificado_id_idCertificado", "dbo.Certificados");
            DropForeignKey("dbo.Usuarios", "rol_id_idRol", "dbo.Roles");
            DropForeignKey("dbo.PermisosNegadosRol", "rol_id_idRol", "dbo.Roles");
            DropForeignKey("dbo.PermisosNegadosRol", "permiso_id_idPermiso", "dbo.Permisos");
            DropForeignKey("dbo.DetallePeriodos", "periodo_id_idPeriodo", "dbo.Periodos");
            DropForeignKey("dbo.Ventas", "cliente_id_idCliente", "dbo.Clientes");
            DropForeignKey("dbo.Facturas", "cliente_id_idCliente", "dbo.Clientes");
            DropForeignKey("dbo.Almacenes", "cliente_id_idCliente", "dbo.Clientes");
            DropForeignKey("dbo.DetalleAlmacen", "producto_id_idProducto", "dbo.Productos");
            DropForeignKey("dbo.DetalleAlmacen", "almacen_id_idAlmacen", "dbo.Almacenes");
            DropForeignKey("dbo.DescuentosProducto", "producto_id_idProducto", "dbo.Productos");
            DropForeignKey("dbo.DescuentosProducto", "descuento_id_idDescuento", "dbo.Descuentos");
            DropForeignKey("dbo.Productos", "categoria_id_idCategoria", "dbo.Categorias");
            DropForeignKey("dbo.Productos", "catalogo_id_idCatalogo", "dbo.Catalogos");
            DropForeignKey("dbo.Capa", "almacen_id_idAlmacen", "dbo.Almacenes");
            DropIndex("dbo.Inventario", new[] { "usuario_id_idUsuario" });
            DropIndex("dbo.Inventario", new[] { "almacen_id_idAlmacen" });
            DropIndex("dbo.ImpuestosProducto", new[] { "producto_id_idProducto" });
            DropIndex("dbo.ImpuestosProducto", new[] { "impuesto_id_idImpuesto" });
            DropIndex("dbo.Existencias", new[] { "producto_id_idProducto" });
            DropIndex("dbo.Existencias", new[] { "almacen_id_idAlmacen" });
            DropIndex("dbo.DetalleInventario", new[] { "Inventario_idInventario" });
            DropIndex("dbo.DetalleInventario", new[] { "producto_id_idProducto" });
            DropIndex("dbo.DetalleVentas", new[] { "Venta_idVenta" });
            DropIndex("dbo.DetalleVentas", new[] { "producto_id_idProducto" });
            DropIndex("dbo.Sucursales", new[] { "preferencia_id_idPreferencia" });
            DropIndex("dbo.Sucursales", new[] { "empresa_id_idEmpresa" });
            DropIndex("dbo.Sucursales", new[] { "certificado_id_idCertificado" });
            DropIndex("dbo.PermisosNegadosRol", new[] { "rol_id_idRol" });
            DropIndex("dbo.PermisosNegadosRol", new[] { "permiso_id_idPermiso" });
            DropIndex("dbo.Usuarios", new[] { "sucursal_id_idSucursal" });
            DropIndex("dbo.Usuarios", new[] { "rol_id_idRol" });
            DropIndex("dbo.Periodos", new[] { "usuario_id_idUsuario" });
            DropIndex("dbo.DetallePeriodos", new[] { "venta_id_idVenta" });
            DropIndex("dbo.DetallePeriodos", new[] { "periodo_id_idPeriodo" });
            DropIndex("dbo.Ventas", new[] { "usuario_id_idUsuario" });
            DropIndex("dbo.Ventas", new[] { "factura_id_idFactura" });
            DropIndex("dbo.Ventas", new[] { "cliente_id_idCliente" });
            DropIndex("dbo.Facturas", new[] { "Impuesto_idImpuesto" });
            DropIndex("dbo.Facturas", new[] { "usuario_id_idUsuario" });
            DropIndex("dbo.Facturas", new[] { "sucursal_id_idSucursal" });
            DropIndex("dbo.Facturas", new[] { "cliente_id_idCliente" });
            DropIndex("dbo.DetalleFacturacion", new[] { "producto_id_idProducto" });
            DropIndex("dbo.DetalleFacturacion", new[] { "factura_id_idFactura" });
            DropIndex("dbo.DetalleAlmacen", new[] { "producto_id_idProducto" });
            DropIndex("dbo.DetalleAlmacen", new[] { "almacen_id_idAlmacen" });
            DropIndex("dbo.DescuentosProducto", new[] { "producto_id_idProducto" });
            DropIndex("dbo.DescuentosProducto", new[] { "descuento_id_idDescuento" });
            DropIndex("dbo.Productos", new[] { "precio_id_idPrecios" });
            DropIndex("dbo.Productos", new[] { "categoria_id_idCategoria" });
            DropIndex("dbo.Productos", new[] { "catalogo_id_idCatalogo" });
            DropIndex("dbo.Capa", new[] { "producto_id_idProducto" });
            DropIndex("dbo.Capa", new[] { "almacen_id_idAlmacen" });
            DropIndex("dbo.Almacenes", new[] { "cliente_id_idCliente" });
            DropTable("dbo.Inventario");
            DropTable("dbo.Precios");
            DropTable("dbo.Impuestos");
            DropTable("dbo.ImpuestosProducto");
            DropTable("dbo.Existencias");
            DropTable("dbo.DetalleInventario");
            DropTable("dbo.DetalleVentas");
            DropTable("dbo.Preferencias");
            DropTable("dbo.Empresas");
            DropTable("dbo.Certificados");
            DropTable("dbo.Sucursales");
            DropTable("dbo.Permisos");
            DropTable("dbo.PermisosNegadosRol");
            DropTable("dbo.Roles");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Periodos");
            DropTable("dbo.DetallePeriodos");
            DropTable("dbo.Ventas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Facturas");
            DropTable("dbo.DetalleFacturacion");
            DropTable("dbo.DetalleAlmacen");
            DropTable("dbo.Descuentos");
            DropTable("dbo.DescuentosProducto");
            DropTable("dbo.Categorias");
            DropTable("dbo.Catalogos");
            DropTable("dbo.Productos");
            DropTable("dbo.Capa");
            DropTable("dbo.Almacenes");
        }
    }
}
