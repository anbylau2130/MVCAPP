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
    public class DictionaryGroupApiController : ApiControllerBase<DictionaryGroupRepository, DictionaryGroup>
    {
        public DictionaryGroupApiController()
        {
            base.SetRepository();
        }

        /// <summary>
        /// 字典组
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IEnumerable<UITree> GetDictionaryGroupTree() 
        {
            List<DictionaryGroup> groups = base.Get().ToList();
            List<UITree> treelst = new List<UITree>();
            foreach (DictionaryGroup item in groups) 
            {
                treelst.Add(new UITree()
                {
                    id = item.ID.ToString(),
                    text = item.GroupName,
                    attributes = new { GroupCode=item.GroupCode } 
                });
            }
            return treelst;
        }
    }
}
