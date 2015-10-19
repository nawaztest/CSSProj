using CSSProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSSProj.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserModel> userModelList = new List<UserModel>();
            UserModel um = new UserModel();
            userModelList = um.GetUsers();
            return View(userModelList);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            UserModel um = new UserModel();
            um = um.GetUserById(id);
            return View(um);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                string userCode = collection["UserCode"].ToString();
                string userName = collection["UserName"].ToString();
                string password = collection["Password"].ToString();

                UserModel um = new UserModel();
                um.UserCode = userCode;
                um.UserName = userName;
                um.Password = password;

                um.AddUser(um);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            UserModel um = new UserModel();
            um = um.GetUserById(id);
            return View(um);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                UserModel um = new UserModel();
                um.UserCode = collection["UserCode"].ToString();
                um.UserName = collection["UserName"].ToString();
                um.Password = collection["Password"].ToString();

                um.UpdateUser(um, id);
          
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            UserModel um = new UserModel();
            um = um.GetUserById(id);
            return View(um);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                UserModel um = new UserModel();

                um.RemoverUser(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
