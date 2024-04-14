using HotelManagment.Models;

namespace HotelManagment.Repository.Interfaces
{
    public interface IReservationRepository
    {
        public Task<List<Reservation>> GetReservations();
        public Task<Reservation> GetSingleReservation(int id);
        public Task AddReservation(Reservation reservation);
        public Task UpdateReservation(Reservation reservation);
        public Task DeleteReservation(int id);
        public Task<List<GuestReservation>> GetGuestReservations();
    }
}
