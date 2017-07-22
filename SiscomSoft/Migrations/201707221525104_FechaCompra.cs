namespace SiscomSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FechaCompra : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Almacenes", "dtFechaCompra", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Almacenes", "dtFechaCompra");
        }
    }
}
