using System.Data.Linq.Mapping;

namespace DatabaseORM
{
    [Table]
    public class Relation
    {
        // Don't use IsDBGenerated, does not work with SQLite
        // Make nullable (int?) for inserting new rows
        // You can chose to not make it nullable if you don't insert data
        [Column(IsPrimaryKey = true)]
        public int? ID { get; set; }

        // This is a foreign key
        // Look at Database.cs for further details
        [Column]
        public int PersonID1 { get; set; }

        // This is a foreign key
        // Look at Database.cs for further details
        [Column]
        public int PersonID2 { get; set; }

        [Column]
        public string Status { get; set; }
    }
}