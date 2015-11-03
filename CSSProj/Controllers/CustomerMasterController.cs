using CSSProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSSProj.Controllers
{
    public class CustomerMasterController : Controller
    {
        // GET: CustomerMaster
        public ActionResult Index()
        {
            List<CustomerModel> custs = new List<CustomerModel>();
            CustomerModel cm = new CustomerModel();
            custs = cm.GetAllCusts();
            return View(custs);
        }

        // GET: CustomerMaster/Details/5
        public ActionResult Details(int id)
        {
            CustomerModel cm = new CustomerModel();
            cm = cm.GetCustomerById(id);
            return View(cm);
        }

        // GET: CustomerMaster/Create
        public ActionResult Create()
        {
            var moveToList = new List<SelectListItem>();
            MoveToModel moveModel = new MoveToModel();
            
            moveModel.MoveTo = "AMC Customer";
            moveToList.Add(new SelectListItem { Text = moveModel.MoveTo, Value = moveModel.MoveTo });

            moveModel = new MoveToModel();
            moveModel.MoveTo = "Warranty List";
            moveToList.Add(new SelectListItem { Text = moveModel.MoveTo, Value = moveModel.MoveTo });

            moveModel = new MoveToModel();
            moveModel.MoveTo = "MAC Inprocess";
            moveToList.Add(new SelectListItem { Text = moveModel.MoveTo, Value = moveModel.MoveTo });

            moveModel = new MoveToModel();
            moveModel.MoveTo = "Inactive Customer";
            moveToList.Add(new SelectListItem { Text = moveModel.MoveTo, Value = moveModel.MoveTo });
            ViewBag.MoveToList = moveToList;
            var cm = new CustomerModel()
            {
                listMoveTo = moveToList
            };
            return View(cm);
        }

        // POST: CustomerMaster/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var cm = new CustomerModel()
                {
                    CustomerCode = collection["CustomerCode"].ToString(),
                    CustomerName = collection["CustomerName"].ToString(),
                    ContactPersonName = collection["ContactPersonName"].ToString(),
                    AddressLine1 = collection["AddressLine1"].ToString(),
                    AddressLine2 = collection["AddressLine2"].ToString(),
                    AddressLine3 = collection["AddressLine3"].ToString(),
                    Telephone1 = collection["Telephone1"].ToString(),
                    Telephone2 = collection["Telephone1"].ToString(),
                    CountryCode = collection["CountryCode"].ToString(),
                    CountryName = collection["CountryName"].ToString(),
                    Fax1 = collection["Fax1"].ToString(),
                    Fax2 = collection["Fax2"].ToString(),
                    Email = collection["Email"].ToString(),
                    Remarks = collection["Remarks"].ToString(),
                    CustomerType = collection["MoveToList"].ToString(),
                    InstallationDate = collection["InstallationDate"].ToString(),
                    ExpiryDate = collection["ExpiryDate"].ToString()
                };
                cm.AddCust(cm);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Response.Write(ex.ToString());
                return View();
            }
        }

        // GET: CustomerMaster/Edit/5
        public ActionResult Edit(int id)
        {
            var moveToList = new List<SelectListItem>();
            MoveToModel moveModel = new MoveToModel();

            moveModel.MoveTo = "AMC Customer";
            moveToList.Add(new SelectListItem { Text = moveModel.MoveTo, Value = moveModel.MoveTo });

            moveModel = new MoveToModel();
            moveModel.MoveTo = "Warranty List";
            moveToList.Add(new SelectListItem { Text = moveModel.MoveTo, Value = moveModel.MoveTo });

            moveModel = new MoveToModel();
            moveModel.MoveTo = "MAC Inprocess";
            moveToList.Add(new SelectListItem { Text = moveModel.MoveTo, Value = moveModel.MoveTo });

            moveModel = new MoveToModel();
            moveModel.MoveTo = "Inactive Customer";
            moveToList.Add(new SelectListItem { Text = moveModel.MoveTo, Value = moveModel.MoveTo });
            ViewBag.MoveToList = moveToList;
            CustomerModel cm = new CustomerModel();
            cm = cm.GetCustomerById(id);
            cm.listMoveTo = moveToList;
            return View(cm);
        }

        // POST: CustomerMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var moveToList = new List<SelectListItem>();
                MoveToModel moveModel = new MoveToModel();

                moveModel.MoveTo = "AMC Customer";
                moveToList.Add(new SelectListItem { Text = moveModel.MoveTo, Value = moveModel.MoveTo });

                moveModel = new MoveToModel();
                moveModel.MoveTo = "Warranty List";
                moveToList.Add(new SelectListItem { Text = moveModel.MoveTo, Value = moveModel.MoveTo });

                moveModel = new MoveToModel();
                moveModel.MoveTo = "MAC Inprocess";
                moveToList.Add(new SelectListItem { Text = moveModel.MoveTo, Value = moveModel.MoveTo });

                moveModel = new MoveToModel();
                moveModel.MoveTo = "Inactive Customer";
                moveToList.Add(new SelectListItem { Text = moveModel.MoveTo, Value = moveModel.MoveTo });
                ViewBag.MoveToList = moveToList;
                // TODO: Add update logic here
                var cm = new CustomerModel()
                {
                    CustomerCode = collection["CustomerCode"].ToString(),
                    CustomerName = collection["CustomerName"].ToString(),
                    ContactPersonName = collection["ContactPersonName"].ToString(),
                    AddressLine1 = collection["AddressLine1"].ToString(),
                    AddressLine2 = collection["AddressLine2"].ToString(),
                    AddressLine3 = collection["AddressLine3"].ToString(),
                    Telephone1 = collection["Telephone1"].ToString(),
                    Telephone2 = collection["Telephone1"].ToString(),
                    CountryCode = collection["CountryCode"].ToString(),
                    CountryName = collection["CountryName"].ToString(),
                    Fax1 = collection["Fax1"].ToString(),
                    Fax2 = collection["Fax2"].ToString(),
                    Email = collection["Email"].ToString(),
                    Remarks = collection["Remarks"].ToString(),
                    CustomerType = collection["MoveToList"].ToString(),
                    InstallationDate = collection["InstallationDate"].ToString(),
                    ExpiryDate = collection["ExpiryDate"].ToString()
                };
                cm.listMoveTo = moveToList;
                cm.UpdateCustByID(cm, id);
                //ViewData["SelectedType"] = Helper.SetSelectedValue(moveToList, cm.CustomerType);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
                return View();
            }
        }

        // GET: CustomerMaster/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerMaster/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
