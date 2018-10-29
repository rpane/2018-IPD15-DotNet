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
        public void InsertPerson() //Fix Me
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
            //make sure all data is the same as inserted
            
        }
        [Test]
        public void UpdatePerson()
        {
            //Finish
        }
       
    }
}
