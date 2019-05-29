using System;
using System.Collections.Generic;
using System.Text;
using garageLogic;

namespace Ex03.GarageLogic
{
    public class UserInterface
    {
        private string m_MenuMassage;
        private StringBuilder m_CarChoiceMassage;
        private GarageDataBase m_data;

        public void MainRuning(GarageDataBase i_Database)
        {
            int choice;
            bool isTheProgramEnd = false;

            m_data = i_Database;
            buildMenuMessage();
            buildCarChoice();

            while (!isTheProgramEnd)
            {
                printTheMenu();
                choice = (int)getInputNumberByRange(" ", (int)Utilities.eOthers.ONE, (int)Utilities.eOthers.EIGHT);
                switch (choice)
                {
                    case 1:
                        insertNewVehicle();
                        break;
                    case 2:
                        printLicenceIDsOfVehicleInTheGarage();
                        System.Threading.Thread.Sleep(2000);
                        break;
                    case 3:
                        changeCarStatus();
                        break;
                    case 4:
                        inflateTheMaximumAirOfAVehicle();
                        break;
                    case 5:
                        refuelVehicle();
                        break;
                    case 6:
                        rechargeVehicle();
                        break;
                    case 7:
                        ShowDataOfACar();
                        break;
                    case 8:
                        isTheProgramEnd = true;
                        break;
                }
                WaitForSignal();
            }
        }

        private void WaitForSignal()
        {
            Console.WriteLine("End Process. Press Enter to continue...");
            Console.ReadLine();
        }

        private void rechargeVehicle()
        {
            float amountOfFuel;
            string licensePlateOfCarToCharge;

            licensePlateOfCarToCharge = getString("Enter the license plate of the car that you want to charge:");
            amountOfFuel = getInputNumberByRange("Enter amount of energy:", (int)Utilities.eOthers.ZERO, (int)Utilities.eOthers.MAX_FUEL);

            try
            {
                m_data.Recharge(licensePlateOfCarToCharge, amountOfFuel);
            }
            catch (ValueOutOfRangeException tooMuchEnergyToAdd)
            {
                Console.WriteLine(tooMuchEnergyToAdd.Message);
            }

            System.Threading.Thread.Sleep(1500);
        }

        private void refuelVehicle()
        {
            string messageToGetFuel;
            string licensePlateOfCarToFuel;
            float amountOfFuel;
            Utilities.eFuelType fuelType;

            messageToGetFuel = string.Format("Choose type of fuel please: {0} 1.Octan95 {0} 2.Octan96 {0} 3. Octan98 {0} 4. Soler", Environment.NewLine);

            licensePlateOfCarToFuel = getString("Enter the license plate of the car that you want to fuel:");
            amountOfFuel = getInputNumberByRange("Enter amount of energy:", (int)Utilities.eOthers.ZERO, (int)Utilities.eOthers.MAX_FUEL);
            fuelType = (Utilities.eFuelType)(int)getInputNumberByRange(messageToGetFuel, (int)Utilities.eOthers.ONE, (int)Utilities.eOthers.FOUR);

            try
            {
                m_data.Refuel(licensePlateOfCarToFuel, amountOfFuel, fuelType);
            }
            catch (ArgumentException AE)
            {
                Console.WriteLine(AE.Message);
            }

            System.Threading.Thread.Sleep(1500);
        }

        private void inflateTheMaximumAirOfAVehicle()
        {
            string licensePlate;
            Console.Clear();
            Console.WriteLine("Write license plate of the car you want to inflate air pressure:");
            licensePlate = Console.ReadLine();
            try
            {
                m_data.TryInflateCarAirPressure(licensePlate);
            }
            catch (ArgumentException AE)
            {
                Console.WriteLine(AE.Message);
                System.Threading.Thread.Sleep(1500);
            }
        }

