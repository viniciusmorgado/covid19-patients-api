using system;

namespace API.Models
{
    public class InfectedDto
    {
        public DateTime Birthday { get; set; }
        public string Sex { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}