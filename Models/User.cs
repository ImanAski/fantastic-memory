using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    [Required]
    public String Email { get; set; }
    [Required]
    public String Name { get; set; }
    public String Password { get; set; }
    public String Role { get; set; }

}