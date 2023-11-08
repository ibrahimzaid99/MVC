using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Mvc.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Image { get; set; }

        public int Salary { get; set; }

        public string Adress { get; set; }

        //---------------------
        [ForeignKey("Department")]
        public int Dept_Id { get; set; }
       
        public virtual Department Department { get; set; }
        //------------------------

        [ForeignKey("Course")]

        public int Crs_Id { get; set; }

        public virtual Course Course { get; set; }
        //------------------------



    }
}
