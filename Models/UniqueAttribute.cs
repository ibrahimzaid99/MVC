using System.ComponentModel.DataAnnotations;

namespace Project_Mvc.Models
{
    public class UniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string uniqueName = value.ToString();
            ProjectContext context = new ProjectContext();
            Course crsFromRequest = (Course)validationContext.ObjectInstance;
           Course crsFromDB= context.Courses.FirstOrDefault(n => n.Name==uniqueName && n.Dept_Id == crsFromRequest.Dept_Id);
            if (crsFromDB == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Name Already Found"); 
            }
            
        }
    }
}
