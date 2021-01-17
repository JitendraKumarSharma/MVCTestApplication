using MVCTestProject.CustomModelBinders;
using MVCTestProject.ModelFromDatabase;
using MVCTestProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTestProject.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StudentInformation([ModelBinder(typeof(StudentModelBinder))] StudentViewModel studentViewModel)
        {

            try
            {
                var name = studentViewModel.Name;

                StudentDBEntities s = new StudentDBEntities();
                s.InsertStudentInfo(studentViewModel.StudentId, studentViewModel.Name, studentViewModel.Address,
                    studentViewModel.City, studentViewModel.State, studentViewModel.Country, studentViewModel.Department, studentViewModel.Marks);

                ViewBag.InsertMessage = "Record Inserted";
            }
            catch (Exception ex)
            {

            }

            return View("Index");

        }
    }
}