using Project_Mvc.Models;

namespace Project_Mvc.ViewModel
{
    public class DepartmentsCourses
    {
        public string Name { get; set; }

        public int Salary { get; set; }

        public string Adress { get; set; }

        public string Image { set; get; }


        public List<Department> Departments { get; set; } = new List<Department>();
        public List<Course> Courses { get; set; } = new List<Course>();

    }
}
