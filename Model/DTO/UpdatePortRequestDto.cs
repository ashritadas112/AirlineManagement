namespace AirlineManagement.Model.DTO
{
    public class UpdatePortRequestDto
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }
    }
}
