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
    public class UpdateEmployeeController : ApiController
    {
        //api/employees
        public HttpResponseMessage Put(int id, EmployeeListResult employee)
        {
 
            try
            {
                var updateEmployeeData = new EmployeeDataAccess();
                updateEmployeeData.Update(employee);


                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Update employee blew up");
            }
            
        }
    }
}
