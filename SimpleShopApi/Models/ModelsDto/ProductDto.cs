

namespace SimpleShopApi.Models.DtoModels
{
    public class ProductDto
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = char.ToUpper(value[0]) + value.Substring(1); }
        }
        public decimal Price { get; set; }

    }
}
