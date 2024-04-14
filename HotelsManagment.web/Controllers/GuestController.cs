using HotelManagment.Models;
using HotelManagment.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelsManagment.web.Controllers
{
    public class GuestController : Controller
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IGuestReservationRepository _guestReservationRepository;
        public GuestController(IGuestReservationRepository guestReservationRepository, IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
            _guestReservationRepository = guestReservationRepository;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _guestRepository.GetGuests();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Guest model)
        {
            await _guestRepository.AddGuest(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _guestRepository.GetSingleGuest(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePOST(int id)
        {
            await _guestRepository.DeleteGuest(id);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            var result = await _guestRepository.GetSingleGuest(id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> UpdatePOST(Guest model)
        {
            await _guestRepository.UpdateGuest(model);
            return RedirectToAction("Index");
        }
    }
}
