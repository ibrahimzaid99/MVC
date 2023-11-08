using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Mvc.Models
{
    public class Course
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        [Unique]
        public string Name { get; set; }

        [Required]
        [Range(minimum:50, maximum:100 ,ErrorMessage ="The Degree Must Be Between 50 To 100")]
        public int Degree { get; set; }

        [Required(ErrorMessage ="Hours Is Required")]
        public int Hours { get; set; }

        [Display (Name = "Minimum Degree")]
        [Remote("CheckDegree","Courses",
         AdditionalFields ="Degree",
         ErrorMessage = "The MinimumDegree Must Be Less Than Degree")]
        public int MinimumDegree { get; set; }

        
        [ForeignKey("Department")]
        [Display (Name ="Department")]
        public int Dept_Id { get; set; }
        public virtual Department? Department { get; set; }

        public virtual List<Instructor>? Instructors { get; set; } 

        public virtual List<CourseResult>? Courses { get; set; } 
    }
}
