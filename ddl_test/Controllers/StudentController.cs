using ddl_test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ddl_test.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// student index action 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// returns sutdent data
        /// </returns>
        public async  Task<IActionResult> Index(int id = 0)
        {
            ViewBag.BT = "Save";
            var students = new StudentDto();
            var stu = new Sutdent();
            students.sutdents = await (from student in _context.sutdents
                        join cnt in _context.countries on student.CountryId equals cnt.CountryId
                        join st in _context.states on student.StateId equals st.StateId
                        join ct in _context.cities on student.CityId equals ct.CityId
                        select new StudentData
                        {
                            StudentId = student.StudentId,
                            Name = student.Name,
                            Email = student.Email,
                            Mobile = student.Mobile,
                            CountryName = cnt.CountryName,
                            StateName = st.StateName,
                            CityName = ct.CityName
                        }).ToListAsync();

            if (id > 0)
            {
                stu = await _context.sutdents.Where(x => x.StudentId == id).FirstOrDefaultAsync();
                students.StudentId = stu.StudentId;
                students.Name = stu.Name;
                students.Mobile = stu.Mobile;
                students.Email = stu.Email;
                students.CountryId = stu.CountryId;
                students.StateId = stu.StateId;
                students.CityId = stu.CityId;
                ViewBag.BT = "Update";
            }


            var countries = _context.countries.Where(x => x.Active).OrderBy(c => c.CountryName).ToList();
            countries.Insert(0 , new Country { CountryId =0, CountryName ="--Select--", Active=true});
            ViewBag.countries = countries;

            var states = await _context.states.Where(x => x.CountryId == stu.CountryId && x.Active).ToListAsync();
            states.Insert(0, new State { StateId = 0, StateName = "--Select--", Active = true });
            ViewBag.State = states;

            var cities = await _context.cities.Where(x => x.StateId == stu.StateId && x.Active).ToListAsync();
            cities.Insert(0, new City { CityId = 0, CityName = "--Select--", Active = true });
            ViewBag.City = cities;



            return View(students);
        }
        /// <summary>
        /// save and upate student data
        /// </summary>
        /// <param name="sutdent"></param>
        /// <returns>
        /// index view
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Index(Sutdent sutdent)
        {
            if (ModelState.IsValid)
            {
                if(sutdent.StudentId <= 0)
                {
                    _context.sutdents.Add(sutdent);
                }
                else
                {
                    _context.Entry(sutdent).State = EntityState.Modified;
                }
                int v = await  _context.SaveChangesAsync();
            }

            return RedirectToAction("");
        }
        /// <summary>
        /// Used for delete student data
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// index view
        /// </returns>
        public async Task<IActionResult> Delete(int id = 0)
        {
            var student = await _context.sutdents.Where(x => x.StudentId == id).FirstOrDefaultAsync();
            _context.sutdents.Remove(student);
            int v = await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// get state data by country id
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns>
        /// state data
        /// </returns>
        public JsonResult GetState(int countryId)
        {
            var data = _context.states.Where(x => x.CountryId == countryId && x.Active).ToList();
            data.Insert(0, new State { StateId = 0, StateName = "--Select--" });
            return Json(new SelectList(data, "StateId", "StateName"));
        }
        /// <summary>
        /// get city data by country id
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns>
        /// city data
        /// </returns>
        public JsonResult GetCity(int stateId)
        {
             var data = _context.cities.Where(x => x.StateId == stateId && x.Active).ToList();
            data.Insert(0, new City { CityId = 0, CityName = "--Select--" });
            return Json(new SelectList(data, "CityId", "CityName"));
        }
    }
}
