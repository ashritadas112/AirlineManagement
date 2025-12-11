namespace AirlineManagement.Model.DTO
{
    public class AirportDto
    {
        public Guid AirportID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
