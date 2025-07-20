namespace ProductManagement.Models
{
    public class AddProductDTO
    {
        public required string Name { get; set; }
        public required bool IsAvailable { get; set; }

        public required string ManufacturerEmail { get; set; }
        public required string ManufacturerPhone { get; set; }
        public required DateTime ManufacturerDate { get; set; }
    }
}
