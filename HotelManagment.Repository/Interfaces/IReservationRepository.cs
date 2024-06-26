﻿using HotelManagment.Models;

namespace HotelManagment.Repository.Interfaces
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetAll();
        Task<Reservation> GetById(int id);
        Task<Reservation> GetByCheckInCheckOutDate(DateTime checkInDate, DateTime checkOutDate);
        Task Add(Reservation reservation);
        Task Update(Reservation reservation);
        Task Delete(int id);
    }
}
