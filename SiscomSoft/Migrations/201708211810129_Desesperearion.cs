namespace SiscomSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Desesperearion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "iTipoCliente", c => c.Int(nullable: false));
            DropColumn("dbo.Clientes", "sTipoCliente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "sTipoCliente", c => c.String(unicode: false));
            DropColumn("dbo.Clientes", "iTipoCliente");
        }
    }
}
