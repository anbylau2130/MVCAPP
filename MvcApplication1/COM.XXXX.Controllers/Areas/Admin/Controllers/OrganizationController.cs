﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace COM.XXXX.Controllers.Areas.Admin.Controllers
{
    public class OrganizationController : ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrganizationForm()
        {
            return View();
        }
    }
}
