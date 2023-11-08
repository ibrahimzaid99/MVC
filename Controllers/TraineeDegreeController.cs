using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Mvc.Models;
using Project_Mvc.ViewModel;

namespace Project_Mvc.Controllers
{
    public class TraineeDegreeController : Controller
    {
        ProjectContext context = new ProjectContext();
        public IActionResult ShowResult(int Id, int Cours_Id)
        {
            var TraineeVm = new TraineeDegreeInCourseWithColorViewModel();
            CourseResult TraineeModel = context.CourseResults.Where(n => n.Trainee_Id == Id && n.Crs_Id == Cours_Id).Include(n => n.Trainee).Include(n => n.Course).SingleOrDefault(); 

            TraineeVm.Trainee_Id = TraineeModel.Id;
            TraineeVm.Trainee_Name = TraineeModel.Trainee.Name;
            TraineeVm.Trainee_Course = TraineeModel.Course.Name;
            TraineeVm.Trainee_Grade = TraineeModel.Degree.ToString();

            int MinimumDegree = TraineeModel.Course.MinimumDegree;

            if (TraineeModel.Degree >= MinimumDegree)
                TraineeVm.Color = "green";
            else
                TraineeVm.Color = "red";
            
            return View("ShowResult",TraineeVm);
        }
    }
}
