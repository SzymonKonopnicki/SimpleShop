namespace SimpleShopApi.Entities;

public partial class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required]
    [MaxLength(25)]
    public string Name { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    [MaxLength(100)]
    public string Category { get; set; }
}
