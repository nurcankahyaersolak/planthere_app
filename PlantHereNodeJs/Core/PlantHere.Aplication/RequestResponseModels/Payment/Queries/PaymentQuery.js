class PaymentQueryResult{
    constructor(cardTypeId,cardNumber,cardSecurityNumber,cardHolderName) {
        this.CardTypeId = cardTypeId,
        this.CardNumber = cardNumber,
        this.CardSecurityNumber =  cardSecurityNumber,
        this.CardHolderName = cardHolderName
    }
}

module.exports = {PaymentQueryResult}