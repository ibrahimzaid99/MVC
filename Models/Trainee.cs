using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Mvc.Models
{
    public class Trainee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Adress { get; set; }

        public int Grade { get; set; }

        [ForeignKey("Department")]
        public int Dept_Id { get; set; }
        
        public virtual Department Department { get; set; }

        public virtual List<CourseResult> Results { get; set; }

    }
}
