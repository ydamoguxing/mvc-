using StudentSystem.BLL;
using StudentSystem.IBLL;
using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem.Mvc.Models
{
    public class GradeController : Controller
    {
        private readonly IGradeManager manager;
        public GradeController(IGradeManager man)
        {
            manager = man;
        }
        // GET: Grade
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateGrade(Models.GradeVm gradevm)
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateGrade(string name="提升班")
        {
            if (ModelState.IsValid)
            {
               await manager.CreateAsync(new Grade() { GradeName = name });
                return Content("添加成功");
            }
            return View();
        }
    }
}