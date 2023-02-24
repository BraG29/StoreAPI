namespace StoreAPI.DTO.V2
{
    public class ProductV2
    {
        public Guid InternalId = Guid.NewGuid();
        public int id { get; set; }
        public string? title { get; set; }
        public float price { get; set; }
        public string? description { get; set; }
        public string? category { get; set; }
        public string? image { get; set; }
    }
}
