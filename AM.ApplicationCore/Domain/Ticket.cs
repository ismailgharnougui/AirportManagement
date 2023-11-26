using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {

        public int Id { get; set; }
        public string Classe { get; set; }
        public string Destination { get; set; }
        public virtual IList<ReservationTicket> Reservations { get; set; }
      


    }
}
