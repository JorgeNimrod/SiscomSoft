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
                        cliente_id = c.Int(nullable: false),
                        sNumFactura = c.String(unicode: false),
                        sMoneda = c.String(unicode: false),
                        sDescripcion = c.String(unicode: false),
                        dTipoCambio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        sTipoCompra = c.String(unicode: false),
                        dtFechaCompra = c.DateTime(nullable: false, precision: 0),
                        dtFechaMovimiento = c.DateTime(nullable: false, precision: 0),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idAlmacen);
            
            CreateTable(
                "dbo.Capas",
                c => new
                    {
                        idCapa = c.Int(nullable: false, identity: true),
                        almacen_id = c.Int(nullable: false),
                        producto_id = c.Int(nullable: false),
                        dtFecha = c.DateTime(nullable: false, precision: 0),
                        dTipoCambio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        iNumeroLote = c.Int(nullable: false),
                        dCantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dCosto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dtFechaCaducidad = c.DateTime(nullable: false, precision: 0),
                        dtFechaFabricacion = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.idCapa);
            
            CreateTable(
                "dbo.Catalogos",
                c => new
                    {
                        idCatalogo = c.Int(nullable: false, identity: true),
                        sUDM = c.String(unicode: false),
                        sAbreviacion = c.String(unicode: false),
                        iValor = c.Int(nullable: false),
                        sClaveUnidad = c.String(unicode: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idCatalogo);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        idCategoria = c.Int(nullable: false, identity: true),
                        sNomCat = c.String(unicode: false),
                        sNomSubCat = c.String(unicode: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idCategoria);
            
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
                        iTipoCliente = c.Int(nullable: false),
                        iStatus = c.Int(nullable: false),
                        sLogo = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.idCliente);
            
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
                "dbo.DescuentosProducto",
                c => new
                    {
                        idDescuentoProducto = c.Int(nullable: false, identity: true),
                        descuento_id = c.Int(nullable: false),
                        producto_id = c.Int(nullable: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idDescuentoProducto);
            
            CreateTable(
                "dbo.DetalleAlmacenes",
                c => new
                    {
                        idDetalle = c.Int(nullable: false, identity: true),
                        sDescripcion = c.String(unicode: false),
                        almacen_id = c.Int(nullable: false),
                        producto_id = c.Int(nullable: false),
                        iCantidad = c.Int(nullable: false),
                        dCosto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idDetalle);
            
            CreateTable(
                "dbo.DetalleFacturas",
                c => new
                    {
                        idDetalleFactura = c.Int(nullable: false, identity: true),
                        factura_id = c.Int(nullable: false),
                        producto_id = c.Int(nullable: false),
                        sClave = c.String(unicode: false),
                        sDescripcion = c.String(unicode: false),
                        iCantidad = c.Int(nullable: false),
                        dPreUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idDetalleFactura);
            
            CreateTable(
                "dbo.DetalleInventarios",
                c => new
                    {
                        pkDetalleInventario = c.Int(nullable: false, identity: true),
                        inventario_id = c.Int(nullable: false),
                        producto_id = c.Int(nullable: false),
                        dCantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dLastCosto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dPreVenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.pkDetalleInventario);
            
            CreateTable(
                "dbo.DetallePeriodos",
                c => new
                    {
                        idDetallePeriodo = c.Int(nullable: false, identity: true),
                        periodo_id = c.Int(nullable: false),
                        venta_id = c.Int(nullable: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idDetallePeriodo);
            
            CreateTable(
                "dbo.DetalleVentas",
                c => new
                    {
                        idDetalleVenta = c.Int(nullable: false, identity: true),
                        venta_id = c.Int(nullable: false),
                        producto_id = c.Int(nullable: false),
                        sDescripcion = c.String(unicode: false),
                        dCantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dPreUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idDetalleVenta);
            
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
                "dbo.Existencias",
                c => new
                    {
                        idExistencia = c.Int(nullable: false, identity: true),
                        almacen_id = c.Int(nullable: false),
                        producto_id = c.Int(nullable: false),
                        dCantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dSalida = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dBaja = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dExistencia = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.idExistencia);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        idFactura = c.Int(nullable: false, identity: true),
                        usuario_id = c.Int(nullable: false),
                        sucursal_id = c.Int(nullable: false),
                        cliente_id = c.Int(nullable: false),
                        dtFecha = c.DateTime(nullable: false, precision: 0),
                        sFolio = c.String(unicode: false),
                        sTipoCambio = c.String(unicode: false),
                        sMoneda = c.String(unicode: false),
                        sUsoCfdi = c.String(unicode: false),
                        sFormaPago = c.String(unicode: false),
                        sMetodoPago = c.String(unicode: false),
                        sTipoCompro = c.String(unicode: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idFactura);
            
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
                "dbo.ImpuestosProducto",
                c => new
                    {
                        idDetalleProducto = c.Int(nullable: false, identity: true),
                        impuesto_id = c.Int(nullable: false),
                        producto_id = c.Int(nullable: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idDetalleProducto);
            
            CreateTable(
                "dbo.Inventarios",
                c => new
                    {
                        idInventario = c.Int(nullable: false, identity: true),
                        sFolio = c.String(unicode: false),
                        dtFecha = c.DateTime(nullable: false, precision: 0),
                        sTipoMov = c.String(unicode: false),
                        bStatus = c.Boolean(nullable: false),
                        usuario_id = c.Int(nullable: false),
                        almacen_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idInventario);
            
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
                        usuario_id = c.Int(nullable: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idPeriodo);
            
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
                "dbo.PermisosNegadosRol",
                c => new
                    {
                        idPermisoNegadoRol = c.Int(nullable: false, identity: true),
                        rol_id = c.Int(nullable: false),
                        permiso_id = c.Int(nullable: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idPermisoNegadoRol);
            
            CreateTable(
                "dbo.Precios",
                c => new
                    {
                        idPrecios = c.Int(nullable: false, identity: true),
                        sNombre = c.String(unicode: false),
                        iPrePorcen = c.Int(nullable: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idPrecios);
            
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
                        bStatus = c.Boolean(nullable: false),
                        categoria_id = c.Int(nullable: false),
                        catalogo_id = c.Int(nullable: false),
                        precio_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idProducto);
            
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
                        empresa_id = c.Int(nullable: false),
                        preferencia_id = c.Int(nullable: false),
                        certificado_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idSucursal);
            
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
                        rol_id = c.Int(nullable: false),
                        sucursal_id = c.Int(nullable: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idUsuario);
            
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
                        cliente_id = c.Int(nullable: false),
                        factura_id = c.Int(nullable: false),
                        usuario_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idVenta);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ventas");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Sucursales");
            DropTable("dbo.Roles");
            DropTable("dbo.Productos");
            DropTable("dbo.Preferencias");
            DropTable("dbo.Precios");
            DropTable("dbo.PermisosNegadosRol");
            DropTable("dbo.Permisos");
            DropTable("dbo.Periodos");
            DropTable("dbo.Inventarios");
            DropTable("dbo.ImpuestosProducto");
            DropTable("dbo.Impuestos");
            DropTable("dbo.Facturas");
            DropTable("dbo.Existencias");
            DropTable("dbo.Empresas");
            DropTable("dbo.DetalleVentas");
            DropTable("dbo.DetallePeriodos");
            DropTable("dbo.DetalleInventarios");
            DropTable("dbo.DetalleFacturas");
            DropTable("dbo.DetalleAlmacenes");
            DropTable("dbo.DescuentosProducto");
            DropTable("dbo.Descuentos");
            DropTable("dbo.Clientes");
            DropTable("dbo.Certificados");
            DropTable("dbo.Categorias");
            DropTable("dbo.Catalogos");
            DropTable("dbo.Capas");
            DropTable("dbo.Almacenes");
        }
    }
}
