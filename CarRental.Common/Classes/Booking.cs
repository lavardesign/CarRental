using System;
using System.Collections.Generic;
using System.Text;
using CarRental.Common.Interfaces;
using CarRental.Common.Extensions;

namespace CarRental.Common.Classes
{
    public class Booking : IBooking
    {
        private readonly IVehicle _vehicle;
        private readonly IPerson person;

        public int Id { get; }

        public int VehicleId => _vehicle.Id;

        public string RegistrationNumber => _vehicle.RegistrationNumber;

        public IPerson Person => person;

        public DateTime Rented { get; }

        public DateTime Returned { get; private set; }

        public double Cost
        {
            get
            {
                if (Returned == default) return double.NaN;
                var days = Rented.DurationDays(Returned);
                var km = OdometerReturned - OdometerRented;
                return days * _vehicle.CostDay + km * _vehicle.CostKm;
            }
        }

        public double OdometerRented { get; }

        public double OdometerReturned { get; private set; }

        public void ReturnVehicle(IVehicle vehicle)
        {
            if (vehicle != _vehicle) throw new ArgumentException("Vehicles don't match", nameof(vehicle));
            if (vehicle.Odometer < _vehicle.Odometer) throw new ArgumentException("New odometer reading can't be less than old reading", nameof(vehicle));

            Returned = DateTime.Now;
            OdometerReturned = _vehicle.Odometer;
            _vehicle.Status = Enums.VehicleStatuses.Available;
        }

        public Booking(IVehicle vehicle, IPerson person, int id)
        {
            var exceptions = new List<Exception>();
            if (id < 0) exceptions.Add(new ArgumentException("ID can't be negative", nameof(id)));
            if (vehicle.Id < 0) exceptions.Add(new ArgumentException("Vehicle ID can't be negative", nameof(vehicle)));
            if (person.Id < 0) exceptions.Add(new ArgumentException("Person ID can't be negative", nameof(person)));
            if (vehicle.Status == Enums.VehicleStatuses.Booked) exceptions.Add(new ArgumentException("Vehicle is already booked", nameof(vehicle)));
            if (exceptions.Count > 0) throw new AggregateException(exceptions);

            _vehicle = vehicle;
            this.person = person;
            Id = id;
            Rented = DateTime.Now;
            OdometerRented = vehicle.Odometer;
            OdometerReturned = double.NaN;

            vehicle.Status = Enums.VehicleStatuses.Booked;
        }
    }
}
