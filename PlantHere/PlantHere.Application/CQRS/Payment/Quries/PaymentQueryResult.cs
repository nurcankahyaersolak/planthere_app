namespace PlantHere.Application.CQRS.Payment.Quries
{
    public class PaymentQueryResult
    {
        public int CardTypeId { get; set; }
        public string CardNumber { get; set; }
        public string CardSecurityNumber { get; set; }
        public string CardHolderName { get; set; }
    }
}
