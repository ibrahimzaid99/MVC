namespace Project_Mvc.Models.Repository.DepartmentRepository
{
    public class DepartmentRepository : IDepartmentRepository
    {

        ProjectContext context;

        public DepartmentRepository(ProjectContext _Context)
        {
            context = _Context;
        }
        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(n => n.Id == id);
        }
        public void Update(Department newDepartment)
        {
            context.Update(newDepartment);
        }

        public void Delete(int id)
        {
            Department department = GetById(id);
            context.Remove(department);
        }

        public void Insert(Department department)
        {
            context.Departments.Add(department);
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
