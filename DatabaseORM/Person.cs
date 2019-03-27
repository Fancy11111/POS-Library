using System.Data.Linq.Mapping;

namespace DatabaseORM
{
    public class Person
    {
        // Don't use IsDBGenerated, does not work with SQLite
        // Make nullable (int?) for inserting new rows
        // You can chose to not make it nullable if you don't insert data
        [Column(IsPrimaryKey = true)]
        public int? ID { get; set; }

        // Use basic column tag if the name of the property is the same as the name of the column
        // Use Column(Name = <columnname>) otherwise
        [Column]
        public string FirstName { get; set; }
        [Column]
        public string LastName { get; set; }
        [Column]
        public double Weight { get; set; }
    }
}