using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]        
        public string ContactName { get; set; }

        [Required]
        public int ContactType { get; set; }

        [Column(TypeName = "nvarchar(12)")]
        public string ContactPhone { get; set; }

        [Required]
        [Column(TypeName = "date")]        
        public DateTime Birthday { get; set; }
    }
}
