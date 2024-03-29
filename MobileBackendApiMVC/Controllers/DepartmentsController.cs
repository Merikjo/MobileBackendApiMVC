﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MobileBackendApiMVC.Models;
using MobileBackendApiMVC.ViewModels;

namespace MobileBackendApiMVC.Controllers
{
    public class DepartmentsController : Controller
    {
        private MobileWorkDataEntities db = new MobileWorkDataEntities();

        // GET: Departments
        public ActionResult Index()
        {
            List<DepartmentsViewModel> model = new List<DepartmentsViewModel>();

            MobileWorkDataEntities entities = new MobileWorkDataEntities();

            try
            {
                List<Departments> departments = entities.Departments.OrderBy(Departments => Departments.DepartmentName).ToList();

                // muodostetaan näkymämalli tietokannan rivien pohjalta       
                foreach (Departments department in departments)
                {
                    DepartmentsViewModel view = new DepartmentsViewModel();
                    view.Id_Department = department.Id_Department;
                    view.DepartmentName = department.DepartmentName;

                    model.Add(view);
                }
            }
            finally
            {
                entities.Dispose();
            }

            return View(model);
        }//Index

        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
            DepartmentsViewModel model = new DepartmentsViewModel();

            MobileWorkDataEntities entities = new MobileWorkDataEntities();

            try
            {
                Departments departmentdetail = entities.Departments.Find(id);

                if (departmentdetail == null)
                {
                    return HttpNotFound();
                }

                // muodostetaan näkymämalli tietokannan rivien pohjalta       
                DepartmentsViewModel view = new DepartmentsViewModel();
                view.Id_Department = departmentdetail.Id_Department;
                view.DepartmentName = departmentdetail.DepartmentName;

                model = view;
            }

            finally
            {
                entities.Dispose();
            }

            return View(model);
        }//details


        // GET: Departments/Create
        public ActionResult Create()
        {
            MobileWorkDataEntities entities = new MobileWorkDataEntities();

            DepartmentsViewModel model = new DepartmentsViewModel();

            return View(model);
        }//create




        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentsViewModel model)
        {
            MobileWorkDataEntities entities = new MobileWorkDataEntities();


            Departments dep = new Departments();
            dep.DepartmentName = model.DepartmentName;

            db.Departments.Add(dep);

            try
            {
                db.SaveChanges();
            }

            catch (Exception ex)
            {
            }

            return RedirectToAction("Index");
        }//create




        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departments departmentdetail = db.Departments.Find(id);
            if (departmentdetail == null)
            {
                return HttpNotFound();
            }

            DepartmentsViewModel view = new DepartmentsViewModel();
            view.Id_Department = departmentdetail.Id_Department;
            view.DepartmentName = departmentdetail.DepartmentName;


            //ViewBag.Id_Employee = new SelectList(db.Employees, "Id_Employee", "FirstName", departments.Id_Employee);

            return View(view);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentsViewModel model)
        {
            Departments dep = new Departments();
            dep.DepartmentName = model.DepartmentName;

            db.SaveChanges();
            return View("Index");
        }//edit



        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departments departmentdetail = db.Departments.Find(id);
            if (departmentdetail == null)
            {
                return HttpNotFound();
            }
            DepartmentsViewModel view = new DepartmentsViewModel();
            view.Id_Department = departmentdetail.Id_Department;
            view.DepartmentName = departmentdetail.DepartmentName;

            return View(view);
        }


        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departments departments = db.Departments.Find(id);
            db.Departments.Remove(departments);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
