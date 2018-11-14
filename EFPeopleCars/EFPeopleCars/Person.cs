using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPeopleCars
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50), Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public GenderEnum Gender { get; set; }

        public enum GenderEnum { Male = 1, Female = 2, NA = 0 }

        public override string ToString()
        {
            return string.Format("Person found: name {0}, age {1}, gender {2}", Name, Age, Gender);
        }
    }
}
