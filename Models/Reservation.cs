using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ContactId")]
        public int ContactId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string ReservationPlace { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ReservationDate { get; set; }

        [Column(TypeName = "bit")]
        public bool Favorite { get; set; } = false;

        public virtual Contact contacts {get; set;}
    }
}
