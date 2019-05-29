using System;
using System.Collections.Generic;
using System.Text;

namespace garageLogic
{
    public class Motorcycle : Vehicle
    {
        private float m_EngineCapacity;
        private Utilities.eLicensetype m_LicenseType;

        public Motorcycle() :
            base((int)Utilities.eNumOfWheels.FOR_MOTORCYCLE, Utilities.ElectricMotorcycleMaximumEnergyCapacity, (int)Utilities.eMaxAirPressure.FOR_MOTORCYCLE)
        {
        }

        public Motorcycle(Utilities.eFuelType i_FuelType) :
            base((int)Utilities.eNumOfWheels.FOR_MOTORCYCLE, i_FuelType,
                Utilities.ReqularMotorcycleMaximumEnergyCapacity, (int)Utilities.eMaxAirPressure.FOR_MOTORCYCLE)
        {
        }

        public Utilities.eLicensetype LicenseType
        {
            set { m_LicenseType = value; }
        }

        public int EngineCapacity
        {
            set { m_EngineCapacity = value; }
        }

        public override void getInformation(ref StringBuilder io_MotorcycleInfo)
        {
            string messageMotorCycle = Enum.GetName(typeof(Utilities.eVehicleType), (int)Utilities.eVehicleType.Motorcycle);

            io_MotorcycleInfo.Append(string.Format("{3} Info:{0}{0}Engine capacity: {1}{0}License type: {2}{0}",
                Environment.NewLine, m_EngineCapacity, m_LicenseType, messageMotorCycle));
            VehicelInfo(ref io_MotorcycleInfo);
        }
    }
}
