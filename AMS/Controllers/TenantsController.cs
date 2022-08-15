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
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Tenants.Controllers
{

    [Authorize(Roles ="Administrator")]
    public class TenantsController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILeaveTypeRepository _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public TenantsController(
                IUnitOfWork unitOfWork,
                IMapper mapper,
                IWebHostEnvironment webHostEnvironment

                )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;

        }

        // GET: Tenants
        public  async Task<ActionResult> Index()
        {
            var tenants = await _unitOfWork.Tenants.FindAll();
            var model = _mapper.Map<List<Tenant>, List<TenantVM>>(tenants.ToList());
            return View(model);
        }


        // GET: Tenants/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Tenants/Create
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Create(TenantVM model)
        {
            try
            {
                string uniqueFileName = ProcessUploadedFile(model);
                
                var tenant = _mapper.Map<Tenant>(model);

                tenant.fileAttached = uniqueFileName;

                await _unitOfWork.Tenants.Create(tenant);

                await _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                ModelState.AddModelError("","");
                return View();
            }

        }

        // GET: LeaveTypes/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var isExists = await _unitOfWork.Tenants.isExists(q => q.Id == id);

            if (!isExists)
            {
                return NotFound();
            }



            var tenant = await _unitOfWork.Tenants.Find(q => q.Id == id);
            var model = _mapper.Map<TenantVM>(tenant);
            return View(model);
        }

        // POST: LeaveTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TenantVM model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var tenant = _mapper.Map<Tenant>(model);
                _unitOfWork.Tenants.Update(tenant);
                await _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(model);
            }
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var tenant = await _unitOfWork.Tenants.Find(expression: q => q.Id == id);
                if (tenant == null)
                {
                    return NotFound();
                }
                _unitOfWork.Tenants.Delete(tenant);
                await _unitOfWork.Save();

            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: LeaveTypes/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var isExists = await _unitOfWork.Tenants.isExists(q => q.Id == id);
            if (!isExists)
            {
                return NotFound();
            }
            var tenant = await _unitOfWork.Tenants.Find(q => q.Id == id);
            var model = _mapper.Map<TenantVM>(tenant);
            return View(model);
        }

        private string ProcessUploadedFile(TenantVM model)
        {
            string uniqueFileName = null;

            if (model.file != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, FileLocation.FileUploadFolder);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.file.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }


    }
}
