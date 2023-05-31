namespace Miro.Models;

public enum PaymentVerificationStatus
{
    Succeed = 100,
    InvalidPayment = 101,
    InvalidMerchant = 102,
    InvalidAmount = 103,
    InvalidAuthority = 104,
    PaymentFailed = 105,
    PaymentCanceledByUser = 106,
    PaymentCanceledBySystem = 107,
    UnknownError = 108
}