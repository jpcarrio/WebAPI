using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ContactReservation
    {
        public string contactName { get; set; }
        public int contactType { get; set; }
        public string contactPhone { get; set; }
        public DateTime birthday { get; set; }
        public string reservationPlace { get; set; }
        public DateTime reservationDate { get; set; }        
    }
}
