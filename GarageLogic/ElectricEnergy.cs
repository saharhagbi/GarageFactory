using System;
using System.Collections.Generic;
using System.Text;

namespace garageLogic
{
    public class ElectricEnergy : EnergySource
    {
        public ElectricEnergy(float i_MaximumOfCapacityEnergy) : base(i_MaximumOfCapacityEnergy) { }

        public void Recharge(float i_ElectricToFill)
        {
            try
            {
                base.addEnergy(i_ElectricToFill);
            }
            catch (ValueOutOfRangeException tooMuchEnergyToAdd)
            {
                Console.WriteLine(tooMuchEnergyToAdd.Message);
            }
        }

        public override void EnergySourceInfo(ref StringBuilder o_EnergySourceElectricInfo)
        {
            o_EnergySourceElectricInfo.Append(
                string.Format("Engine Info: {0}Maximum Capacity: {1},{0}Current Amount: {2} Hours Left{0}",
                Environment.NewLine, r_MaximumOfCapacityEnergy, m_CurrentAmountOfEnergy));
        }
    }
}
