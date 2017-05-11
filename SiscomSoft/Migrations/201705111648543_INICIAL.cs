namespace SiscomSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INICIAL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Certificados",
                c => new
                    {
                        pkCertificado = c.Int(nullable: false, identity: true),
                        sCSD = c.String(nullable: false, unicode: false),
                        sCertificado = c.String(nullable: false, unicode: false),
                        sLLave = c.String(nullable: false, unicode: false),
                        sContraseña = c.String(nullable: false, unicode: false),
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
                        iTelefono = c.Int(nullable: false),
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
                        fkCertificado_pkCertificado = c.Int(),
                        fkSucursal_pkSucursal = c.Int(),
                    })
                .PrimaryKey(t => t.pkEmpresa)
                .ForeignKey("dbo.Certificados", t => t.fkCertificado_pkCertificado)
                .ForeignKey("dbo.Sucursales", t => t.fkSucursal_pkSucursal)
                .Index(t => t.fkCertificado_pkCertificado)
                .Index(t => t.fkSucursal_pkSucursal);
            
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
                    })
                .PrimaryKey(t => t.pkPreferencia);
            
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
                        iNumCuenta = c.Int(nullable: false),
                        sCondPAgo = c.String(unicode: false),
                        sTipoCliente = c.String(unicode: false),
                        sLogo = c.String(unicode: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkCliente);
            
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
                        sPerfil = c.String(nullable: false, unicode: false),
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
                "dbo.Productos",
                c => new
                    {
                        pkProducto = c.Int(nullable: false, identity: true),
                        sDescripcion = c.String(unicode: false),
                        sCategoria = c.String(unicode: false),
                        sMarca = c.String(unicode: false),
                        iUnidadMed = c.Int(nullable: false),
                        dPrecio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dCosto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        bStatus = c.Boolean(nullable: false),
                        fkImpuesto_pkImpuesto = c.Int(),
                    })
                .PrimaryKey(t => t.pkProducto)
                .ForeignKey("dbo.Impuestos", t => t.fkImpuesto_pkImpuesto)
                .Index(t => t.fkImpuesto_pkImpuesto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productos", "fkImpuesto_pkImpuesto", "dbo.Impuestos");
            DropForeignKey("dbo.PermisosNegadosRol", "fkRol_pkRol", "dbo.Roles");
            DropForeignKey("dbo.Usuarios", "fkRol_pkRol", "dbo.Roles");
            DropForeignKey("dbo.PermisosNegadosRol", "fkPermiso_pkPermiso", "dbo.Permisos");
            DropForeignKey("dbo.Sucursales", "fkPreferencia_pkPreferencia", "dbo.Preferencias");
            DropForeignKey("dbo.Empresas", "fkSucursal_pkSucursal", "dbo.Sucursales");
            DropForeignKey("dbo.Empresas", "fkCertificado_pkCertificado", "dbo.Certificados");
            DropIndex("dbo.Productos", new[] { "fkImpuesto_pkImpuesto" });
            DropIndex("dbo.PermisosNegadosRol", new[] { "fkRol_pkRol" });
            DropIndex("dbo.Usuarios", new[] { "fkRol_pkRol" });
            DropIndex("dbo.PermisosNegadosRol", new[] { "fkPermiso_pkPermiso" });
            DropIndex("dbo.Sucursales", new[] { "fkPreferencia_pkPreferencia" });
            DropIndex("dbo.Empresas", new[] { "fkSucursal_pkSucursal" });
            DropIndex("dbo.Empresas", new[] { "fkCertificado_pkCertificado" });
            DropTable("dbo.Productos");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Roles");
            DropTable("dbo.PermisosNegadosRol");
            DropTable("dbo.Permisos");
            DropTable("dbo.Impuestos");
            DropTable("dbo.Clientes");
            DropTable("dbo.Preferencias");
            DropTable("dbo.Sucursales");
            DropTable("dbo.Empresas");
            DropTable("dbo.Certificados");
        }
    }
}
