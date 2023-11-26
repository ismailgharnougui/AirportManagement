using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePlane:IService<Plane>
    {
        public IEnumerable<Passenger> GetPassengers(Plane p);

        public IEnumerable<Flight> GetFlight(int n);
        public IEnumerable<Staff> GetStaffById(string PassportNumber);

        void Deleteplanes();
        public bool check(Flight f, int n);
        
    }
}
