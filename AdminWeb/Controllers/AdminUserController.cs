using AdminWeb.core;
using AdminWeb.Core;
using AdminWeb.Models;
using Common.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Model.admin;
using Model.client;
using Model;

namespace AdminWeb.Controllers
{

    public class AdminUserController : BaseController
    {
        [HttpGet]
        public IActionResult LoginOut()
        {
            Passport.ClearPassport();

            return Redirect("/Home/Login");
        }
    }
}
