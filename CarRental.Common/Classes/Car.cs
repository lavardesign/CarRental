using System;
using System.Collections.Generic;
using System.Text;
using CarRental.Common.Enums;

namespace CarRental.Common.Classes
{
    public class Car : Vehicle
    {
        public Car(int id, string make, string registrationNumber, double odometer, double costKm, VehicleStatuses status, VehicleTypes type)
            : base(id, make, registrationNumber, odometer, costKm, status, type)
        {
            if (type == VehicleTypes.Motorcycle)
            {
                throw new ArgumentException("Car can't be a Motorcycle", nameof(type));
            }
        }

        public Car(int id, string make, string registrationNumber, double costKm, VehicleStatuses status, VehicleTypes type)
            : this(id, make, registrationNumber, costKm, 0d, status, type)
        {
        }

        public Car(int id, string make, string registrationNumber, double odometer, double costKm, VehicleTypes type)
            : this(id, make, registrationNumber, odometer, costKm, VehicleStatuses.Available, type)
        {
        }

        public Car(int id, string make, string registrationNumber, double costKm, VehicleTypes type)
            : this(id, make, registrationNumber, costKm, 0d, VehicleStatuses.Available, type)
        {
        }
    }
}
