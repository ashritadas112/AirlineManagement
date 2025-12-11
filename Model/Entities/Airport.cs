namespace AirlineManagement.Model.Entities
{
    public class Airport
    {
        public Guid AirportID { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }

        // Navigation (One airport can be origin for many flights)
        public required ICollection<Flight> OriginFlights { get; set; }

        // Navigation (One airport can be destination for many flights)
        public required ICollection<Flight> DestinationFlights { get; set; }
    }
}
