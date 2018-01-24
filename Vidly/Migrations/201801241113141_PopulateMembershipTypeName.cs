namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Neko ime' WHERE Id = 1");
            Sql("UPDATE MembershipTypes (Id, SignupFee, DurationInMonths, DiscountRate) VALUES (2, 30, 1, 10)");
            Sql("UPDATE MembershipTypes (Id, SignupFee, DurationInMonths, DiscountRate) VALUES (3, 90, 3, 15)");
            Sql("UPDATE MembershipTypes (Id, SignupFee, DurationInMonths, DiscountRate) VALUES (4, 300, 12, 20)");
        }
        
        public override void Down()
        {
        }
    }
}
