using Miro.Models;

namespace miro.Services.Interface;

public interface IPaymentService
{
    Task<String> CreatePaymentRequest(PaymentRequest paymentRequest);
    Task<PaymentVerification> VerifyPayment(PaymentRequest paymentRequest, string paymentAuthority);
}