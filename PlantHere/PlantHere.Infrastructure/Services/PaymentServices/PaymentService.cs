using PlantHere.Application.Interfaces.Services;

namespace PlantHere.Infrastructure.PaymentServices
{
    public class PaymentService : IPaymentService
    {
        public bool ReceiverPayment(int cardTypeId, string cardNumber, string cardSecurityNumber, string cardHolderName)
        {
            return true;
        }
    }
}
