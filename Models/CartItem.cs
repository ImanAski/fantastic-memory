

namespace Miro.Models;

public class CartItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string PriceFormatted
    {
        get
        {
            return string.Format("{0:N0}", Price) + " تومان";
        }
    }
}