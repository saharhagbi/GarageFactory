using System;
using System.Collections.Generic;
using System.Text;

namespace garageLogic
{
    public class Car : Vehicle
    {
        private Utilities.eColor m_CarColor;
        private Utilities.eNumOfDoors m_NumOfDoors;

        public Car() :
            base((int)Utilities.eNumOfWheels.FOR_CAR, Utilities.ElectricCarMaximumEnergyCapacity, (int)Utilities.eMaxAirPressure.FOR_CAR)
        {
        }

        public Car(Utilities.eFuelType i_fuelType) :
            base((int)Utilities.eNumOfWheels.FOR_CAR, i_fuelType, Utilities.ReqularCarMaximumEnergyCapacity, (int)Utilities.eMaxAirPressure.FOR_CAR)
        {
        }

        public Utilities.eColor CarColor
        {
            set { m_CarColor = value; }
        }

        public Utilities.eNumOfDoors NumOfDoors
        {
            set { m_NumOfDoors = value; }
        }

        public override void getInformation(ref StringBuilder io_CarInfo)
        {
            string messageCar = Enum.GetName(typeof(Utilities.eVehicleType), (int)Utilities.eVehicleType.Car);

            io_CarInfo.Append(string.Format("{3} Info{0} Color: {1}{0} Amount of doors: {2}{0}", Environment.NewLine,
                m_CarColor, m_NumOfDoors, messageCar));

            VehicelInfo(ref io_CarInfo);
        }
    }
}
