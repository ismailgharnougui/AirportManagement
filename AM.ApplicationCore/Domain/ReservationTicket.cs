using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class ReservationTicket
    {
        public DateTime DateReservation { get; set; }

        public double Prix { get; set; }
        public string PassengerFK { get; set; }
      
        public int TicketFK { get; set; }
        [ForeignKey("TicketFK")]
        public virtual Ticket Ticket { get; set; }
        [ForeignKey("PassengerFK")]
        public virtual Passenger Passenger { get; set; }
    }
}