        private void changeCarStatus()
        {
            string licensePlate;
            Utilities.eCarCondition newCarCOndition;
            string messageForGettingCarSituation;

            Console.Clear();
            licensePlate = getString("Write license plate of the car you want to change");

            messageForGettingCarSituation = string.Format("Choose mode of cars that you want to see: {0} 1. In Fix {0} 2. Fixed {0} 3. Paid", System.Environment.NewLine);

            newCarCOndition = (Utilities.eCarCondition)getInputNumberByRange(messageForGettingCarSituation, (int)Utilities.eOthers.ONE, (int)Utilities.eOthers.FOUR);

            try
            {
                m_data.TryChangeCarStatus(licensePlate, newCarCOndition);
            }
            catch (ArgumentException AE)
            {
                Console.WriteLine(AE.Message);
                System.Threading.Thread.Sleep(1500);
            }
        }

        private void insertNewVehicle()
        {
            int choice;

            printTheCarOption();
            choice = (int)getInputNumberByRange("choose one of the vehicles above", (int)Utilities.eOthers.ONE, (int)Utilities.eVehicleType.amountOfCarType);
            createNewVehicleByType(choice);
        }

        private void createNewVehicleByType(int i_Choice)
        {
            Vehicle newVehicle = VehicleFactory.CreateNewVehicleByType(i_Choice);
            switch ((Utilities.eVehicleType)i_Choice)
            {
                case Utilities.eVehicleType.Motorcycle:
                    setMotorcycleInfo(newVehicle);
                    break;
                case Utilities.eVehicleType.ElectricMotorcycle:
                    setMotorcycleInfo(newVehicle);
                    break;
                case Utilities.eVehicleType.Car:
                    setCarInformation(newVehicle);
                    break;
                case Utilities.eVehicleType.ElectricCar:
                    setCarInformation(newVehicle);
                    break;
                default:
                    setTruckInfo(newVehicle);
                    break;
            }

            setGeneralInfoVehicle(newVehicle);
            addToDataBase(newVehicle);
        }

        private void addToDataBase(Vehicle i_VehicleToAddData)
        {
            string name;
            string phone;
            getCostumerInfo(out name, out phone);

            m_data.AddToData(name, phone, i_VehicleToAddData);
        }

        private void getCostumerInfo(out string io_Name, out string io_Phone)
        {
            io_Name = getString("Write your name:");
            io_Phone = getString("Write your Phone:");
        }

