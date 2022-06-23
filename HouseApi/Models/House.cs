namespace HouseApi.Models
{
    public class House
    {
        public int Id { get; set; }
        public string Location { get; set; } = string.Empty;
        public double Prize { get; set; }
        public int Rooms { get; set; }
    }
}
