using System.ComponentModel.DataAnnotations;

namespace SimpleShopApi.Models.DtoModels
{
    public class ProductAddDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public decimal? Price { get; set; }

        [Required]
        public string? Category { get; set; }

    }
}
