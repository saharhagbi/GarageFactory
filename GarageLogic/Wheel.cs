using System;
using System.Collections.Generic;
using System.Text;

namespace garageLogic
{
    public class Wheel
    {
        private readonly float r_MaximumAirPressure;
        private string m_Name;
        private float m_CurrentAirPressure;

        public Wheel(float i_MaximumAirPressure)
        {
            r_MaximumAirPressure = i_MaximumAirPressure;
        }

        public string WheelManufacturer
        {
            set { m_Name = value; }
        }

        public float MaximumAirPressure///////addd To Wheel Class
        {
            get { return r_MaximumAirPressure; }
        }

        public float CurrentWheelAirPressure
        {
            set { m_CurrentAirPressure = value; }
        }

        public void InflateTheMaximumAirPressure()
        {
            m_CurrentAirPressure = r_MaximumAirPressure;
        }

        public void GetWheelInfo(ref StringBuilder o_WheelInfo)
        {
            o_WheelInfo.Append(string.Format("Wheel Info:{0}Manifacture Name: {1}{0}Maximum air Pressure: {2}{0}Current air Pressure: {3}{0}"
                , Environment.NewLine, m_Name, r_MaximumAirPressure, m_CurrentAirPressure));
        }
    }
}