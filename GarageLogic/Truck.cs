using System;
using System.Collections.Generic;
using System.Text;

namespace garageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsDeliverDangerMaterial;
        private float m_VolumeOfCargo;

        public Truck(Utilities.eFuelType i_FuelType) :
            base((int)Utilities.eNumOfWheels.FOR_TRUCK, i_FuelType,
                Utilities.TruckMaximumEnergyCapacity, (int)Utilities.eMaxAirPressure.FOR_TRUCK)
        {
        }

        public bool IsDeliverDangerMaterial
        {
            set { m_IsDeliverDangerMaterial = value; }
        }

        public float VolumeOfCargo
        {
            set { m_VolumeOfCargo = value; }
        }

        public override void getInformation(ref StringBuilder io_TruckInfo)
        {
            string messageTruck = Enum.GetName(typeof(Utilities.eVehicleType), (int)Utilities.eVehicleType.Truck);

            if (m_IsDeliverDangerMaterial)
            {
                io_TruckInfo.Append(string.Format("{3} Info:{0}Deliver danger material{0}Cargo Volume: {1}{0}",
                    Environment.NewLine, m_VolumeOfCargo, messageTruck));
            }
            else
            {
                io_TruckInfo.Append(string.Format("{3} Info:{0}Doesn't deliver danger material{0}Cargo Volume: {1}{0}",
                     Environment.NewLine, m_VolumeOfCargo, messageTruck));
            }

            VehicelInfo(ref io_TruckInfo);
        }
    }
}
