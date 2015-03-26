using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Web.Http;
using COM.XXXX.EasyUIModels;
using COM.XXXX.Models;
using Newtonsoft.Json;
using Repository.Domain;
using Repository.Domain.Infrastructure;

namespace COM.XXXX.WebApi
{
    public class ApiControllerBase<R, M> : ApiController
        where R : Repository<M>, new()
        where M : IModel, new()
    {
        public R Repository;
        protected IUnitOfWork UnitOfWork { get; set; }
        protected TestDbContext DbContext { get; set; }

        /// <summary>
        /// 构建DbContext，UnitOfWork
        /// </summary>
        public ApiControllerBase()
        {
            DbContext = new TestDbContext();
            UnitOfWork = new UnitOfWork(DbContext);
        }

        /// <summary>
        /// 初始化Repository类
        /// </summary>
        public void SetRepository()
        {
            Repository = new R();
            Repository.SetDBContext(DbContext);
        }

        /// <summary>
        /// 让webapi始终返回json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public HttpResponseMessage toJson(Object obj)
        {
            String str;
            if (obj is String || obj is Char)
            {
                str = obj.ToString();
            }
            else
            {
                //JavaScriptSerializer serializer = new JavaScriptSerializer();
                //str = serializer.Serialize(obj);
                str = JsonConvert.SerializeObject(obj);
            }
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }

        #region WebApi 函数
        // GET api/<controller> 
        public IEnumerable<M> Get()
        {
            return Repository.List();
        }

        // GET api/<controller>/5

        public M Get(Guid id)
        {
            return Repository.Query(M => M.ID == id).First();
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]M model)
        {
            Repository.Insert(model);

            if (UnitOfWork.Save() == 1)
            {
                return toJson(new UISuccess() { success = true, message = "恭喜你,~O(∩_∩)O~编辑成功了耶！" });
            }
            return toJson(new UISuccess() { success = false, message = "Σ( ° △ °|||)︴~,由于某种原因导致数据失败，请稍后重新操作！" });
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(Guid id, [FromBody]M model)
        {
            model.ID = id;
            Repository.Update(model);
            if (UnitOfWork.Save() == 1)
            {
                return  toJson(new UISuccess() { success = true, message = "恭喜你,~O(∩_∩)O~更新成功了耶！" });
            }
            return toJson(new UISuccess() { success = false, message = "Σ( ° △ °|||)︴~,由于某种原因导致数据失败，请稍后重新操作！" });
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(Guid id)
        {
            Repository.Delete(new M { ID = id });
            if (UnitOfWork.Save() == 1)
            {
                return toJson(new UISuccess() { success = true, message = "恭喜你,~O(∩_∩)O~删除成功了耶！" });
            }
            return toJson(new UISuccess() { success = false, message = "Σ( ° △ °|||)︴~,由于某种原因导致数据失败，请稍后重新操作！" }); ;
        }
        #endregion
    }
}