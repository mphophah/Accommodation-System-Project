using AutoMapper;
using AMS.Contracts;
using AMS.Data;
using AMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AMS.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReservationController(
                IUnitOfWork unitOfWork,
                IMapper mapper
                )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Index()
        {
            var reservations = await _unitOfWork.Reservations.FindAll();
            var model = _mapper.Map<List<Reservation>, List<ReservationVM>>(reservations.ToList());
            return View(model);
        }

        // GET: LeaveRequest/Create
        public async Task<ActionResult> Create()
        {
            var tenants = await _unitOfWork.Tenants.FindAll();
            var rooms = await _unitOfWork.Rooms.FindAll();

            var tenantsData = tenants.Select(q => new SelectListItem
            {
                Text = q.FirstName + " " + q.LastName,
                Value = q.Id.ToString()
            });

            var roomsData = rooms.Select(q => new SelectListItem
            {
                Text = q.RoomNumber,
                Value = q.Id.ToString()
            });


            var model = new ReservationVM
            {
                TenantList = tenantsData,
                RoomList = roomsData,
            };

            return View(model);
        }

        // POST: LeaveRequest/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ReservationVM model)
        {

            try
            {

                var ReservationModel = new ReservationVM
                {
                    DateIn = model.DateIn,
                    DateOut = model.DateOut,
                    RoomId = model.RoomId,
                    TenantId = model.TenantId,

                };

                var reservation = _mapper.Map<Reservation>(ReservationModel);
                await _unitOfWork.Reservations.Create(reservation);
                await _unitOfWork.Save();


                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "");
                return View(model);
            }
        }

        // GET: Reservation/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var isExists = await _unitOfWork.Reservations.isExists(q => q.Id == id);

            if (!isExists)
            {
                return NotFound();
            }



            var reservation = await _unitOfWork.Reservations.Find(q => q.Id == id);
            var model = _mapper.Map<ReservationVM>(reservation);
            return View(model);
        }

        // POST: Reservation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ReservationVM model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var reservation = _mapper.Map<Reservation>(model);
                _unitOfWork.Reservations.Update(reservation);
                await _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(model);
            }
        }

        // POST: Reservation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var reservation = await _unitOfWork.Reservations.Find(expression: q => q.Id == id);
                if (reservation == null)
                {
                    return NotFound();
                }
                _unitOfWork.Reservations.Delete(reservation);
                await _unitOfWork.Save();

            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Reservations/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var isExists = await _unitOfWork.Reservations.isExists(q => q.Id == id);
            if (!isExists)
            {
                return NotFound();
            }
            var reservation = await _unitOfWork.Reservations.Find(q => q.Id == id);
            var model = _mapper.Map<ReservationVM>(reservation);
            return View(model);
        }


    }
}
