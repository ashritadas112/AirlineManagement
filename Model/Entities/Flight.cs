namespace AirlineManagement.Model.Entities
{
    public class Flight
    {
        public  Guid FlightId { get; set; }
        public required string FlightNumber { get; set; }



        // FK to Aircraft
        public Guid AircraftId { get; set; }
        public required Aircraft Aircraft { get; set; }

        // Origin Airport FK
        public Guid OriginAirportId { get; set; }
        public required Airport OriginAirport { get; set; }

        // Destination Airport FK
        public Guid DestinationAirportId { get; set; }
        public required Airport DestinationAirport { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }
    }

}
