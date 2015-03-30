using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using COM.XXXX.EasyUIModels;
using COM.XXXX.Models.Admin;
using Repository.DAL.Repository;

namespace COM.XXXX.WebApi.Admin.Controllers
{
   public  class ModuleApiController: ApiControllerBase<ModuleRepository,Module>
    {
        public ModuleApiController()
        {
            base.SetRepository();
        }

       /// <summary>
       /// 获取Module的Tree列表
       /// </summary>
       /// <returns></returns>
       [HttpPost]
       public dynamic GetModulesTree()
       {
           List<Module> modules=  base.Get().ToList();
           List<UITree> treelst=new List<UITree>(); 
           foreach (Module module in modules)
           {
               treelst.Add(new UITree()
                   {
                       id=module.ID.ToString(),
                       text = module.Name,
                       iconCls = module.PicUrl,
                   });
           }
           return treelst;
       }
    }
}
