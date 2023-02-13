namespace SimpleShopApi.Entities
{
    public class AuthenticationSettings
    {
        public string Key { get; set; }
        public int ExpireDays { get; set; }
        public string Issuer { get; set; }
    }
}
