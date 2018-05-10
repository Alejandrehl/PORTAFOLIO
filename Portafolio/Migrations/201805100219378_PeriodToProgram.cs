namespace Portafolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PeriodToProgram : DbMigration
    {
        public override void Up()
        {
            AddColumn("CEM.Programs", "Period", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("CEM.Programs", "Period");
        }
    }
}
