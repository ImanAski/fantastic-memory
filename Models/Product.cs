using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    [Required]
    public String Name { get; set; }
    [Required]
    public String Description { get; set; }
    [Required]
    public decimal Price { get; set; }
    public bool InStock { get; set; }

    public string PriceFormatted
    {
        get
        {
            if (InStock)
            {
                return string.Format("{0:N0}", Price) + " تومان";
            }
            else 
            {
                return "این محصول موجود نیست";
            }
        }
    }

    public string InStockFormattedEn
    {
        get
        {
            if (InStock)
            {
                return string.Format("In Stock");
            }else 
            {
                return string.Format("Not In Stock");
            }
        }
    }

}