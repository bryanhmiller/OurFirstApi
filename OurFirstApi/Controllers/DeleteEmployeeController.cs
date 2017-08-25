using Dapper;
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
        public HttpResponseMessage Put(int id, EmployeeListResult employee)
        {
            using (var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    var result = connection.Execute("delete from Employee where EmployeeId = @EmployeeId",
                                                    new { EmployeeId = employee.EmployeeId});

                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Delete employee blew up");
                }
            }
        }

    }
}
