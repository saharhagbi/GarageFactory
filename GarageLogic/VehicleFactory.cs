using System;
using System.Collections.Generic;
using System.Text;

namespace garageLogic
{
    public class VehicleFactory
    {
        public static Vehicle CreateNewVehicleByType(int i_choice)
        {
            Vehicle newVehicle;
            switch ((Utilities.eVehicleType)i_choice)
            {
                case Utilities.eVehicleType.Motorcycle:
                    newVehicle = new Motorcycle(Utilities.eFuelType.Octan95);
                    break;
                case Utilities.eVehicleType.ElectricMotorcycle:
                    newVehicle = new Motorcycle();
                    break;
                case Utilities.eVehicleType.Car:
                    newVehicle = new Car(Utilities.eFuelType.Octan96);
                    break;
                case Utilities.eVehicleType.ElectricCar:
                    newVehicle = new Car();
                    break;
                default:
                    newVehicle = new Truck(Utilities.eFuelType.Soler);
                    break;
            }

            return newVehicle;
        }
    }
}
