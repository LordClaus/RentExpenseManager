using System;

[Serializable]
public class CreditCalculationModel
{
    public string Id;
    public float LoanAmount;
    public float InterestRate;
    public int TermMonths;
    public float MonthlyPayment;
    public float TotalOverpayment;
    public string SavedDate;

    public CreditCalculationModel()
    {
        Id = Guid.NewGuid().ToString();
        SavedDate = DateTime.Now.ToString("yyyy-MM-dd");
    }
}