using System;

[Serializable]
public class PaymentModel
{
    public string Id;
    public string RentalId;
    public string UtilityId;
    public float Amount;
    public string Date;
    public bool IsPaid;

    public PaymentModel()
    {
        Id = Guid.NewGuid().ToString();
    }
}