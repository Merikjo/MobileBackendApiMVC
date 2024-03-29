﻿using MobileBackendApiMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimesheetMobileXamarin.Models;

namespace MobileBackendApiMVC.Controllers
{
    public class WorkAssignmentController : ApiController
    {
        public string[] GetAll()
        {
            string[] assignmentNames = null;
            MobileWorkDataEntities entities = new MobileWorkDataEntities();
            try
            {
                assignmentNames = (from wa in entities.WorkAssignments
                                   where (wa.Active == true)
                                   select wa.Title).ToArray();
            }
            finally
            {
                entities.Dispose();
            }

            return assignmentNames;
        }

        [HttpPost] //verbiattribuutti
        public bool GetStatus(WorkAssignmentOperationModel input)
        {
            return true;
        }

        [HttpPost] //verbiattribuutti
        public bool PostStatus(WorkAssignmentOperationModel input)
        {
            MobileWorkDataEntities entities = new MobileWorkDataEntities();
            try
            {
                WorkAssignments assignment = (from wa in entities.WorkAssignments
                                              where (wa.Active == true) &&
                                              (wa.Title == input.AssignmentTitle)
                                              select wa).FirstOrDefault();

                if (assignment == null)
                {
                    return false;
                }

                //NumberStyles style;
                //CultureInfo provider;
                //provider = new CultureInfo("fi-FI");
                //string valueString = input.Latitude.ToString("R", CultureInfo.InvariantCulture);
                //style = NumberStyles.AllowDecimalPoint;


                if (input.Operation == "Start")
                {
                    int assignmentId = assignment.Id_WorkAssignment;

                    Timesheets newEntry = new Timesheets()
                    {
                        Id_WorkAssignment = assignmentId,
                        StartTime = DateTime.Now,
                        WorkComplete = false,
                        Active = true,
                        CreatedAt = DateTime.Now
                    };
                    entities.Timesheets.Add(newEntry);
                }
                else if (input.Operation == "Stop")
                {
                    int assignmentId = assignment.Id_WorkAssignment;

                    Timesheets existing = (from ts in entities.Timesheets
                                           where (ts.Id_WorkAssignment == assignmentId) &&
                                           (ts.Active == true) && (ts.WorkComplete == false)
                                           orderby ts.StartTime descending
                                           select ts).FirstOrDefault();

                    if (existing != null)
                    {
                        existing.StopTime = DateTime.Now;
                        existing.WorkComplete = true;
                        existing.LastModifiedAt = DateTime.Now;
                    }
                    else
                    {
                        return false;
                    }
                }
                entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            finally
            {
                entities.Dispose();
            }
            return true;
        }
    }
}
