namespace ProjectClientHub.API.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public Guid ClientId { get; set; }

    }
}
