using HotelManagment.Data;
using HotelManagment.Models;
using HotelManagment.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelManagment.Repository.Repositories
{
    public class GuestReservationRepositoryEF : IGuestReservationRepository
    {
        private readonly ApplicationDbContext _context;
        public GuestReservationRepositoryEF(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddGuestReservation(GuestReservation guestReservation)
        {
            if (guestReservation == null) throw new ArgumentNullException("Invalid argument passed");

            await _context.GuestReservations.AddAsync(guestReservation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGuestReservation(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException("Invalid argument passed");

            var entity = await _context.GuestReservations.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) throw new NullReferenceException("Entity not found");

            _context.GuestReservations.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GuestReservation>> GetGuestReservations()
        {
            var entity = await _context.GuestReservations
                      .ToListAsync();

            if (entity == null) throw new NullReferenceException("Entities not found");

            return entity;
        }

        public async Task<GuestReservation> GetSingleGuestReservation(int id)
        {
            var entity = await _context.GuestReservations
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new NullReferenceException("Entity not found");
            }

            return entity;
        }

        public async Task UpdateGuestReservation(GuestReservation guestReservation)
        {
            if (guestReservation == null || guestReservation.Id <= 0)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }

            var entity = await _context.GuestReservations.FirstOrDefaultAsync(x => x.Id == guestReservation.Id);

            if (entity == null)
            {
                throw new NullReferenceException("Entity not found");
            }

            entity.ReservationId = guestReservation.ReservationId;
            entity.GuestId = guestReservation.GuestId;
            entity.Reservation = guestReservation.Reservation;
            entity.Guest = guestReservation.Guest;


            _context.GuestReservations.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
