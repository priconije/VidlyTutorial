namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomerDateOfBirth : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET DateOfBirth = CAST('1992-06-16' AS DATETIME) WHERE Name = 'Ognjen Prica'");
            Sql("UPDATE Customers SET DateOfBirth = CAST('1996-10-21' AS DATETIME) WHERE Name = 'Sasa Prica'");
        }

        public override void Down()
        {
        }
    }
}
