namespace Project_Mvc.Models.Repository.DepartmentRepository
{
    public interface IDepartmentRepository
    {
        void Delete(int id);
        List<Department> GetAll();
        Department GetById(int id);
        void Insert(Department department);
        void Save();
        void Update(Department newDepartment);
    }
}