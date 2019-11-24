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
        IEnumerable<IBooking> GetBookings(int vehicleId);
        IBooking GetBooking(int vehicleId);
        IPerson GetPerson(string socialSecurityNumber);
        IPerson GetPerson(int id);
        IVehicle GetVehicle(string registrationNumber);
        IVehicle GetVehicle(int id);

        int NextVehicleId { get; }
        int NextPersonId { get; }
        int NextBookingId { get; }

        void AddVehicle(IVehicle vehicle);
        void AddPerson(IPerson customer);

        IBooking RentVehicle(int vehicleId, int customerId);
        IBooking ReturnVehicle(int vehicleId);

        public IEnumerable<string> VehicleStatusNames => Enum.GetNames(typeof(VehicleStatuses));
        public VehicleStatuses GetVehicleStatuses(string name) => (VehicleStatuses)Enum.Parse(typeof(VehicleStatuses), name);
        public IEnumerable<string> VehicleTypeNames => Enum.GetNames(typeof(VehicleTypes));
        public VehicleTypes GetVehicleTypes(string name) => (VehicleTypes)Enum.Parse(typeof(VehicleTypes), name);
    }
}
