using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;
using OurFirstApi.Models;
using OurFirstApi.DataAccess;

namespace OurFirstApi.Controllers
{
    //api/employees
    public class EmployeesController : ApiController
    {
        //api/employees
        public HttpResponseMessage Get()
        {
          
                try
                {
                    var allEmployeeData = new EmployeeDataAccess();
                    var employees = allEmployeeData.GetAll();

                    return Request.CreateResponse(HttpStatusCode.OK, employees);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Query blew up");
                }
            }
        

        //api/employees/3000
        public HttpResponseMessage Get(int id)
        {
            {
                try
                {
                    var employeeData = new EmployeeDataAccess();
                    var employee = employeeData.Get(id);    
                    if (employee == null)
                        {
                            return Request.CreateErrorResponse(HttpStatusCode.NotFound,$"Employee with the Id {id} was not found");
                        }

                        return Request.CreateResponse(HttpStatusCode.OK, employee);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }
            }
        }

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
                                                            new { FirstName = employee.FirstName, LastName = employee.LastName });


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

