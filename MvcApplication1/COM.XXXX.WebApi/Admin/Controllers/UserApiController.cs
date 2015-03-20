using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using COM.XXXX.Models;
using COM.XXXX.Models.Admin;
using Repository.DAL.Repository;

namespace COM.XXXX.WebApi.Admin.Controllers
{
    public class UserApiController : ApiControllerBase<UserRepository, User>
    {

        public UserApiController()
        {
            base.SetRepository();
        }
        [HttpPost]
        public dynamic GetAllUsers()
        {
            var list = base.Get();
            return new
                {
                    total = list.Count(),
                    rows = list

                };
        }


    }
}