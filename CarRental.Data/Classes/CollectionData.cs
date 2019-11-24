using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CarRental.Data.Interfaces;
using CarRental.Common.Interfaces;
using CarRental.Common.Enums;
using CarRental.Common.Classes;

namespace CarRental.Data.Classes
{
    public class CollectionData : IData
    {
        readonly List<IPerson> persons = new List<IPerson>();
        readonly List<IVehicle> vehicles = new List<IVehicle>();
        readonly List<IBooking> bookings = new List<IBooking>();

        public int NextVehicleId => vehicles.Count == 0 ? 0 : vehicles.Max(x => x.Id) + 1;
        public int NextPersonId => persons.Count == 0 ? 0 : persons.Max(x => x.Id) + 1;
        public int NextBookingId => bookings.Count == 0 ? 0 : bookings.Max(x => x.Id) + 1;

        public CollectionData()
        {
            SeedData();
        }

        void SeedData()
        {
            persons.AddRange(new List<IPerson>
            {
            new Customer(0, "800316", "Björn", "Österholm"),
            new Customer(1, "750702", "Julia", "Oehm"),
            new Customer(2, "530210", "John", "Doe")
            });

            vehicles.AddRange(new List<IVehicle>
            {
                new Car(0, "Ford", "PUU052", 20000, 1, VehicleStatuses.Available, VehicleTypes.Combi),
                new Car(1, "Mercedes", "LYX999", 1000, 2, VehicleStatuses.Available, VehicleTypes.Sedan),
                new Car(2, "WV", "WAS609", 45000, 2, VehicleStatuses.Available, VehicleTypes.Sedan),
                new Motorcycle(3, "KTM", "SPD300", 200, 5, VehicleStatuses.Available),
                new Car(4, "Passat", "PAS001", 80000, 2.5, VehicleStatuses.Available, VehicleTypes.Van)
            });

            var vehicle1 = vehicles[3];
            var person1 = persons[2];
            bookings.Add(new Booking(vehicle1, person1, 1));

            var vehicle2 = vehicles[0];
            var person2 = persons[1];
            var booking = new Booking(vehicle2, person2, 2);
            bookings.Add(booking);

            vehicle2.Drive(400);
            booking.ReturnVehicle(vehicle2);
        }

        public IBooking GetBooking(int vehicleId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IBooking> GetBookings() => bookings;

        public IEnumerable<IBooking> GetBookings(int vehicleId) => bookings.Where(x => x.VehicleId == vehicleId);

        public IPerson GetPerson(string socialSecurityNumber) => persons.SingleOrDefault(x => x.SocialSecurityNumber == socialSecurityNumber);

        public IPerson GetPerson(int id) => persons.SingleOrDefault(x => x.Id == id);

        public IEnumerable<IPerson> GetPersons() => persons;

        public IVehicle GetVehicle(string registrationNumber) => vehicles.SingleOrDefault(x => x.RegistrationNumber == registrationNumber);

        public IVehicle GetVehicle(int id) => vehicles.SingleOrDefault(x => x.Id == id);

        public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default)
        {
            if (status == default)
            {
                return vehicles;
            }
            return vehicles.Where(x => x.Status == status);
        }

        public void AddPerson(IPerson person)
        {
            if (persons.Any(x => x.SocialSecurityNumber == person.SocialSecurityNumber))
            {
                throw new ArgumentException("Person already exists in data source", nameof(person));
            }
            persons.Add(person);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            if (vehicles.Any(x => x.Id == vehicle.Id)) throw new ArgumentException("The vehicle already exists", nameof(vehicle));
            vehicles.Add(vehicle);
        }

        public IBooking RentVehicle(int vehicleId, int customerId)
        {
            var vehicle = GetVehicle(vehicleId) ?? throw new ArgumentException("No matching vehicle in data source", nameof(vehicleId));
            var person = GetPerson(customerId) ?? throw new ArgumentException("No matching person in data source", nameof(NextPersonId));
            var booking = new Booking(vehicle, person, NextBookingId);
            bookings.Add(booking);
            return booking;
        }

        public IBooking ReturnVehicle(int vehicleId)
        {
            var booking = GetBooking(vehicleId) ?? throw new ArgumentException("No matching booking in data source", nameof(vehicleId));
            var vehicle = GetVehicle(vehicleId) ?? throw new ArgumentException("No matching vehicle in data source", nameof(vehicleId));
            booking.ReturnVehicle(vehicle);
            return booking;
        }
    }
}
