namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameToMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes SET Name=( Case WHEN Id=1 THEN 'Pay as you go' WHEN Id=2 THEN 'Monthly' WHEN Id=3 THEN 'Quarterly' WHEN Id=4 THEN 'Annual' END);");
        }
        
        public override void Down()
        {
        }
    }
}
