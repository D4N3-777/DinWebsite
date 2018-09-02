﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Din.Controllers
{
    public class BaseController : Controller
    {
        protected int GetCurrentSessionId()
        {
            return Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type.Equals("ID")).Value);
        }
    }
}