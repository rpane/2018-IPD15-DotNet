using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPeople
{
    class SocietyContext : DbContext
    {
        public SocietyContext() : base("name = DBConectionSociety")
        {

        }
        public DbSet<Person> People { get; set;}

    }
}
