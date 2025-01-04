using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EF
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide a Name")]
        [RegularExpression("^[a-zA-Z.-]+$", ErrorMessage = "Name can only contain alphabetic characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide a salary")]
        public string Salary { get; set; }
        [Required(ErrorMessage = "Please provide a NID Number")]
        [MaxLength(12)]
        public string NIDNumber { get; set; }
        [Required(ErrorMessage = "Please provide a date")]
        public System.DateTime Dob { get; set; }
    }
}
