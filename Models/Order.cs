namespace Miro.Models;


/*
 * For Status You can use
 * 0 for Just created (or waiting for success)
 * 1 for Success after paying the bill in the Zarinpal Page or alternative payment Gateway
 */
public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string CustomerLastName { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerAddress { get; set; }
    public string CustomerProvince { get; set; }
    public string CustomerCity { get; set; }
    public string CustomerMobile { get; set; }
    public bool NewsUpdate { get; set; }
    public ShipmentMethod ShipmentMethod { get; set; }
    public string PostalCode { get; set; }
    public string? MessageForProvider { get; set; }
    public string? HouseNumber { get; set; }
    
    public decimal TotalPrice { get; set; }
    public List<CartItem> Items { get; set; }
    public OrderStatus Status { get; set; }
    public int UserId { get; set; }
}