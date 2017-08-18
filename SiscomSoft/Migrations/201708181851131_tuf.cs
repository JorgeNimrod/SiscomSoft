namespace SiscomSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tuf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Catalogos", "sAbreviacion", c => c.String(unicode: false));
            AddColumn("dbo.Catalogos", "iValor", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Catalogos", "iValor");
            DropColumn("dbo.Catalogos", "sAbreviacion");
        }
    }
}
