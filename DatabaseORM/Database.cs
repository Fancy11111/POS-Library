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
        public Database(SQLiteConnection conn) : base(conn)
        {
        
        }
        #endregion

        #region Tables
        public Table<Person> Persons;
        public Table<Relation> Relations;
        #endregion

        #region Foreign Keys/Associations
        // This section is used to allow direct access to the Entity referenced via a foreign key in a table
        // In this example Relations has to foreign keys, both referencing to a Person

        // This field stores the actual foreign key
        private int personid1;

        // this is the Reference to the entity
        // you can get the entity of an EntityRef via the Entity property
        private EntityRef<Person> _person1 = new EntityRef<Person>();

        // The property is used to capsule the EntityRef object
        // IsForeignKey = True for all references, Storage = <EntityRefField>, ThisKey = <ForeignKeyField>
        [Association(Name = "FK_ROUTER", IsForeignKey = true, Storage = "_person1", ThisKey = "personid1")]
        public Person Person1
        {
            get { return _person1.Entity; }
            set { _person1.Entity = value; }
        }

        // This field stores the actual foreign key
        private int personid2;

        // this is the Reference to the entity
        // you can get the entity of an EntityRef via the Entity property
        private EntityRef<Person> _person2 = new EntityRef<Person>();

        // The property is used to capsule the EntityRef object
        // IsForeignKey = True for all references, Storage = <EntityRefField>, ThisKey = <ForeignKeyField>
        [Association(Name = "FK_ROUTER", IsForeignKey = true, Storage = "_person2", ThisKey = "personid2")]
        public Person Person2
        {
            get { return _person2.Entity; }
            set { _person2.Entity = value; }
        }
        #endregion
    }
}
