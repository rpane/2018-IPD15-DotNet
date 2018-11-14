using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EFPeopleCars
{
   public class PeopleCarsContext : DbContext
    {
        public PeopleCarsContext() : base("name=PeopleCars") 
        {

        }
        public DbSet<Person> People { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
