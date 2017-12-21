﻿using System;
using System.Web.Mvc;
using DinWebsite.Logic;
using DinWebsite.Models;
using DinWebsite.Models.AD;
using DinWebsite.Models.Exceptions;

namespace DinWebsite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["PermissionLevel"] != null)
            {
                if ((string)Session["PermissionLevel"] == "admin")
                {
                    return View("../UserPanel/index");
                }
                else if ((string)Session["PermissionLevel"] == "user")
                {
                    return View("../UserPanel/index");
                }
            }
            return View("index");
        }

        [HttpPost]
        public ActionResult Login(LoginData data)
        {
            try
            {
                Session.Clear();
                Tuple<bool, ADObject> result = LoginSystem.Login(data.Username, data.Password);
                if (result.Item1)
                {
                    Session["UserData"] = result.Item2;
                    Session["Name"] = result.Item2.Name;
                    var adUser = result.Item2 as ADUser;
                    if (adUser != null)
                        foreach (var v in adUser.Groups)
                        {
                            if (v.DistinguishedName.ToLower().Contains("domain admins"))
                            {
                                Session["PermissionLevel"] = "admin";
                                return View("../UserPanel/index");
                            }
                            else if (v.DistinguishedName.ToLower().Contains("kodi users"))
                            {
                                Session["PermissionLevel"] = "user";
                                return View("../UserPanel/index");
                            }
                        }
                }
                Session["failed"] = 1;
                Session["failedString"] = "Username or Password is incorrect";
                return RedirectToAction("Index");
            }
            catch (LoginException ex)
            {
                Session["failed"] = 1;
                Session["failedString"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return View("Logout");
        }
    }
}