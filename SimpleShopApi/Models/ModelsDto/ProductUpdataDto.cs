

namespace SimpleShopApi.Models.DtoModels
{
    public class ProductUpdataDto
    {
        [Required]
        [MaxLength(25)]
        public string Name;

        [MinLength(1)]
        public decimal Price { get; set; }

        [MaxLength(100)]
        public string Category { get; set; }

    }
}
