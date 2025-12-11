namespace AirlineManagement.Model.Entities
{
    public class Aircraft
    {
        public Guid AircraftId { get; set; }
        public required string ModelName { get; set; }
        public required string Capacity { get; set; }

        // Navigation - One aircraft can be used in many flights
        public required ICollection<Flight> Flights { get; set; }
    }
}
