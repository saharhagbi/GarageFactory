using System;
using System.Collections.Generic;
using System.Text;
using garageLogic;

public class OwnerDetails
{
    private string m_OwnerName;
    private string m_OwnerPhone;
    private Utilities.eCarCondition m_CarCondoition;
    private Vehicle m_Vehicle;

    public OwnerDetails(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
    {
        m_OwnerName = i_OwnerName;
        m_OwnerPhone = i_OwnerPhone;
        m_Vehicle = i_Vehicle;
        m_CarCondoition = Utilities.eCarCondition.IN_FIX;
    }

    public string OwnerName
    {
        get { return m_OwnerName; }
    }

    public string OwnerPhone
    {
        get { return m_OwnerPhone; }
    }

    public Vehicle Vehicle
    {
        get { return m_Vehicle; }
    }

    public Utilities.eCarCondition CarCondition
    {
        get { return m_CarCondoition; }
        set { m_CarCondoition = value; }
    }
}