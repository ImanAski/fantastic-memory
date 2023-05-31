namespace Miro.Models;

public class PaymentRequest
{
    public string MerchantId { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public string CallbackUrl { get; set; }
    public int OrderId { get; set; }
}