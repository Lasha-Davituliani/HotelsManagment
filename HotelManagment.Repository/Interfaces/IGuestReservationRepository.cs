using HotelManagment.Models;

namespace HotelManagment.Repository.Interfaces
{
    public interface IGuestReservationRepository
    {
        public Task<List<GuestReservation>> GetGuestReservations();
        public Task<GuestReservation> GetSingleGuestReservation(int id);
        public Task AddGuestReservation(GuestReservation reservation);
        public Task UpdateGuestReservation(GuestReservation reservation);
        public Task DeleteGuestReservation(int id);
       
    }
}
