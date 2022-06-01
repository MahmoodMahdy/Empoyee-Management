using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.BL.Interface;
using WebApplication2.Models;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        //Loosly Coupled
        private readonly IEmployeeRep employee;
        private readonly IDepartmentRep department;
        private readonly ICountryRepo country;
        private readonly IcityRep city;
        private readonly IDistrictRep district;
        public EmployeeController(IEmployeeRep employee , IDepartmentRep department, ICountryRepo country, IcityRep city, IDistrictRep district)
        {
            this.employee = employee;
            this.department = department;
            this.country = country;
            this.city = city;
            this.district = district;
        }
        public IActionResult Index()
        {
            var data = employee.Get();
            return View(data);
        }
        public IActionResult Create()
        {
            var data = department.Get();
            var Countrydata = country.Get();

            ViewBag.DepartmentList = new SelectList(data, "Id", "DepartmentName");
            ViewBag.CountryList = new SelectList(Countrydata, "Id", "CountryName");

            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeVM emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    #region save Photo
                   
                    #endregion

                    #region save cv
              
                    #endregion

                    employee.Add(emp);
                    return RedirectToAction("Index", "Employee");
                }
                var data = department.Get();

                ViewBag.DepartmentList = new SelectList(data, "Id", "DepartmentName");
                return View(emp);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(emp);
            }


        }
        public IActionResult Edit(int id)
        {
            var data = employee.GetByID(id);

            ViewBag.Deptdata = department.Get();
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeVM emp)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    employee.Edit(emp);
                    return RedirectToAction("Index", "Employee");
                }
                var Deptdata = department.Get();
                ViewBag.DepartmentList = new SelectList(Deptdata, "Id", "DepartmentName", emp.DepartmentId);
                return View(emp);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(emp);
            }

        }
        public IActionResult Delete(int id)
        {

            var data = employee.GetByID(id);
            return View(data);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {

                employee.Delete(id);
                return RedirectToAction("Index", "Employee");
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View();
            }

        }


        // --------------- Ajax Call --------- 
        [HttpPost]
        public JsonResult GetCityByCountryId (int cuntryId)
        {
            var data = city.Get().Where(a => a.CountryName == cuntryId );
            return Json(data); 
        }
        [HttpPost]
        public JsonResult GetDistrictByCityId(int CityId)
        {
            var data = district.Get().Where(a => a.CityName == CityId);
            return Json(data);
        }
    }
}
