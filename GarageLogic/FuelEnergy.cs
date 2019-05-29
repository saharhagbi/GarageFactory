using System;
using System.Collections.Generic;
using System.Text;

namespace garageLogic
{
    public class FuelEnergy : EnergySource
    {
        private readonly Utilities.eFuelType r_FuelType;

        public FuelEnergy(float i_MaximumOfCapacityEnergy, Utilities.eFuelType i_FuelType)
            : base(i_MaximumOfCapacityEnergy)
        {
            r_FuelType = i_FuelType;
        }

        public void ReFuel(float i_FuelToAdd, Utilities.eFuelType i_FuelType)
        {
            if (r_FuelType == i_FuelType)
            {
                try
                {
                    base.addEnergy(i_FuelToAdd);
                }
                catch (ValueOutOfRangeException toomuchEnergyToAdd)
                {
                    Console.WriteLine(toomuchEnergyToAdd.Message);
                }
            }
            else
            {
                throw new ArgumentException("The fuel type is not much to the Vehicle's fuel type");
            }
        }

        public override void EnergySourceInfo(ref StringBuilder o_EnergySourceFuelInfo)
        {
            string messageForFuelType = Enum.GetName(typeof(Utilities.eFuelType), r_FuelType);

            o_EnergySourceFuelInfo.Append(string.Format("Engine Info:{0}Maximum Fuel Capacity: {1}{0}Current Amount Fuel:{2} Litters{0}Fuel Type: {3}{0}",
            Environment.NewLine, r_MaximumOfCapacityEnergy, m_CurrentAmountOfEnergy, messageForFuelType));
        }
    }
}
