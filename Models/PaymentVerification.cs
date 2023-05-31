namespace Miro.Models;

public class PaymentVerification
{
    public bool IsSuccess { get; set; }
    public PaymentVerificationStatus Status { get; set; }
    public string RefId { get; set; }
}