using System;
using System.Collections.Generic;
using System.Data.Linq; // Import this
using System.Data.Linq.Mapping; // Import this
using System.Data.SQLite; // Import this
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseORM
{
    [Database]
    public class Database : DataContext
    {
        #region Constructor
        // To see how the connection string for SQLite is built, see DatabaseORM/Example.cs
        public Database(SQLiteConnection conn) : base(conn)
        {
        
        }
        #endregion

        #region Tables
        public Table<Person> Persons;
        public Table<Relation> Relations;
        #endregion
    }
}
