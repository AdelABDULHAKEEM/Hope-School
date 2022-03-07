using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hope_School.Controllers.API
{
    [RoutePrefix("api/Student")]
    public class StudentController : ApiController
    {
        SchoolDBEntities DB = new SchoolDBEntities();
        [Route("Login")]
        [HttpPost]
        public IHttpActionResult StudentLogin(Student login)
        {
            var log = DB.Students.Where(x => x.StudentID.Equals(login.StudentID)).FirstOrDefault();

            if (log == null)
            {
                return Ok(new { status = 401, isSuccess = false, message = "Invalid User", });
            }
            else

                return Ok(new { status = 200, isSuccess = true, message = "User Login successfully", UserDetails = log });
        }
        [Route("InsertStudent")]
        [HttpPost]
        public object InsertStudent(Student Reg)
        {
            try
            {
                Student EL = new Student();
                if (EL.StudentID == 0)
                {
                    EL.StudentName = Reg.StudentName;
                    EL.StudentAddress = Reg.StudentAddress;
                   
                    DB.Students.Add(EL);
                    DB.SaveChanges();
                    return new 
                    { Status = "Success", Message = "Record SuccessFully Saved." };
                }
            }
            catch (Exception)
            {

                throw;
            }
            return new 
            { Status = "Error", Message = "Invalid Data." };
        }
    }
}
