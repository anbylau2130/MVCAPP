using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Web.Http;
using COM.XXXX.Models;
using Repository.Domain;
using Repository.Domain.Infrastructure;

namespace COM.XXXX.WebApi
{
    public class ApiControllerBase<R, M> : ApiController 
                where R : Repository<M>,new()
                where M : IModel,new() 
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
                Repository=new R();
                Repository.SetDBContext(DbContext);
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
            public bool Post([FromBody]M model)
            {
                Repository.Insert(model);
                if (UnitOfWork.Save() != 1)
                {
                    return true;
                }
                return false;
            }

            // PUT api/<controller>/5
            public bool Put(Guid id, [FromBody]M model)
            {
                Repository.Update(model);
                if (UnitOfWork.Save() != 1)
                {
                    return true;
                }
                return false;
            }

            // DELETE api/<controller>/5
            public bool Delete(Guid id)
            {
                Repository.Delete(new M { ID = id });
                if (UnitOfWork.Save() != 1)
                {
                    return true;
                }
                return false;
            }
            #endregion
    }
}