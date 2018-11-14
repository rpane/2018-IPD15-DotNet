using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPeople
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            //Add
            using (SocietyContext ctx = new SocietyContext())
            {
                Person p = new Person { Name = "Jerry", Age = rand.Next(1, 100), Gender = Person.GenderEnum.Male };
                ctx.People.Add(p);
                ctx.SaveChanges();
                Console.WriteLine("Person added");
            }
            //Update
            using (SocietyContext ctx = new SocietyContext())
            {
                var people = (from p in ctx.People where p.Id == 2 select p).ToList();
                if(people.Count == 0)
                {
                    Console.WriteLine("Record not found");
                }
                else
                {
                    Person p = people[0];
                    Console.WriteLine("Person Found! " +p);
                    p.Name = "Steve";
                    p.Age = 20;
                    p.Gender = Person.GenderEnum.Female;
                    ctx.SaveChanges();
                }
            }
            // Delete
            using (SocietyContext ctx = new SocietyContext())
            {
                var people = (from p in ctx.People where p.Id == 3 select p).ToList();
                if (people.Count == 0)
                {
                    Console.WriteLine("Record not found");
                }
                else
                {
                    Person p = people[0];
                    ctx.People.Remove(p);
                    ctx.SaveChanges();
                    Console.WriteLine("Person Found! and deleted " + p);
                }
            }
            Console.ReadKey();
        }
    }
}
