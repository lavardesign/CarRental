using System;
using System.Collections.Generic;
using System.Text;
using CarRental.Common.Enums;

namespace CarRental.Common.Classes
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(int id, string make, string registrationNumber, double odometer, double costKm, VehicleStatuses status)
            : base(id, make, registrationNumber, odometer, costKm, status, VehicleTypes.Motorcycle)
        {
        }

        public Motorcycle(int id, string make, string registrationNumber, double odometer, double costKm)
            : this(id, make, registrationNumber,odometer, VehicleStatuses.Available)
        {
        }

        public Motorcycle(int id, string make, string registrationNumber, double costKm, VehicleStatuses status)
            : this(id, make, registrationNumber,costKm, 0d, status)
        {
        }

        public Motorcycle(int id, string make, string registrationNumber, double costKm)
            : this(id, make, registrationNumber, costKm, 0d, VehicleStatuses.Available)
        {
        }
    }
}
