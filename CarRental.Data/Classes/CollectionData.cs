using System;
using System.Collections.Generic;
using System.Text;
using CarRental.Data.Interfaces;
using CarRental.Common.Interfaces;
using CarRental.Common.Enums;

namespace CarRental.Data.Classes
{
    public class CollectionData : IData
    {
        readonly List<IPerson> _persons = new List<IPerson>();
        readonly List<IVehicle> _vehicles = new List<IVehicle>();
        readonly List<IBooking> _bookings = new List<IBooking>();

        public CollectionData()
        {
            SeedData();
        }

        void SeedData()
        {
            _persons.Add(new Customer(1, "800316", "Björn", "Österholm"));
            _persons.Add(new Customer(2, "750702", "Julia", "Oehm"));

            _vehicles.AddRange(new List<IVehicle>
            {
                new Car(1, "Ford", "PUU052", 20000, 1, VehicleStatuses.Available, VehicleTypes.Combi),
                new Car(2, "Mercedes", "LYX999", 1000, 2, VehicleStatuses.Available, VehicleTypes.Sedan),
                new Car(3, "WV", "WAS609", 45000, 2, VehicleStatuses.Available, VehicleTypes.Sedan),
                new Car(4, "KTM", "SPD300", 200, 5, VehicleStatuses.Available, VehicleTypes.Motorcycle),
                new Car(5, "Passat", "PAS001", 80000, 2.5, VehicleStatuses.Available, VehicleTypes.Van)
            });

            var vehicle1 = _vehicles.Single(v => v.Id.Equals(4));
            vehicle1.Status = VehicleStatuses.Booked;
            var person1 = _persons.Single(v => v.Id.Equals(2));
            _bookings.Add(new Booking(1, vehicle1, person1));

            var vehicle2 = _vehicles.Single(v => v.Id.Equals(2));
            var person2 = _persons.Single(v => v.Id.Equals(1));
            var booking = new Booking(2, vehicle2, person2);
            _bookings.Add(booking);

            booking.ReturnVehicle(vehicle2);
            vehicle2.Status = VehicleStatuses.Available;
        }

        public IBooking GetBooking(int vehicleId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IBooking> GetBookings()
        {
            throw new NotImplementedException();
        }

        public IPerson GetPerson(string socialSecurityNumber)
        {
            throw new NotImplementedException();
        }

        public IPerson GetPerson(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPerson> GetPersons()
        {
            throw new NotImplementedException();
        }

        public IVehicle GetVehicle(string registrationNumber)
        {
            throw new NotImplementedException();
        }

        public IVehicle GetVehicle(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = 0)
        {
            throw new NotImplementedException();
        }
    }
}
