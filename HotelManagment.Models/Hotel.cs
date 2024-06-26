﻿namespace HotelManagment.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PhyisicalAddress { get; set; }
        public Manager Manager { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
