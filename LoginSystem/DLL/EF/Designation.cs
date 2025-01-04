using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EF
{
    public class Designation
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide a Name")]
        [RegularExpression("^[a-zA-Z.-]+$", ErrorMessage = "Name can only contain alphabetic characters")]
        public string Name { get; set; }

        public string Description { get; set; }
        [Required(ErrorMessage = "Please provide the type")]
        public string Type { get; set; }
    }
}