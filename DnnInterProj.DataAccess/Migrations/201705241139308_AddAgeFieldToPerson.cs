namespace DnnInterProj.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAgeFieldToPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Persons", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Persons", "Age");
        }
    }
}
