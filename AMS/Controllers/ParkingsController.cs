using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AMS.Contracts;
using AMS.Data;
using AMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Parkings.Controllers
{

    [Authorize(Roles = "Administrator")]
    public class ParkingsController : Controller
    {
        private readonly ILeaveTypeRepository _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ParkingsController(
                IUnitOfWork unitOfWork,
                IMapper mapper

                )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<ActionResult> index()
        {

            // This also grab the related table information
            var parkings = await _unitOfWork.Parkings.FindAll(
                    includes: q => q.Include(x => x.Tenant)
                    );

            var model = _mapper.Map<List<ParkingVM>>(parkings.ToList());
            // System.Console.WriteLine(model.First().Tenant.FirstName);
            return View(model);
        }

        public async Task<ActionResult> Create(string parameter)
        {

            var tenants = await _unitOfWork.Tenants.FindAll();
            var tenantsOptionList = tenants.Select(q => new SelectListItem
            {
                Text = q.FirstName + " " + q.LastName,
                Value = q.Id.ToString()
            });

            var model = new ParkingVM
            {
                TenantList = tenantsOptionList
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ParkingVM modelVM)
        {
            try
            {
                var model = new ParkingVM
                {
                    TenantId = modelVM.TenantId,
                    Amount = modelVM.Amount,
                    ParkingNumber = modelVM.ParkingNumber,
                    ParkingType = modelVM.ParkingType

                };

                var parking = _mapper.Map<Parking>(model);
                await _unitOfWork.Parkings.Create(parking);
                await _unitOfWork.Save();
                return View("index");
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // GET: parking/edit
        public async Task<ActionResult> Edit(int id)
        {
            var isExists = await _unitOfWork.Parkings.isExists(q => q.Id == id);
            if (!isExists)
                return NotFound();


            var tenants = await _unitOfWork.Tenants.FindAll();
            var tenantsOptionList = tenants.Select(q => new SelectListItem
            {
                Text = q.FirstName + " " + q.LastName,
                Value = q.Id.ToString()
            });
            var parking = await _unitOfWork.Parkings.Find(q => q.Id == id);

            var modelA = new ParkingVM
            {
                ParkingNumber = parking.ParkingNumber,
                ParkingType = parking.ParkingType,
                Amount = parking.Amount,
                TenantId = parking.TenantId,
                TenantList = tenantsOptionList

            };

            var model = _mapper.Map<ParkingVM>(parking);
            return View(model);
        }


        // POST: paring/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ParkingVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
            var parking = _mapper.Map<Parking>(model);

            _unitOfWork.Parkings.Update(parking);
            await _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
            }

            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(model);
            }
        }


    }
}
