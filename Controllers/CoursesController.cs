using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Mvc.Models;
using Project_Mvc.Models.Repository.CourseRepository;
using Project_Mvc.Models.Repository.DepartmentRepository;

namespace Project_Mvc.Controllers
{
    public class CoursesController : Controller
    {
        //ProjectContext context = new ProjectContext();

        ICourseRepository courseRepository;
        IDepartmentRepository departmentRepository;
        public CoursesController(ICourseRepository courseRepository, IDepartmentRepository departmentRepository)
        {
            this.courseRepository = courseRepository;
            this.departmentRepository = departmentRepository;
        }
        //---------
        public IActionResult Index()
        { 
            List<Course> courses = courseRepository.GetAll();
            return View(courses);
        }
        //---------------------------------
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public IActionResult AddCourses()
        {
            List<Department> DepartmentsList = departmentRepository.GetAll();
            ViewData["DepartmentsList"] = DepartmentsList;
            return View("AddCourses");
        }
        //---------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCourses(Course newCourse)
        {
            // if (newCourse.Name != null)
            if (ModelState.IsValid == true)
            {
                //context.Update(newCourse);
                courseRepository.Insert(newCourse);
                //context.SaveChanges();
                courseRepository.Save();
                return RedirectToAction("Index");
            }
            List<Department> DepartmentsList = departmentRepository.GetAll();
            ViewData["DepartmentsList"] = DepartmentsList;
            return View("AddCourses", newCourse);
        }
        //------------------------
        public IActionResult Edit(int id)
        {
            Course course = courseRepository.GetById(id);
            List<Department> DepartmentsList = departmentRepository.GetAll();
            ViewData["DepartmentsList"] = DepartmentsList;
            return View("Edit", course);
        }
        //------------------------
        public IActionResult SaveEdit(Course course)
        {
            if (course.Name != null)
            {
                courseRepository.Update(course);
                courseRepository.Save();
                return RedirectToAction("Index");
            }
            List<Department> DepartmentsList = departmentRepository.GetAll();
            ViewData["DepartmentsList"] = DepartmentsList;
            return View("Edit", course);
        }
        //------------------------
        public IActionResult CheckDegree(int Degree, int MinimumDegree)
        {
            if (Degree > MinimumDegree)
            {
                return Json(true);
            }
            return Json(false);
        }

    }
}
