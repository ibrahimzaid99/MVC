using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Mvc.Models;
using Project_Mvc.ViewModel;

namespace Project_Mvc.Controllers

{
 
   
    public class InstructorController : Controller
    {
        ProjectContext Context = new ProjectContext();
        public IActionResult New()
        {
            List<Department> DepartmentList = Context.Departments.ToList();
            List<Course> CoursesList = Context.Courses.ToList();
            ViewData["DepartmentList"] = DepartmentList;
            ViewData["CoursesList"] = CoursesList;
            return View("New");
        }
        
        //---------------------------------------

        //using View Model
        public IActionResult NewVM()
        {
            DepartmentsCourses departmentsCourses = new DepartmentsCourses();
            List<Department> DepartmentList = Context.Departments.ToList();
            List<Course> CoursesList = Context.Courses.ToList();
            foreach (var department in DepartmentList)
            {
                departmentsCourses.Departments.Add(new Department()
                {
                    Id = department.Id,
                    Name = department.Name,
                    Courses = department.Courses,
                    Instructors = department.Instructors,
                    Manager = department.Manager,
                    Trainees = department.Trainees
                });
            }
            foreach (var Course in CoursesList)
            {
                departmentsCourses.Courses.Add(new Course()
                {
                    Id = Course.Id,
                    Name = Course.Name,
                    Courses = Course.Courses,
                    Degree = Course.Degree,
                    Instructors = Course.Instructors,
                    Hours = Course.Hours,
                    MinimumDegree = Course.MinimumDegree,
                    Dept_Id = Course.Dept_Id,
                    Department = Course.Department
                });
                
            }

            return View(departmentsCourses);
        }

        //---------------------------------------
        public IActionResult SaveNew(Instructor newInstructor)
        {
            if (newInstructor.Name != null)
            {
                Context.Instructors.Add(newInstructor);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("New", newInstructor);
        }
        //---------------------------------------
        public IActionResult Edit(int id)
        {

            Instructor instructor = Context.Instructors.FirstOrDefault(x => x.Id == id);
            List<Department> DepartmentList = Context.Departments.ToList();
            List<Course> CoursesList = Context.Courses.ToList();
            ViewData["DepartmentList"] = DepartmentList;
            ViewData["CoursesList"] = CoursesList;
            return View("Edit", instructor);
        }
        //---------------------------------------
        public IActionResult SaveEdit(Instructor instructor)
        {
            if (instructor.Name != null)
            {
                Context.Update(instructor);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            List<Department> DepartmentList = Context.Departments.ToList();
            List<Course> CoursesList = Context.Courses.ToList();
            ViewData["DepartmentList"] = DepartmentList;
            ViewData["CoursesList"] = CoursesList;
            return View("Edit", instructor);
        }
        //---------------------------------------
        public IActionResult Index()
        {
            List<Instructor> InstModel = Context.Instructors.Include(c=>c.Department).Include(c=>c.Course).ToList();
            //List<Department> DepartmentList = Context.Departments.ToList();
            //List<Course> CoursesList = Context.Courses.ToList();
            //ViewData["DepartmentList"] = DepartmentList;
            //ViewData["CoursesList"] = CoursesList;
            return View("Index", InstModel);
        }
        //---------------------------------------
        public IActionResult Detailes(int id)
        {
            Instructor insModel = Context.Instructors.FirstOrDefault(n => n.Id == id);

            return View("First", insModel);
        }
        //---------------------------------------
        public IActionResult GetCourses(int did)
        {
            List<Course> courses = Context.Courses.Where(n=>n.Dept_Id== did).ToList();
            return Json(courses);
        }
    }
}
