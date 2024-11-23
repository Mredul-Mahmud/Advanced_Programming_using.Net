using PerformanceOnDTOCrud.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace PerformanceOnDTOCrud.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        [Required (ErrorMessage = "Please provide a name")]
        [StringLength(50)]
        [RegularExpression("^[a-zA-Z.-]+$", ErrorMessage = "Name can only contain alphabetic characters")]
        public string Name { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please provide the price")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Please provide Stock Quantity")]
        public int StockQuantity { get; set; }
        [Required(ErrorMessage = "Please provide a Category")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Please provide a Category Id")]
        public int CategoryId { get; set; }

        public virtual AllCategory AllCategory { get; set; }
    }
}