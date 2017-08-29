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
    public class AddEmployeeController : ApiController
    { 
        //api/employees
        public HttpResponseMessage Post(EmployeeListResult employee)
        {
            using (var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString))
            {
                try
                {
                    var addEmployeeData = new EmployeeDataAccess();
                    addEmployeeData.Add(employee);

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Add employee blew up");
                }
            }
        }
    }
}



