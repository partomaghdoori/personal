namespace ProductManagement.Models.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required bool IsAvailable { get; set; }

        public required string ManufacturerEmail { get; set; }
        public required string ManufacturerPhone { get; set; }
        public required DateTime ManufacturerDate { get; set; }
    }
}
