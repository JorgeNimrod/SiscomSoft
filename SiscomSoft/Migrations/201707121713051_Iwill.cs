namespace SiscomSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Iwill : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetalleAlmacen", "dtFechaCaducidad", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DetalleAlmacen", "dtFechaCaducidad");
        }
    }
}
