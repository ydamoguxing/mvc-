using StudentSystem.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.UI.WebControls;

namespace StudentSystem.WebApi.Controllers
{
    [EnableCors("*", "*", "*", "*")]
    public class GradeController : ApiController
    {
        private readonly IGradeManager manager;
        public GradeController(IGradeManager man)
        {
            this.manager = man;
        }
      
        public IHttpActionResult GetAll()
        {
            return Ok(manager.GetAll());
        }
    }
}
