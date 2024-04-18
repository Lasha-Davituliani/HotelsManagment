using AutoMapper;
using HotelManagment.Models;
using HotelManagment.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using HotelManagment.Models.DTOs;

namespace HotelManagment.Web.Controllers
{
    public class GuestsController : Controller
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IGuestReservationRepository _guestReservationRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public GuestsController(IGuestRepository guestRepository, IGuestReservationRepository guestReservationRepository, IReservationRepository reservationRepository, IMapper mapper)
        {
            _guestRepository = guestRepository;
            _guestReservationRepository = guestReservationRepository;
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<GuestReservation> rawData = await _guestReservationRepository.GetAll();
            List<GuestReservationDto> result = _mapper.Map<List<GuestReservationDto>>(rawData);

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(GuestReservationForCreatingDto model)
        {
            Guest newGuest = _mapper.Map<Guest>(model);
            Reservation newReservation = _mapper.Map<Reservation>(model);

            await _guestRepository.Add(newGuest);
            await _reservationRepository.Add(newReservation);

            var newGuestFromDb = await _guestRepository.GetByPin(model.PersonalNumber);
            var newReservationFromDb = await _reservationRepository.GetByCheckInCheckOutDate(model.CheckInDate, model.CheckOutDate);

            model.GuestId = newGuestFromDb.Id;
            model.ReservationId = newReservationFromDb.Id;

            await _guestReservationRepository.Add(_mapper.Map<GuestReservation>(model));
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            var result = await _guestReservationRepository.GetById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePOST(int id, int guestId, int reservationId)
        {
            await _guestReservationRepository.Delete(id);
            await _guestRepository.Delete(guestId);
            await _reservationRepository.Delete(reservationId);

            return RedirectToAction("Index");
        }

        //TODO დამოუკიდებლად დაწერეთ Update ის ლოგიკა გამოიყენეთ GuestWithReservationForUpdatingDto კლასი
        public async Task<IActionResult> Update(int id)
        {
            var guestReservation = await _guestReservationRepository.GetById(id);
            if (guestReservation == null)
            {
                return NotFound();
            }

            var updateDto = _mapper.Map<GuestWithReservationForUpdatingDto>(guestReservation);
            return View(updateDto);
        }

        // Action to handle the form submission for update
        [HttpPost]
        public async Task<IActionResult> Update(int id, GuestWithReservationForUpdatingDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var existingGuestReservation = await _guestReservationRepository.GetById(id);
            if (existingGuestReservation == null)
            {
                return NotFound();
            }

            var updatedGuestReservation = _mapper.Map(model, existingGuestReservation);
            var updatedGuest = _mapper.Map(model, existingGuestReservation.Guest);
            var updatedReservation = _mapper.Map(model, existingGuestReservation.Reservation);

            await _guestRepository.Update(updatedGuest);
            //await _reservationRepository.Update(updatedReservation);
            //await _guestReservationRepository.Update(updatedGuestReservation);

            return RedirectToAction("Index");
        }
    }
}