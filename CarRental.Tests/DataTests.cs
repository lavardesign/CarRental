using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using CarRental.Data.Classes;
using CarRental.Data.Interfaces;
using CarRental.Common.Enums;
using CarRental.Common.Classes;
using CarRental.Common.Extensions;
using CarRental.Common.Interfaces;
using CarRental.Business.Classes;

namespace CarRental.Tests
{
    public class DataTests
    {
        public const string FirstName = "John";
        public const string LastName = "Doe";
        public const string Ssn = "530210";
        public const string Make = "Ford";
        public const string RegNr = "PUU052";
        public const VehicleTypes VType = VehicleTypes.Combi;

        [Fact]
        public void CanCreateDataInstance()
        {
            IData data = new CollectionData();

            Assert.NotNull(data);
        }

        [Fact]
        public void CanGetPersons()
        {
            IData data = new CollectionData();
            var persons = data.GetPersons();

            Assert.NotNull(persons);
            Assert.NotEmpty(persons);
        }

        [Fact]
        public void CanGetVehicles()
        {
            IData data = new CollectionData();
            var vehiclesDefault = data.GetVehicles();
            var vehiclesAvailable = data.GetVehicles(VehicleStatuses.Available);

            Assert.NotNull(vehiclesDefault);
            Assert.NotNull(vehiclesAvailable);
            Assert.NotEmpty(vehiclesDefault);
            Assert.NotEmpty(vehiclesAvailable);
            Assert.True(vehiclesDefault.Count() >= vehiclesAvailable.Count());
        }

        [Fact]
        public void CanGetBookings()
        {
            IData data = new CollectionData();
            var bookings = data.GetBookings();

            Assert.NotNull(bookings);
            Assert.NotEmpty(bookings);
        }

        [Fact]
        public void CanGetPersonSingle()
        {
            IData data = new CollectionData();
            var person1 = data.GetPerson(Ssn);

            Assert.NotNull(person1);
            Assert.Equal(Ssn, person1.SocialSecurityNumber);
            var person2 = data.GetPerson(person1.Id);
            Assert.NotNull(person2);
            Assert.Same(person1, person2);
        }

        [Fact]
        public void CanGetVehicleSingle()
        {
            IData data = new CollectionData();
            var vehicle1 = data.GetVehicle(RegNr);

            Assert.NotNull(vehicle1);
            Assert.Equal(RegNr, vehicle1.RegistrationNumber);
            var vehicle2 = data.GetVehicle(vehicle1.Id);
            Assert.NotNull(vehicle2);
            Assert.Same(vehicle1, vehicle2);
        }

        [Fact]
        public void CanGetBookingSingle()
        {
            IData data = new CollectionData();
            var booking = data.GetBooking(1);

            Assert.NotNull(booking);
            Assert.Equal(0, booking.Id);
        }

        [Fact]
        public void CanNextIds()
        {
            IData data = new CollectionData();
            var bookingCount = data.GetBookings().Count();
            var vehicleCount = data.GetVehicles().Count();
            var personCount = data.GetPersons().Count();

            Assert.True(data.NextBookingId >= bookingCount);
            Assert.True(data.NextVehicleId >= vehicleCount);
            Assert.True(data.NextPersonId >= personCount);
        }
    }
}
