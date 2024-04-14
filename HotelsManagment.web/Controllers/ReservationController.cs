using HotelManagment.Models;
using HotelManagment.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelsManagment.web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IGuestReservationRepository _guestReservationRepository;
        public ReservationController(IGuestReservationRepository guestReservationRepository, IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
            _guestReservationRepository = guestReservationRepository;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _reservationRepository.GetReservations();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Reservation model)
        {
            await _reservationRepository.AddReservation(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _reservationRepository.GetSingleReservation(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePOST(int id)
        {
            await _reservationRepository.DeleteReservation(id);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            var result = await _reservationRepository.GetSingleReservation(id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> UpdatePOST(Reservation model)
        {
            await _reservationRepository.UpdateReservation(model);
            return RedirectToAction("Index");
        }
    }
}
