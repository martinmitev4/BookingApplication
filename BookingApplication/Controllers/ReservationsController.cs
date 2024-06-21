using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BA.Domain.Domain;
using BA.Service.Implementation;
using BA.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookingApplication.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IReservationsServices _reservationService;
        private readonly IApartmentService _apartmentService;

        public ReservationsController(IReservationsServices reservationService, IApartmentService apartmentService)
        {
            _reservationService = reservationService;
            _apartmentService = apartmentService;
        }

        // GET: Reservations
        public IActionResult Index()
        {
            return View(_reservationService.GetReservations());
        }

        // GET: Reservations/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = _reservationService.GetReservationById(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            ViewData["ApartmentId"] = new SelectList(_apartmentService.GetApartments(), "Id", "ApartmentName");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Check_in_date,ApartmentId")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                reservation.Id = Guid.NewGuid();
                _reservationService.CreateNewReservation(reservation);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApartmentId"] = new SelectList(_apartmentService.GetApartments(), "Id", "ApartmentName", reservation.ApartmentId);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = _reservationService.GetReservationById(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["ApartmentId"] = new SelectList(_apartmentService.GetApartments(), "Id", "ApartmentName", reservation.ApartmentId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,Check_in_date,ApartmentId")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _reservationService.UpdateReservation(reservation);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApartmentId"] = new SelectList(_apartmentService.GetApartments(), "Id", "ApartmentName", reservation.ApartmentId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = _reservationService.GetReservationById(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _reservationService.DeleteReservation(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(Guid id)
        {
            return _reservationService.GetReservationById(id) != null ? true : false;
        }
    }
}
