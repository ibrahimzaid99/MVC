namespace Project_Mvc.Models.Repository.CourseRepository
{
    public interface ICourseRepository
    {
        void Delete(int id);
        List<Course> GetAll();
        Course GetById(int id);
        void Insert(Course Course);
        void Save();
        void Update(Course newCourse);
    }
}