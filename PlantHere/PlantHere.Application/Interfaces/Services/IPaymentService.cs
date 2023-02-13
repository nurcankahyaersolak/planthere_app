namespace PlantHere.Application.Interfaces.Services
{
    public interface IPaymentService
    {
        bool ReceiverPayment(int cardTypeId, string cardNumber, string cardSecurityNumber, string cardHolderName);
    }
}
