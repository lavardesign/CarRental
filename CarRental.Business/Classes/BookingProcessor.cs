using System;
using System.Collections.Generic;
using System.Text;
using CarRental.Data.Interfaces;
using CarRental.Data.Classes;
using CarRental.Common.Classes;
using CarRental.Common.Enums;
using CarRental.Common.Interfaces;

namespace CarRental.Business.Classes
{
    public class BookingProcessor
    {
        private readonly IData _db = new CollectionData();

        public IEnumerable<Customer> GetCustomers()
        {
            var customers = new List<Customer>();
            foreach (var person in _db.GetPersons())
            {
                if (person is Customer customer)
                {
                    customers.Add(customer);
                }
            }
            return customers;
        }

        public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => _db.GetVehicles(status);

        public IEnumerable<IBooking> GetBookings() => _db.GetBookings();

        public IBooking GetBooking(int vehicleId) => _db.GetBooking(vehicleId);

        public Customer GetCustomer(int customerId) => (Customer)_db.GetPerson(customerId);

        public IVehicle GetVehicle(int vehicleId) => _db.GetVehicle(vehicleId);

        public IEnumerable<string> VehicleStatusNames => _db.VehicleStatusNames;
        public IEnumerable<string> VehicleTypeNames => _db.VehicleTypeNames;
        public VehicleStatuses GetVehicleStatuses(string name) => _db.GetVehicleStatuses(name);
        public VehicleTypes GetVehicleTypes(string name) => _db.GetVehicleTypes(name);
    }
}
