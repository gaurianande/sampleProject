using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Models
{
    public class Credentials
    {
        [NotNull]
        public string Username { get; set; }
        [NotNull]
        public string Password { get; set; }
    }
}
