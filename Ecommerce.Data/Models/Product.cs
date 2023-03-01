using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name Cannot Exceed 50 characters")]
        public string Name { get; set; }

        [MaxLength(150, ErrorMessage = "Description Cannot Exceed 150 characters")]
        public string Description { get; set; }

        [Range(1, 1000,ErrorMessage = "Price Must be Greater than 0")]
        public int Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return String.Format("{0}", this.Name);
        }
    }
}
