using System.Data.Linq;
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


        [Column]
        public string Status { get; set; }


        #region Foreign Keys/Associations
        // This section is used to allow direct access to the Entity referenced via a foreign key in a table
        // In this example Relations has to foreign keys, both referencing to a Person

        // This field stores the actual foreign key
        [Column(Name = "PersonID1")]
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
        [Column(Name = "PersonID2")]
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