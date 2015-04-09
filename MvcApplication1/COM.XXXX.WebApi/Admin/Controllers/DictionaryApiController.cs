using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Http;
using COM.XXXX.Models.Admin;
using Repository.DAL.Repository.Admin;
using COM.XXXX.EasyUIModels;

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
       /// <summary>
       /// 获取组织机构Tree
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       [HttpPost]
       public IEnumerable<UITree> GetDictionaryTree(Guid? id)
       {
           List<UITree> treelst = new List<UITree>();
           List<Dictionary> lst = new List<Dictionary>();
           if (string.IsNullOrEmpty(id.ToString())) 
           {
               lst.AddRange(Repository.Query(dic => dic.PDictionaryID == null).OrderBy(dic => dic.Sort).ToList());
           }
           else
           {
               lst.AddRange(Repository.Query(dic => dic.PDictionaryID == id).OrderBy(dic => dic.Sort).ToList());
           }
           foreach (var item in lst) 
           {
               var tree = new UITree()
               {
                   id = item.ID.ToString(),
                   text = item.Title,
                   iconCls = item.iconCls,
               };
               var dicchildren = Repository.Query(dic => dic.PDictionaryID == item.ID).OrderBy(dic => dic.Sort).ToList();
               foreach (var child in dicchildren)
               {
                   tree.children.Add(new UITree()
                   {
                       id = child.ID.ToString(),
                       text = child.Title,
                       iconCls = child.iconCls,
                       children = GetDictionaryTree(child.ID).ToList(),
                   });
               }
               treelst.Add(tree);
           }

           return treelst;
       }
    }
}
