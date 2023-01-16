using System.ComponentModel.DataAnnotations;

namespace SimpleShopApi.Models.DtoModels
{
    public class ProductUpdataDto
    {
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string? Category { get; set; }


    }
}
