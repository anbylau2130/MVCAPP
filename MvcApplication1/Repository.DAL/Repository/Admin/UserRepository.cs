/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：UserRepository
// 文件功能描述：
//
// 创建标识：xycui 2014/12/4 14:30:23
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COM.XXXX.Models;
using COM.XXXX.Models.Admin;
using Repository.Domain;
using Repository.Domain.Infrastructure;

namespace Repository.DAL.Repository
{
    public class UserRepository : Repository<User>
    {
        public UserRepository()
        {
        }

        public UserRepository(TestDbContext dbcontext)
            : base(dbcontext)
        {

        }

        public IList<User> GetAllUsers()
        {
            return dbContext.Users.ToList();
        }

        public User GetUserByUserName(string username, string password)
        {

            return dbContext.Users.ToList()
                .Where(x => x.UserName == username && x.PassWord == password).FirstOrDefault();
        }

        public IList<User> GetUserByOrganizationID(Guid? id)
        {
            return base.Query(x => x.OrganizationID == id).ToList();
        }
    }
}
