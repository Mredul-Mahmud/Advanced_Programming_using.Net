using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PerformanceOnDTOCrud.EF;

namespace PerformanceOnDTOCrud.DTOs
{
    public class CustomerDTO
    {

        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please provide first name")]
        [StringLength(50)]
        [RegularExpression("^[a-zA-Z.-]+$", ErrorMessage = "First name can only contain alphabetic characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please provide last name")]
        [StringLength(50)]
        [RegularExpression("^[a-zA-Z.-]+$", ErrorMessage = "Last name can only contain alphabetic characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please provide an email address")]
        [EmailAddress(ErrorMessage = "Please provide a valid email address")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Please provide a date")]
        public System.DateTime DateJoined { get; set; }
    }
}