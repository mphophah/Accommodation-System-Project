using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AMS.Contracts;
using AMS.Data;
using AMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace RoomsControllers
{
    public class RoomsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoomsController(
                IUnitOfWork unitOfWork,
                IMapper mapper
                )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        // GET: Accomondation/Rooms

        public async Task<IActionResult> Index()
        {
            var rooms = await _unitOfWork.Rooms.FindAll();
            var model = _mapper.Map<List<Room>, List<RoomVM>>(rooms.ToList());
            return View(model);
        }


        // somthing that I add

        // GET: Accomondation/AddRoom
        public IActionResult Create()
        {
            return View();
        }


        //POST: Tenats/addRoom
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Create(RoomVM model)
        {
            try
            {
                var room = _mapper.Map<Room>(model);
                await _unitOfWork.Rooms.Create(room);
                await _unitOfWork.Save();
                System.Console.WriteLine(room.Description);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
                ModelState.AddModelError("", "");
                return View();

            }

        }

        // GET: RoomsEdit/5
        public async Task<ActionResult> Edit(int id)
        {
            var isExists = await _unitOfWork.Rooms.isExists(q => q.Id == id);

            if (!isExists)
            {
                return NotFound();
            }



            var room = await _unitOfWork.Rooms.Find(q => q.Id == id);
            var model = _mapper.Map<RoomVM>(room);
            return View(model);
        }

        // POST: Rooms/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RoomVM model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var room = _mapper.Map<Room>(model);
                _unitOfWork.Rooms.Update(room);
                await _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(model);
            }
        }

        // POST: Rooms/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var room = await _unitOfWork.Rooms.Find(expression: q => q.Id == id);
                if (room == null)
                {
                    return NotFound();
                }
                _unitOfWork.Rooms.Delete(room);
                await _unitOfWork.Save();

            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Rooms/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var isExists = await _unitOfWork.Rooms.isExists(q => q.Id == id);
            if (!isExists)
            {
                return NotFound();
            }
            var room = await _unitOfWork.Rooms.Find(q => q.Id == id);
            var model = _mapper.Map<RoomVM>(room);
            return View(model);
        }



    }

}
