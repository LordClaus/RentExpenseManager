using System;
using System.Collections.Generic;

[Serializable]
public class RentalModel
{
    public string Id;
    public string RentalName;
    public float MonthlyRent;
    public string Address;
    public string StartDate;
    public List<string> UtilityIds;
    public bool IsActive;

    public RentalModel()
    {
        Id = Guid.NewGuid().ToString();
        UtilityIds = new List<string>();
        IsActive = true;
    }
}