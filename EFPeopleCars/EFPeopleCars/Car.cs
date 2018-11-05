using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPeopleCars
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50), Required]
        public string MakeModel { get; set; }

        [Required]
        public int YearOfProduction { get; set; }
    }
}
