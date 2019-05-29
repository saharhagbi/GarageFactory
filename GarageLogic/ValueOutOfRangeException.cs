using System;
using System.Collections.Generic;
using System.Text;

namespace garageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;

        public ValueOutOfRangeException(string i_Message, float i_MaxValue, float i_MinValue)
    : base(i_Message)
        {
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
        }


        public float HowMuchMoreEnergy
        {
            get { return r_MaxValue; }
        }

        public float MinValue
        {
            get { return r_MinValue; }
        }
    }
}

