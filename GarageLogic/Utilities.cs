using System;
using System.Collections.Generic;
using System.Text;

namespace garageLogic
{
    public class Utilities
    {
        public enum eColor
        {
            RED = 0,
            BLUE = 1,
            BLACK = 2,
            GRAY = 3
        }

        public enum eCarCondition
        {
            IN_FIX = 1,
            FIXED = 2,
            PAID = 3,
            AmountOfCarCondition = 4
        }

        public enum eFuelType
        {
            Octan95 = 1,
            Octan96 = 2,
            Octan98 = 3,
            Soler = 4
        }

        public enum eVehicleType
        {
            Motorcycle = 1,
            ElectricMotorcycle = 2,
            Car = 3,
            ElectricCar = 4,
            Truck = 5,
            amountOfCarType = 5
        }

        public enum eLicensetype
        {
            A = 1,
            A1 = 2,
            A2 = 3,
            B = 4
        }

        public enum eEnergyType
        {
            Electric = 0,
            Fuel = 1
        }

        public enum eNumOfWheels
        {
            FOR_MOTORCYCLE = 2,
            FOR_CAR = 4,
            FOR_TRUCK = 12
        }

        public enum eMaxAirPressure
        {
            FOR_MOTORCYCLE = 33,
            FOR_CAR = 31,
            FOR_TRUCK = 26
        }

        public enum eNumOfDoors
        {
            TWO = 2,
            THREE = 3,
            FOUR = 4,
            FIVE = 5
        }

        public enum eOthers
        {
            ZERO = 0,
            ONE = 1,
            TWO = 2,
            FOUR = 4,
            FIVE = 5,
            EIGHT = 8,
            HUNDRED = 100,
            MAX_FUEL = 110
        }

        public static float ReqularMotorcycleMaximumEnergyCapacity
        {
            get { return 8; }
        }

        public static float ElectricMotorcycleMaximumEnergyCapacity
        {
            get { return 1.4f; }
        }

        public static float ReqularCarMaximumEnergyCapacity
        {
            get { return 55; }
        }

        public static float ElectricCarMaximumEnergyCapacity
        {
            get { return 1.8f; }
        }

        public static float TruckMaximumEnergyCapacity
        {
            get { return 110; }
        }

        public class Constants
        {
            public const string yesInCapitalLetter = "y";
            public const string yes = "y";
            public const string noInCapitalLetter = "n";
            public const string no = "n";
        }
    }
}
