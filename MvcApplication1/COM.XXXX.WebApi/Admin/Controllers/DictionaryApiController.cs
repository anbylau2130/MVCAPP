using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Http;
using COM.XXXX.Models.Admin;
using Repository.DAL.Repository.Admin;

namespace COM.XXXX.WebApi.Admin.Controllers
{               
   public class DictionaryApiController: ApiControllerBase<DictionaryRepository, Dictionary>
    {

        public DictionaryApiController()
        {
            base.SetRepository();
        }
       [HttpPost]
       public dynamic GetAllDictionary()
       {
           var list= base.Get();
           return new
           {
               total = list.Count(),
               rows = list
           };
       }
     
    }
}
