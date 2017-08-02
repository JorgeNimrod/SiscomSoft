using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace SiscomSoft.Models
{
    public class DataModel : DbContext
    {
        public DataModel() : base("DataModel") { }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Sucursal> Sucursales { get; set; }

        public DbSet<Certificado> Certificados { get; set; }

        public DbSet<Preferencia> Preferencias { get; set; }

        public DbSet<Rol> Roles { get; set; }

        public DbSet<Permiso> Permisos { get; set; }

        public DbSet<PermisoNegadoRol> PermisosNegadosRol { get; set; }

        public DbSet<Impuesto> Impuestos { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }

        public DbSet<Precio> Precios { get; set; }

        public DbSet<InventarioEntrada> InventariosEntradas { get; set; }

        public DbSet<Catalogo> Catalogos { get; set; }

        public DbSet<Factura> Facturas { get; set; }

        public DbSet<Venta> Ventas { get; set; }

        public DbSet<DetalleVenta> DetalleVentas { get; set; }

        public DbSet<Almacen> Almacenes { get; set; }

        public DbSet<DetalleAlmacen> DetalleAlmacen { get; set; }

        public DbSet<ImpuestoProducto> ImpuestosProductos { get; set; }

        public DbSet<DescuentoProducto> DescuentosProductos { get; set; }

        public DbSet<Descuento> Descuentos { get; set; }

        public DbSet<Periodo> Periodos { get; set; }

        public DbSet<DetallePeriodo> DetallePeriodos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DataModel>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
