namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMoviesDB : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Movies ON");
            Sql("INSERT INTO Movies (Id, Name, GenreId, ReleaseDate, DateAdded, NumberInStock) " +
                "VALUES (1, 'John Wick', 1, CAST('2014-10-24' AS DATETIME), CAST('2018-01-26' AS DATETIME), 5)");

            Sql("INSERT INTO Movies (Id, Name, GenreId, ReleaseDate, DateAdded, NumberInStock) " +
                "VALUES (2, 'Hangover', 3, CAST('2009-06-15' AS DATETIME), CAST('2018-01-26' AS DATETIME), 5)");

            Sql("INSERT INTO Movies (Id, Name, GenreId, ReleaseDate, DateAdded, NumberInStock) " +
                "VALUES (3, 'Die Hard', 1, CAST('1988-07-20' AS DATETIME), CAST('2018-01-26' AS DATETIME), 5)");

            Sql("INSERT INTO Movies (Id, Name, GenreId, ReleaseDate, DateAdded, NumberInStock) " +
                "VALUES (4, 'Saw', 7, CAST('2004-10-29' AS DATETIME), CAST('2018-01-26' AS DATETIME), 5)");

            Sql("INSERT INTO Movies (Id, Name, GenreId, ReleaseDate, DateAdded, NumberInStock) " +
                "VALUES (5, 'Thor Ragnarok', 8, CAST('2017-11-03' AS DATETIME), CAST('2018-01-26' AS DATETIME), 5)");

            Sql("INSERT INTO Movies (Id, Name, GenreId, ReleaseDate, DateAdded, NumberInStock) " +
                "VALUES (6, 'Dunkirk', 6, CAST('2017-07-21' AS DATETIME), CAST('2018-01-26' AS DATETIME), 5)");
        }
        
        public override void Down()
        {
        }
    }
}
