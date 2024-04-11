namespace HotelManagment.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsFree { get; set; }
        public double DailyPrice { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }

}
