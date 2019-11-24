using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Common.Interfaces
{
    public interface IBooking
    {
        int Id { get; }
        int VehicleId { get; }
        string RegistrationNumber { get; }
        IPerson Person { get; }
        DateTime Rented { get; }
        DateTime Returned { get; }
        double Cost { get; }
        double OdometerRented { get; }
        double OdometerReturned { get; }

        void ReturnVehicle(IVehicle vehicle);
    }
}
