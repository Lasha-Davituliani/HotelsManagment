using HotelManagment.Models;

namespace HotelManagment.Repository.Interfaces
{
    public interface IGuestReservationRepository
    {
        Task<List<GuestReservation>> GetAll();
        Task<GuestReservation> GetById(int id);
        Task Add(GuestReservation guestReservation);
        Task Update(GuestReservation guestReservation);
        Task Delete(int id);
    }
}
