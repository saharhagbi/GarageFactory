using System;
using System.Collections.Generic;
using System.Text;

namespace garageLogic
{
    public abstract class EnergySource
    {
        protected readonly float r_MaximumOfCapacityEnergy;
        protected float m_CurrentAmountOfEnergy;

        public EnergySource(float i_MaximumOfCapacityEnergy)
        {
            r_MaximumOfCapacityEnergy = i_MaximumOfCapacityEnergy;
        }

        public float LeftEnergy
        {
            set { m_CurrentAmountOfEnergy = value; }
        }

        public float MaximumCapacity
        {
            get { return r_MaximumOfCapacityEnergy; }
        }

        protected void addEnergy(float i_FuelToAdd)
        {
            if (i_FuelToAdd + m_CurrentAmountOfEnergy <= r_MaximumOfCapacityEnergy)
            {
                m_CurrentAmountOfEnergy = i_FuelToAdd + m_CurrentAmountOfEnergy;
            }
            else
            {
                string message = string.Format("Too much energy to add. Should be between {0} - {1}",
                    m_CurrentAmountOfEnergy, (this.MaximumCapacity - m_CurrentAmountOfEnergy));
                throw new ValueOutOfRangeException(message, m_CurrentAmountOfEnergy, this.MaximumCapacity);
            }
        }

        public abstract void EnergySourceInfo(ref StringBuilder o_EnergySourceInfo);
    }
}
