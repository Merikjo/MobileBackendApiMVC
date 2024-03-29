﻿using MobileBackendApiMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileBackendApiMVC.Controllers
{
    public class EmployeeController : ApiController
    {
        public string[] GetAll()
        {
            string[] employeeNames = null;
            MobileWorkDataEntities entities = new MobileWorkDataEntities();
            try
            {
                employeeNames = (from e in entities.Employees
                                 where (e.Active == true)
                                 select e.FirstName + " " +
                                 e.LastName).ToArray();
            }
            finally
            {
                entities.Dispose();
            }

            return employeeNames;
        }

        public byte[] GetEmployeeImage(string employeeName)
        {
            MobileWorkDataEntities entities = new MobileWorkDataEntities();
            try
            {
                string[] nameParts = employeeName.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string first = nameParts[0];
                string last = nameParts[1];
                byte[] bytes = (from e in entities.Employees
                                where (e.Active == true) &&
                                (e.FirstName == first) &&
                                (e.LastName == last)
                                select e.EmployeePicture).FirstOrDefault();

                return bytes;
            }
            finally
            {
                entities.Dispose();
            }
        }

        public string PutEmployeeImage()
        {
            MobileWorkDataEntities entities = new MobileWorkDataEntities();
            try
            {
                Employees newEmployee = new Employees()
                {
                    FirstName = "Teppo",
                    LastName = "Testaaja",

                    //EmployeePicture = File.ReadAllBytes(@"C:\TEMP\Matti.png")
                    EmployeePicture = File.ReadAllBytes(@"E:\VS2019-Xamarin\MobileBackendMVC-Api\MobileBackendMVC-Api\Images\Matti.png")
                };
                entities.Employees.Add(newEmployee);
                entities.SaveChanges();

                return "OK!";
            }
            finally
            {
                entities.Dispose();
            }

            return "Error";
        }
    }
}
