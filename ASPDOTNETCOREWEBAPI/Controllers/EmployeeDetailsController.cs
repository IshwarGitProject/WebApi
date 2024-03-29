﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ASPDOTNETCOREWEBAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ASPDOTNETCOREWEBAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeDetailsController : ControllerBase
    {
        IConfiguration _iconfiguration;
        public EmployeeDetailsController(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }
        [HttpGet]
        public List<EmployeeDetails> GetEmployeeDetails()
        {
            List<EmployeeDetails> odata = new List<EmployeeDetails>();
            string connectionString = _iconfiguration.GetValue<string>("Data:ConnectionString");
            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataReader rdr;
            SqlCommand cmd = new SqlCommand("getAllEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            rdr = cmd.ExecuteReader();
            

            while (rdr.Read())
            {
                EmployeeDetails emp = new EmployeeDetails();
                emp.Id = Convert.ToInt32(rdr["Id"]);
                emp.EmpName = Convert.ToString(rdr["EmpName"]);
                emp.EmailId = Convert.ToString(rdr["EmailId"]);
                emp.Address = Convert.ToString(rdr["Address"]);
                emp.DateOfBirth = Convert.ToDateTime(rdr["DOB"]);
                emp.Gender = Convert.ToInt32(rdr["Gender"]);
                emp.PinCode = Convert.ToInt32(rdr["PinCode"]);
                odata.Add(emp);
            }
            rdr.Close();
            conn.Close();



            //odata.Add(new EmployeeDetails
            //{
            //    Id = 1,
            //    EmpName = "Ishwar",
            //    EmailId = "Software",
            //    Address = "SSE",
            //    DateOfBirth = Convert.ToDateTime("10/10/2019")
            //});
            return odata;
        }
        [HttpPost]
        public string InsertEmployeeDetails (EmployeeDetails emp)
        {
            string connectionString = _iconfiguration.GetValue<string>("Data:ConnectionString");
            SqlConnection conn = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand("InsertEmployeeDetails", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                // define parameters and their values
                cmd.Parameters.AddWithValue("@EmpName", emp.EmpName);
                cmd.Parameters.AddWithValue("@DOB", emp.DateOfBirth);
                cmd.Parameters.AddWithValue("@EmailId", emp.EmailId);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Address", emp.Address);
                cmd.Parameters.AddWithValue("@PinCode", emp.PinCode);                

                // open connection, execute INSERT, close connection
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return "";
        }
    }
}