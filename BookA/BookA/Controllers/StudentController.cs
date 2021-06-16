using BookA.Models;
using BookA.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookA.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _reps = null;
        public StudentController(StudentRepository repository)
        {
            _reps = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ViewResult AddStudent(bool issuccess=false)
        {
            ViewBag.IsSuccess = issuccess;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>  AddStudent(StudentModel model)
        {
            //int id = _reps.AddNewStudent(model);
            //if(id>0)
            //{
            //    return RedirectToAction(nameof(AddStudent), new { Issuccess = true });
            //}
           int id= await _reps.AddNewStudent(model);
            if(id>0)
            {
                return RedirectToAction(nameof(AddStudent), new { issuccess = true });
            }
            return View();
        }
    }
}
