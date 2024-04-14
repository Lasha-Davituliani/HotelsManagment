using HotelManagment.Models;
using HotelManagment.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelsManagment.web.Controllers
{
    public class GuestReservationController : Controller
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IGuestReservationRepository _guestReservationRepository;
        public GuestReservationController(IGuestReservationRepository guestReservationRepository, IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
            _guestReservationRepository = guestReservationRepository;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _guestReservationRepository.GetGuestReservations();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(GuestReservation model)
        {
            await _guestReservationRepository.AddGuestReservation(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _guestReservationRepository.GetSingleGuestReservation(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePOST(int id)
        {
            await _guestReservationRepository.DeleteGuestReservation(id);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            var result = await _guestReservationRepository.GetSingleGuestReservation(id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> UpdatePOST(GuestReservation model)
        {
            await _guestReservationRepository.UpdateGuestReservation(model);
            return RedirectToAction("Index");
        }
    }
}
