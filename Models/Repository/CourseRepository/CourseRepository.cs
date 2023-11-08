namespace Project_Mvc.Models.Repository.CourseRepository
{
    public class CourseRepository : ICourseRepository
    {
        ProjectContext context;

        public CourseRepository(ProjectContext _context)
        {
            context =_context;
        }
        public List<Course> GetAll()
        {
            return context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return context.Courses.FirstOrDefault(n => n.Id == id);
        }
        public void Update(Course newCourse)
        {
            context.Update(newCourse);
        }

        public void Delete(int id)
        {
            Course course = GetById(id);
            context.Remove(course);
        }

        public void Insert(Course Course)
        {
            context.Courses.Add(Course);
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
