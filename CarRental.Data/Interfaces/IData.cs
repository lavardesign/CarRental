using System;
using System.Collections.Generic;
using System.Text;
using CarRental.Common.Interfaces;
using CarRental.Common.Enums;

namespace CarRental.Data.Interfaces
{
    public interface IData
    {
        IEnumerable<IPerson> GetPersons();
        IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default);
        IEnumerable<IBooking> GetBookings();
        IBooking GetBooking(int vehicleId);
        IPerson GetPerson(string socialSecurityNumber);
        IPerson GetPerson(int id);
        IVehicle GetVehicle(string registrationNumber);
        IVehicle GetVehicle(int id);


    }
}
