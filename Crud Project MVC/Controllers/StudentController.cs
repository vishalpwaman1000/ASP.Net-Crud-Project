using Crud_Project_MVC.Models;
using Crud_Project_MVC.Models.Entities;
using Crud_Project_MVC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Crud_Project_MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRL _studentRL;
        public StudentController(IStudentRL studentRL)
        {
            _studentRL = studentRL;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentRequest request)
        {
            await _studentRL.AddStudent(request);
            return RedirectToAction("List", "Student");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var studentList = await _studentRL.GetStudentList();
            return View(studentList);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var student = await _studentRL.GetStudentById(Id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student request)
        {
            await _studentRL.UpdateStudent(request);
            return RedirectToAction("List", "Student");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid Id)
        {
            await _studentRL.DeleteStudent(Id);
            return RedirectToAction("List", "Student");
        }
    }
}
