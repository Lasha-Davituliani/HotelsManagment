using HotelManagment.Models;

namespace HotelManagment.Repository.Interfaces
{
    public interface IRoomRepository
    {
        public Task<List<Room>> GetRooms();
        public Task<List<Room>> GetRoomsOfHotel(int hotelId);
        public Task AddRoom(Room room);
        public Task UpdateRoom(Room room);
        public Task DeleteRoom(int Id);
        public Task<Room> GetSingleRoom(int id);
    }
}
