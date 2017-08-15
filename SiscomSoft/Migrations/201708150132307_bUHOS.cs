namespace SiscomSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bUHOS : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Catalogos", "sClaveUnidad", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Catalogos", "sClaveUnidad");
        }
    }
}
