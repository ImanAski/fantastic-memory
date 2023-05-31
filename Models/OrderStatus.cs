namespace Miro.Models;

/*
 * Enum for Zarinpal Payment Status
 */
public enum OrderStatus
{
    PendingPayment,
    Paid,
    PaymentFailed,
    Shipped,
    Delivered,
    Cancelled
}