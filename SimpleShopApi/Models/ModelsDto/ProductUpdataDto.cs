

namespace SimpleShopApi.Models.DtoModels
{
    public class ProductUpdataDto
    {
        private string name;
        [Required]
        [MaxLength(25)]
        public string Name
        {
            get { return name.ToLower(); }
            set { name = value; }
        }

        public decimal Price { get; set; }

        private string category;
        [Required]
        [MaxLength(100)]
        public string? Category
        {
            get { return category.ToLower(); }
            set { category = value; }
        }

    }
}
