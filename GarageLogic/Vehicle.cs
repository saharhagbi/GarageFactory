using System;
using System.Collections.Generic;
using System.Text;

namespace garageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicencePlate;
        private List<Wheel> m_Wheels;
        private EnergySource m_Engine;

        public Vehicle(int i_AmountOfWheels,
            Utilities.eFuelType i_FuelType, float i_MaximumOfCapacityEnergy, float i_MaximumAirPressure)
        {
            createAListOfWheels(i_AmountOfWheels, i_MaximumAirPressure);
            m_Engine = new FuelEnergy(i_MaximumOfCapacityEnergy, i_FuelType);
        }

        public Vehicle(int i_AmountOfWheels, float i_MaximumOfCapacityEnergy, float i_MaximumAirPressure)
        {
            createAListOfWheels(i_AmountOfWheels, i_MaximumAirPressure);
            m_Engine = new ElectricEnergy(i_MaximumOfCapacityEnergy);
        }

        private void createAListOfWheels(int i_AmountOfWheels, float i_MaximumAirPressure)
        {
            m_Wheels = new List<Wheel>(i_AmountOfWheels);
            for (int i = 0; i < i_AmountOfWheels; ++i)
            {
                createAListOfWheel(i_MaximumAirPressure);
            }
        }

        private void createAListOfWheel(float i_MaximumAirPressure)
        {
            Wheel wheel = new Wheel(i_MaximumAirPressure);
            m_Wheels.Add(wheel);
        }

        public string ModelName
        {
            set { m_ModelName = value; }
        }

        public string LicencePlate
        {
            get { return m_LicencePlate; }
            set { m_LicencePlate = value; }
        }

        public float LeftEnergy
        {
            set
            {
                if(value <= 100 && value >= 0)
                {
                    m_Engine.LeftEnergy = value * m_Engine.MaximumCapacity / 100;
                }
                else
                {
                    throw new ArgumentException("The amount of Energy need to set by precent!");
                }
             }
        }

        public float MaximumCapacity
        {
            get { return m_Engine.MaximumCapacity; }
        }

        public float MaximumAirPressure
        {
            get { return m_Wheels[0].MaximumAirPressure; }
        }

        public void SetAirpressureAndWheelManufacture(float i_CurrentWheelAirPressure, string i_WheelManufacturer)
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.CurrentWheelAirPressure = i_CurrentWheelAirPressure;
                wheel.WheelManufacturer = i_WheelManufacturer;
            }
        }

        public void InflateTheMaximumAirPressure()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.InflateTheMaximumAirPressure();
            }
        }

        public void ChargeCar(float i_AmountOfFuel)
        {
            if (this.m_Engine is ElectricEnergy)
            {
                ((ElectricEnergy)m_Engine).Recharge(i_AmountOfFuel);
            }
            else
            {
                throw new ArgumentException("This is not a electric car!");
            }
        }

        public void RefuelCar(float i_AmountOfFuel, Utilities.eFuelType i_FuelType)
        {
            if (this.m_Engine is FuelEnergy)
            {
                try
                {
                    ((FuelEnergy)m_Engine).ReFuel(i_AmountOfFuel, i_FuelType);
                }
                catch (ArgumentException AE)
                {
                    Console.WriteLine(AE.Message);
                }
            }
            else
            {
                throw new ArgumentException("This is not a electric car!");
            }
        }

        public abstract void getInformation(ref StringBuilder io_VehicelInfo);

        public void VehicelInfo(ref StringBuilder o_VehicelInfo)
        {
            o_VehicelInfo.Append(string.Format("Model name: {1},{0}Licence Plate: {2}{0}"
                , Environment.NewLine, m_ModelName, m_LicencePlate));
            m_Engine.EnergySourceInfo(ref o_VehicelInfo);
            Console.WriteLine(m_Wheels.Count);
            m_Wheels[0].GetWheelInfo(ref o_VehicelInfo);
        }
    }
}
