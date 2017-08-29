using Dapper;
using OurFirstApi.DataAccess;
using OurFirstApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OurFirstApi.Controllers
{
    public class DeleteEmployeeController : ApiController
    {
        //api/employees
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var deleteEmployeeData = new EmployeeDataAccess();
                deleteEmployeeData.Delete(id);
            
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Delete employee blew up");
            }
        }       
    }
}
