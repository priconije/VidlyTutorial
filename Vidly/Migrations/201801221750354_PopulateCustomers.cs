namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomers : DbMigration
    {
        public override void Up()
        {
            //c# 'bool' tip = sql 'bit' -> kada se setuje ne koristimo true/false nego 0/1
            Sql("INSERT INTO Customers (Name, IsSubscribedToNewsletter, MembershipTypeId) VALUES ('Ognjen Prica', 0, 1)");
            Sql("INSERT INTO Customers (Name, IsSubscribedToNewsletter, MembershipTypeId) VALUES ('Sasa Prica', 1, 2)");
        }
        
        public override void Down()
        {
        }
    }
}
