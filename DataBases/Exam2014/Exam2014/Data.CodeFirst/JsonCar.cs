namespace Data.CodeFirst.Models
{
    public class JsonCar
    {
        public int Year { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public JsonDealer Dealer { get; set; }
    }
}