        private void setGeneralInfoVehicle(Vehicle i_VehicleToUpDate)
        {
            string nameModel;
            string licensePlate;
            float LeftEnergy;
            string WheelManufacturer;
            float CurrentWheelAirPressure;

            getInfoOnVehicle(out nameModel, out licensePlate, out LeftEnergy, out WheelManufacturer,
                out CurrentWheelAirPressure, i_VehicleToUpDate.MaximumAirPressure);

            i_VehicleToUpDate.ModelName = nameModel;
            i_VehicleToUpDate.LicencePlate = licensePlate;
            try
            {
                i_VehicleToUpDate.LeftEnergy = LeftEnergy;
                i_VehicleToUpDate.SetAirpressureAndWheelManufacture(CurrentWheelAirPressure, WheelManufacturer);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            
        }

        private void setCarInformation(Vehicle i_VehicleToUpDate)
        {
            Utilities.eColor carColor;
            Utilities.eNumOfDoors numOfDoorsOfCar;
            string messageForInput = string.Format("Choose a number for your car color: {0} 1. Red {0} 2. Blue {0} 3. Black {0} 4. Gray {0}", System.Environment.NewLine);

            carColor = (Utilities.eColor)getInputNumberByRange(messageForInput, (int)Utilities.eOthers.ONE, (int)Utilities.eOthers.FOUR);
            numOfDoorsOfCar = (Utilities.eNumOfDoors)getInputNumberByRange("Choose a number between 2 - 5 for your car's number of doors", (int)Utilities.eOthers.TWO, (int)Utilities.eOthers.FIVE);

            ((Car)i_VehicleToUpDate).CarColor = carColor;
            ((Car)i_VehicleToUpDate).NumOfDoors = numOfDoorsOfCar;
        }

        private void setMotorcycleInfo(Vehicle i_VehicleToUpDate)
        {
            string message = string.Format("Choose a number for engine: {0} 1. A {0} 2. A1 {0} 3. A2 {0} 4. B {0}", System.Environment.NewLine);
            Utilities.eLicensetype LicenseType = (Utilities.eLicensetype)getInputNumberByRange(message, (int)Utilities.eOthers.ONE, (int)Utilities.eOthers.FOUR);

            int EngineCapacity = getNumber("Write engine capacity");
            ((Motorcycle)i_VehicleToUpDate).LicenseType = LicenseType;
            ((Motorcycle)i_VehicleToUpDate).EngineCapacity = EngineCapacity;
        }

        private void setTruckInfo(Vehicle i_VehicleToUpDate)
        {
            bool isDeliverDangerMaterial;
            float VolumeOfCargo;

            isDeliverDangerMaterial = checkWithUserIfDeliverDangerMaterial();
            VolumeOfCargo = (float)getInputNumberByRange("Write Cargo Volume:", (int)Utilities.eOthers.ZERO, (int)Utilities.eOthers.MAX_FUEL);

            ((Truck)i_VehicleToUpDate).IsDeliverDangerMaterial = isDeliverDangerMaterial;
            ((Truck)i_VehicleToUpDate).VolumeOfCargo = VolumeOfCargo;
        }

        private bool checkWithUserIfDeliverDangerMaterial()
        {
            string stringUserChoise;
            stringUserChoise = getString("Write y if there are danger material else write n");
            bool isHavingDangerousStuff;

            while ((stringUserChoise != Utilities.Constants.yes) && (stringUserChoise != Utilities.Constants.no) &&
                (stringUserChoise != Utilities.Constants.yesInCapitalLetter) && (stringUserChoise != Utilities.Constants.noInCapitalLetter))
            {
                stringUserChoise = getString("InvalidInput");
            }

            isHavingDangerousStuff = ((stringUserChoise == Utilities.Constants.yes) ||
                (stringUserChoise == Utilities.Constants.yesInCapitalLetter));

            return isHavingDangerousStuff;
        }

        private float getInputNumberByRange(string i_Prompt, int i_FromRange, float i_ToRange)
        {
            string inputInString;
            bool isSucceeded;
            Console.WriteLine(i_Prompt);
            inputInString = Console.ReadLine();
            float resNumber;

            manageToParse(inputInString, out resNumber, i_Prompt);

            while ((resNumber < i_FromRange) || (resNumber > i_ToRange))
            {
                Console.WriteLine("Invalid input. Check if your number is between {0} to {1}.", i_FromRange, i_ToRange);
                inputInString = Console.ReadLine();
                isSucceeded = float.TryParse(inputInString, out resNumber);
                Console.Clear();
            }
            return resNumber;
        }

        private void manageToParse(string i_InputInString, out float io_ResNumber, string i_Prompt)
        {
            bool isValidInput = false;
            io_ResNumber = 0;

            while (!isValidInput)
            {
                try
                {
                    io_ResNumber = tryParsing(i_InputInString);
                    isValidInput = true;
                }

                catch (FormatException notAnumber)
                {
                    Console.WriteLine(notAnumber.Message);
                    i_InputInString = Console.ReadLine();
                }
            }
        }

        private float tryParsing(string i_InputInString)
        {
            bool isSucceeded;
            float resNumber;

            isSucceeded = float.TryParse(i_InputInString, out resNumber);

            if (!isSucceeded)
            {
                throw new FormatException("Must be a number, try writing a number again:");
            }

            else
            {
                return resNumber;
            }
        }

        private string getString(string i_Prompt)
        {
            string outputString;

            Console.WriteLine(i_Prompt);
            outputString = Console.ReadLine();

            return outputString;
        }

        private int getNumber(string i_Prompt)
        {
            int choice;
            string UserChoise;
            bool IsItParse;

            Console.WriteLine(i_Prompt);
            UserChoise = Console.ReadLine();

            IsItParse = int.TryParse(UserChoise, out choice);

            while (!IsItParse)
            {
                Console.WriteLine("Please enter a valid number.");
                UserChoise = Console.ReadLine();
                IsItParse = int.TryParse(UserChoise, out choice);
            }

            return choice;
        }

        private void getInfoOnVehicle(
            out string io_NameModel, out string io_LicensePlate, out float io_LeftEnergy,
            out string io_WheelManufacturer, out float io_CurrentWheelAirPressure,
            float i_MaximumWheelAirPressure)//replace in user inerface
        {
            io_NameModel = getString("write model");

            io_LicensePlate = getString("License Plate Number:");

            io_LeftEnergy = getInputNumberByRange("Left Energy:", (int)Utilities.eOthers.ZERO, (int)Utilities.eOthers.HUNDRED);

            io_WheelManufacturer = getString("Wheel Manufacturer:");

            io_CurrentWheelAirPressure = getInputNumberByRange("Current Air Pressure:", (int)Utilities.eOthers.ZERO, i_MaximumWheelAirPressure);
        }

        private void printTheCarOption()
        {
            Console.Clear();
            Console.WriteLine(m_CarChoiceMassage);
        }

        private void buildCarChoice()
        {
            m_CarChoiceMassage = new StringBuilder();
            int amountOfCarType = (int)garageLogic.Utilities.eVehicleType.amountOfCarType;

            for (int i = 0; i < amountOfCarType; ++i)
            {
                m_CarChoiceMassage.Append(string.Format("{0}. {1} {2}", i + 1, (garageLogic.Utilities.eVehicleType)i + 1, Environment.NewLine));
            }

        }

        private void buildMenuMessage()
        {
            string optionOne, optionTwo, optionThree, optionFour, optionFive, optionSix, optionSeven, ExitOption;
            string menuTitle;

            optionOne = "Insert A new vehicle To The Garage";
            optionTwo = "Show the Licence ID's of the vehicle in the garage";
            optionThree = "Change car status";
            optionFour = "To inflate the maximum air of a vehicle";
            optionFive = "To refuel a vehicle";
            optionSix = "To recharge a vehicle";
            optionSeven = "Show data of a car";
            ExitOption = "Exit";
            menuTitle = string.Format(@"
  __  __ ______ _   _ _    _ 
 |  \/  |  ____| \ | | |  | |
 | \  / | |__  |  \| | |  | |
 | |\/| |  __| | . ` | |  | |
 | |  | | |____| |\  | |__| |
 |_|  |_|______|_| \_|\____/ 
");
            m_MenuMassage = string.Format(@"{9}{0}Please select one of the options below:{0}
1. {1}{0}2. {2}{0}3. {3}{0}4. {4}{0}5. {5}{0}6. {6}{0}7. {7}{0}8. {8}", Environment.NewLine,
                                optionOne, optionTwo, optionThree, optionFour, optionFive, optionSix, optionSeven, 
                                ExitOption, menuTitle);
        }

        private void printTheMenu()
        {
            Console.Clear();
            Console.WriteLine(m_MenuMassage);
        }

        private void printLicenceIDsOfVehicleInTheGarage()
        {
            string messageForGettingCarSituation;
            Utilities.eCarCondition carSituationRequested;

            messageForGettingCarSituation = string.Format("Choose mode of cars that you want to see: {0} 1. In Fix {0} 2. Fixed {0} 3. Paid", System.Environment.NewLine);

            carSituationRequested = (Utilities.eCarCondition)getInputNumberByRange(messageForGettingCarSituation, (int)Utilities.eOthers.ONE, (int)Utilities.eOthers.FOUR);

            List<OwnerDetails> copiedListToModify = m_data.ModifyListBySituation(carSituationRequested);

            printList(copiedListToModify);
        }

        private void printList(List<OwnerDetails> i_ListToPrint)
        {
            if (i_ListToPrint.Count == 0) // there are no cars in garage
            {
                Console.WriteLine("There are no cars in garage in this situation ");
            }
            else
            {
                Console.WriteLine("Cars in the garage in this situation:{0}", System.Environment.NewLine);
                foreach (OwnerDetails owner in i_ListToPrint)
                {
                    Console.WriteLine("{0}", owner.Vehicle.LicencePlate);
                }

                Console.WriteLine();
            }
        }

        public void ShowDataOfACar()
        {
            StringBuilder info = new StringBuilder();

            string licensePlate = getString("Write down the license plate of the car you want to see");

            try
            {
                m_data.GetVehicleInfo(licensePlate, ref info);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                System.Threading.Thread.Sleep(1500);
            }

            Console.WriteLine(info);
        }
    }
}
