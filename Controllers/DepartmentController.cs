using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.DAl.Database;
using WebApplication2.BL.Reposatory;
using System.Diagnostics;
using WebApplication2.BL.Interface;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        //Loosly Coupled
        private readonly IDepartmentRep department;

        public DepartmentController(IDepartmentRep department)
        {
            this.department = department; 
        }
        public IActionResult Index()
        {
            //DepartmentVM dept1 = new DepartmentVM() { Id = 1, DepartmentName = "HR", DepartmentCode ="A100" };
            //DepartmentVM dept2 = new DepartmentVM() { Id = 2, DepartmentName = "IT", DepartmentCode = "A200" };
            //DepartmentVM dept3 = new DepartmentVM() { Id = 3, DepartmentName = "Sales", DepartmentCode = "A300" };

            //List<DepartmentVM> deptData = new List<DepartmentVM>() ;
            //deptData.Add(dept1);
            //deptData.Add(dept2);
            //deptData.Add(dept3);

                   var data =  department.Get(); 
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentVM dpt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    department.Add(dpt);
                    return RedirectToAction("Index", "Department");
                }
                return View(dpt); 
            }
            catch(Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(dpt);
            }

          
        }
        public IActionResult Edit(int id)
        {
            var data = department.GetByID(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(DepartmentVM dpt)
        {
            try
            {

                if (ModelState.IsValid)
                {
                     department.Edit(dpt);
                    return RedirectToAction("Index", "Department");
                }
                return View(dpt); 
            }catch(Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(dpt);
            }
          
        }
        public IActionResult Delete(int id)
        {

            var data = department.GetByID(id);
            return View(data);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {

                department.Delete(id);
                return RedirectToAction("Index" , "Department") ;
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View();
            }

        }





    }
}
