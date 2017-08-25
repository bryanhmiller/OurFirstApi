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
                    connection.Open();

                    var result = connection.Execute("Insert into Employee(Firstname, LastName) " +
                                                            "Values(@firstName,@lastName)",
                                                            new { FirstName = employee.FirstName, LastName = employee.LastName});


                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Add employee blew up");
                }
            }
        }
    }
}



