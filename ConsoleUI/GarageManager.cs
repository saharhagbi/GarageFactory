using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        public static void RunProgram()
        {
            garageLogic.GarageDataBase garageDataBase = new garageLogic.GarageDataBase();
            UserInterface userInterface = new UserInterface();
            userInterface.MainRuning(garageDataBase);
        }
    }
}
