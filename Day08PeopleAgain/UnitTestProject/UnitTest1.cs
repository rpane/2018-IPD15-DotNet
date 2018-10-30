using System;
using System.Collections.Generic;
using System.Linq;
using Day08PeopleAgain;
using NUnit.Framework;


namespace UnitTestProject
{
    [TestFixture]
    public class UnitTest1
    {
        Database db;

        [SetUp]
        public void Initialize()
        {
            db = new Database();
        }

        [Test]
        public void InsertPerson()
        {
            Person p1 = new Person() { Name = "Test1", Age = 33, Gender = Person.GenderEnum.NA };
            Person p2 = new Person() { Name = "Test2", Age = 22, Gender = Person.GenderEnum.Female };
            //Insert a record
            int id1 = db.AddPerson(p1);
            //Insert a second record
            int id2 = db.AddPerson(p2);
            //make sure crested IDs are consecutive
            Assert.AreEqual(id2 - id1, 1, "Ids of the two inserts must be consecutive");
            //Find the record just inserted
            List<Person> list = db.GetAllPeople();
            Person p1returned = (from p in list where p.Id == id1 select p).First();
            Person p2returned = (from p in list where p.Id == id2 select p).First();
            Assert.IsNotNull(p1returned, "Did not find person 1 as inserted");
            Assert.IsNotNull(p2returned, "Did not find person 2 as inserted");
            // make sure all data is the same as inserted
            Assert.AreEqual(p1.Name, p1returned.Name, "P1 names are different after insert");
            Assert.AreEqual(p1.Age, p1returned.Age, "P1 ages are different after insert");
            Assert.AreEqual(p1.Gender, p1returned.Gender, "P1 ages are different after insert");
            // cleanup - delete
            db.DeletePerson(id1);
            db.DeletePerson(id2);
            // make sure they are gone
            /*
            List<Person> list2 = db.GetAllPeople();
            Person p1returned2 = (from p in list2 where p.Id == id1 select p).First();
            Person p2returned2 = (from p in list2 where p.Id == id2 select p).First();            
            Assert.IsTrue(p1returned2.Name==null, "Did not find person 1 as inserted");
            Assert.IsNull(p2returned2, "Did not find person 2 as inserted");
            */
        }
        [Test]
        public void UpdatePerson()
        {
            List<Person> list = db.GetAllPeople();
            Person x = list[0] as Person;
            Person y = list[0] as Person;           
            y.Name = "Joey";
            y.Age = 32;
            y.Gender = Person.GenderEnum.Male;
            db.UpdatePerson(y);
            Assert.AreEqual(x, y, "They are not the same");
            //Cleanup
            db.DeletePerson(y.Id);

        }
       
    }
}
