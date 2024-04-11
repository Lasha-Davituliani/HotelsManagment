using HotelManagment.Data;
using HotelManagment.Models;
using HotelManagment.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelManagment.Repository.Repositories
{
    public class RoomRepositoryEF : IRoomRepository
    {
        private readonly ApplicationDbContext _context;
        public RoomRepositoryEF(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddRoom(Room room)
        {
            if (room == null) throw new ArgumentNullException("Invalid argument passed");

            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoom(int Id)
        {
            if(Id <= 0) throw new ArgumentOutOfRangeException("Invalid argument passed");

            var entity = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == Id);
            if (entity == null) throw new NullReferenceException("Entity not found");

            _context.Rooms.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Room>> GetRooms()
        {
            var entity = await _context.Rooms
                        .Include(nameof(Hotel))
                        .ToListAsync();

            if (entity == null) throw new NullReferenceException("Entities not found");

            return entity;

        }
        public async Task<List<Room>> GetRoomsOfHotel(int hotelId)
        {
            var entities = await _context.Rooms
                        .Include(nameof(Hotel))
                        .Where(x => x.HotelId == hotelId)
                        .ToListAsync();

            if (entities == null) throw new NullReferenceException("Entity not found");

            return entities;
        }

        public async Task<Room> GetSingleRoom(int id)
        {
            var entity = await _context.Rooms
                        .Include(r => r.Hotel)
                        .FirstOrDefaultAsync(r => r.Id == id);


            if (entity == null) throw new NullReferenceException("Entity not found");
           
            return entity;
        }

        public async Task UpdateRoom(Room room)
        {
            if (room == null || room.Id <= 0) throw new ArgumentNullException("Invalid argument passed");

            var entity = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == room.Id);

            if (entity == null) throw new NullReferenceException("Entity not found");

            entity.Name = room.Name;
            entity.IsFree = room.IsFree;
            entity.HotelId = room.HotelId;
            entity.DailyPrice = room.DailyPrice;

            _context.Rooms.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
