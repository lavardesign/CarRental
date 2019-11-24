using System;
using System.Collections.Generic;
using System.Text;
using CarRental.Common.Enums;

namespace CarRental.Common.Interfaces
{
    public interface IVehicle
    {
        int Id { get; }
        string Make { get; }
        string RegistrationNumber { get; }
        double Odometer { get; }
        double CostKm { get; }
        double CostDay { get; }

        VehicleStatuses Status { get; set; }
        VehicleTypes Type { get; }

        void Drive(double distance);
    }
}
