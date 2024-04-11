namespace HotelManagment.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }     
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }

}
