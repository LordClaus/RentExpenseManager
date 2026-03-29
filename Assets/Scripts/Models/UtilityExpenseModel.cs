using System;

[Serializable]
public class UtilityExpenseModel
{
    public string Id;
    public string RentalId;
    public string CategoryName;
    public float Amount;
    public string DueDate;
    public string Frequency;

    public UtilityExpenseModel()
    {
        Id = Guid.NewGuid().ToString();
    }
}