using System;
using System.Collections.Generic;
using System.Text;

namespace garageLogic
{
    public class GarageDataBase
    {
        private List<OwnerDetails> m_AllVehicleInTheGarage = new List<OwnerDetails>();

        public List<OwnerDetails> getListOfOwnerDetails
        {
            get
            { return m_AllVehicleInTheGarage; }
        }

        public void AddToData(string i_Name, string i_Phone, Vehicle i_VehicleToAddData)
        {
            int VehicleIndexInList = findVehicleInList(i_VehicleToAddData.LicencePlate);

            if (VehicleIndexInList == -1)
            {
                m_AllVehicleInTheGarage.Add(new OwnerDetails(i_Name, i_Phone, i_VehicleToAddData));
            }
            else
            {
                m_AllVehicleInTheGarage[VehicleIndexInList].CarCondition = Utilities.eCarCondition.IN_FIX;
            }

            Console.WriteLine("check");
        }

        public int findVehicleInList(string i_LicencePlate)
        {
            int loopIndex = 0;
            int indexWanted = 0;
            bool isIndexFound = false;

            foreach (OwnerDetails ownerDetails in m_AllVehicleInTheGarage)
            {
                if (ownerDetails.Vehicle.LicencePlate == i_LicencePlate)
                {
                    isIndexFound = true;
                    indexWanted = loopIndex;
                }

                loopIndex++;
            }

            if (!isIndexFound)
            {
                indexWanted = -1;
            }

            return indexWanted;
        }

        public void TryChangeCarStatus(string i_LicencePlate, Utilities.eCarCondition i_newCarCOndition)
        {
            getVehicleToChangeInfo(i_LicencePlate).CarCondition = i_newCarCOndition;
        }

        public void TryInflateCarAirPressure(string i_LicencePlate)
        {
            getVehicleToChangeInfo(i_LicencePlate).Vehicle.InflateTheMaximumAirPressure();
        }

        private OwnerDetails getVehicleToChangeInfo(string i_LicencePlate)
        {
            int VehicleIndexInList = findVehicleInList(i_LicencePlate);

            if (VehicleIndexInList > -1)
            {
                return m_AllVehicleInTheGarage[VehicleIndexInList];
            }
            else
            {
                throw new ArgumentException("There isn't such car in the garage!");
            }
        }

        public List<OwnerDetails> ModifyListBySituation(Utilities.eCarCondition i_carConditionRequested)
        {
            List<OwnerDetails> copiedListToModify = new List<OwnerDetails>();

            foreach (OwnerDetails owner in m_AllVehicleInTheGarage)
            {
                if (owner.CarCondition == i_carConditionRequested)
                {
                    copiedListToModify.Add(owner);
                }
            }

            return copiedListToModify;
        }

        public void Recharge(string i_licensePlateOfCarToCharge, float i_amountOfFuel)
        {
            try
            {
                rechargeHelper(i_licensePlateOfCarToCharge, i_amountOfFuel);
            }
            catch (ArgumentException AE)
            {
                Console.WriteLine(AE.Message);
            }
        }

        private void rechargeHelper(string i_licensePlateOfCarToCharge, float i_amountOfFuel)
        {
            int indexCarByPlate = findVehicleInList(i_licensePlateOfCarToCharge);

            if (indexCarByPlate > -1)
            {
                m_AllVehicleInTheGarage[indexCarByPlate].Vehicle.ChargeCar(i_amountOfFuel);
            }
            else
            {
                throw new ArgumentException("There is not such car!");
            }
        }

        public void Refuel(string i_licensePlateOfCarToCharge, float i_amountOfFuel, Utilities.eFuelType i_fuelType)
        {
            try
            {
                refuelHelper(i_licensePlateOfCarToCharge, i_amountOfFuel, i_fuelType);
            }
            catch (ArgumentException AE)
            {
                Console.WriteLine(AE);
            }
        }

        private void refuelHelper(string i_licensePlateOfCarToCharge, float i_amountOfFuel, Utilities.eFuelType i_FuelType)
        {
            int indexCarByPlate = findVehicleInList(i_licensePlateOfCarToCharge);

            if (indexCarByPlate > -1)
            {
                m_AllVehicleInTheGarage[indexCarByPlate].Vehicle.RefuelCar(i_amountOfFuel, i_FuelType);
            }
            else
            {
                throw new ArgumentException("There is not such car!");
            }
        }

        private void getVehicelInfoHelper(string i_licensePlat, ref StringBuilder o_MessageWithTheInfo)
        {
            int VehicelToFindInfo = findVehicleInList(i_licensePlat);

            if (VehicelToFindInfo > -1)
            {
                m_AllVehicleInTheGarage[VehicelToFindInfo].Vehicle.getInformation(ref o_MessageWithTheInfo);
            }
            else
            {
                throw new ArgumentException("There isn't such car!!");
            }
        }

        public void GetVehicleInfo(string i_licensePlat, ref StringBuilder o_MessageWithTheInfo)
        {
            try
            {
                getVehicelInfoHelper(i_licensePlat, ref o_MessageWithTheInfo);
            }
            catch (ArgumentException AE)
            {
                Console.WriteLine(AE.Message);
            }
        }
    }
}
