namespace SiscomSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AAA : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Descuentos", "dTasaDesc", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Descuentos", "dTasaDescEx", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Descuentos", "iTasaDesc");
            DropColumn("dbo.Descuentos", "iTasaDescEx");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Descuentos", "iTasaDescEx", c => c.Int(nullable: false));
            AddColumn("dbo.Descuentos", "iTasaDesc", c => c.Int(nullable: false));
            DropColumn("dbo.Descuentos", "dTasaDescEx");
            DropColumn("dbo.Descuentos", "dTasaDesc");
        }
    }
}
