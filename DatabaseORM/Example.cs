using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseORM
{
    public class Example
    {
        public static void ReadingData()
        {
            // This is the connection string for SQLite
            // DbLinqProvider = Sqlite  is needed always
            var conn = new SQLiteConnection($"DbLinqProvider=Sqlite;Data Source=Example.db");
            List<Person> persons;
            List<Relation> relations;
            using(var db = new Database(conn))
            {
                persons = db.Persons.ToList();
                relations = db.Relations.ToList();
            }

            // read data here
        }

        public static void InsertData()
        {
            // This is the connection string for SQLite
            // DbLinqProvider = Sqlite  is needed always
            var conn = new SQLiteConnection($"DbLinqProvider=Sqlite;Data Source=Example.db");
            using (var db = new Database(conn))
            {
                // row that you want to insert
                var person = new Person() { FirstName = "Daniel", LastName = "Fenz", Weight = 666.666 };
                // Add person to batch
                db.Persons.InsertOnSubmit(person);
                // execute batch
                db.SubmitChanges();
            }
        }
    }
}
