using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;

using AM.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace AM.Infrastructure

{
    public class ServiceFlight : Service<Flight>, IServiceFlight
    {
        public ServiceFlight(ApplicationCore.Interfaces.IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public IEnumerable<Staff> GetStaffById(int volId)
        {
            return GetById(volId).Passengers.OfType<Staff>();
        }
    }
}
