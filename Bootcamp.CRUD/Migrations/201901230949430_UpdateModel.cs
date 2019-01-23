namespace Bootcamp.CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Suppliers");
            AlterColumn("dbo.Suppliers", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Suppliers", "id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Suppliers");
            AlterColumn("dbo.Suppliers", "id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Suppliers", "CreateDate");
        }
    }
}
