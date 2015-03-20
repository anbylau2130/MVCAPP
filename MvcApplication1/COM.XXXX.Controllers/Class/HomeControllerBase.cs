using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Repository.Domain;
using Repository.Domain.Infrastructure;
using System.Web.Mvc;

namespace Com.XXXX.Class
{
    public class HomeControllerBase:Controller
    {
        protected IUnitOfWork UnitOfWork;
        protected TestDbContext DbContext;

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding)
        {
            return new CustomJsonResult { Data = data, ContentType = contentType, ContentEncoding = contentEncoding };
        }
        public new JsonResult Json(object data, JsonRequestBehavior jsonRequest)
        {
            return new CustomJsonResult { Data = data, JsonRequestBehavior = jsonRequest };
        }
        public new JsonResult Json(object data)
        {
            return new CustomJsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public HomeControllerBase()
        {
            DbContext = new TestDbContext();
            UnitOfWork = new UnitOfWork(DbContext);
        }
    }
}