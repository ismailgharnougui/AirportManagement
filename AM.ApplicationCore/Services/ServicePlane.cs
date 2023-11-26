using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        public ServicePlane(ApplicationCore.Interfaces.IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void Deleteplanes()
        {
            Delete(p => p.ManufactureDate.Year - DateTime.Now.Year > 10);
        }

        public IEnumerable<Flight> GetFlight(int n)
        {

            return GetAll()
                .OrderByDescending(P => P.
                PlaneId)
                .Take(n)
                .SelectMany(p => p.Flights)
                .OrderBy(f => f.FlightDate);

        }

        public IEnumerable<Passenger> GetPassengers(Plane p)
        {
            return p.Flights.SelectMany(f => f.Passengers);

        }

        public IEnumerable<Plane> GetPlaneByDate(DateTime date)
        {
            return GetMany(p => p.ManufactureDate.Equals(date));
        }



        public bool check(Flight f, int n)
        {
            return f.Plane.Capacity > f.Passengers.Count() + n;
        }

        public IEnumerable<Staff> GetStaffById(string PassportNumber)
        {
            throw new NotImplementedException();
        }
    }

}