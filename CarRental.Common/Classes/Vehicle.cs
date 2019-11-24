using System;
using System.Collections.Generic;
using System.Text;
using CarRental.Common.Enums;
using CarRental.Common.Interfaces;

namespace CarRental.Common.Classes
{
    public abstract class Vehicle : IVehicle
    {

        public int Id { get; }

        public string Make { get; }

        public string RegistrationNumber { get; }

        public double Odometer { get; private set; }

        public double CostKm { get; }

        public VehicleStatuses Status { get; set; }

        public VehicleTypes Type { get; }

        public void Drive(double distance) => Odometer += distance;

        public double CostDay
        {
            get => Type switch
            {
                VehicleTypes.Sedan => 100,
                VehicleTypes.Combi => 200,
                VehicleTypes.Van => 300,
                VehicleTypes.Motorcycle => 50,
                _ => throw new InvalidOperationException("Vehicle type unavailable")
            };
        }

        protected Vehicle(int id, string make, string registrationNumber, double odometer, double costKm, VehicleStatuses status, VehicleTypes type)
        {
            Id = id;
            Make = make;
            RegistrationNumber = registrationNumber;
            Odometer = odometer;
            CostKm = costKm;
            Status = status;
            Type = type;
        }
    }
}
