using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Models
{
    [Table("productuser")]
    public class User
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        public string EmailID { get; set; }
        [Key]
        public int UserID { get; set; }
        public Role Role { get; set; }

    }
    
}
