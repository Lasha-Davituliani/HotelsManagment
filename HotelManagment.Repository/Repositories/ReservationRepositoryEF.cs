using HotelManagment.Data;
using HotelManagment.Models;
using HotelManagment.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelManagment.Repository.Repositories
{
    public class ReservationRepositoryEF : IReservationRepository
    {
        private readonly ApplicationDbContext _context;
        public ReservationRepositoryEF(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddReservation(Reservation reservation)
        {
            if (reservation == null) throw new ArgumentNullException("Invalid argument passed");

            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReservation(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException("Invalid argument passed");

            var entity = await _context.Reservations.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) throw new NullReferenceException("Entity not found");

            _context.Reservations.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GuestReservation>> GetGuestReservations()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Reservation>> GetReservations()
        {
            var entity = await _context.Reservations
                       .ToListAsync();

            if (entity == null) throw new NullReferenceException("Entities not found");

            return entity;
        }

        public async Task<Reservation> GetSingleReservation(int id)
        {
            var entity = await _context.Reservations
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new NullReferenceException("Entity not found");
            }

            return entity;
        }

        public async Task UpdateReservation(Reservation reservation)
        {
            if (reservation == null || reservation.Id <= 0)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }

            var entity = await _context.Reservations.FirstOrDefaultAsync(x => x.Id == reservation.Id);

            if (entity == null)
            {
                throw new NullReferenceException("Entity not found");
            }

            entity.CheckOutDate = reservation.CheckOutDate;
            entity.CheckInDate = reservation.CheckInDate;
            entity.GuestReservations = reservation.GuestReservations;


            _context.Reservations.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
