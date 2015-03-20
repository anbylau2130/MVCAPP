/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：PrivilegeRepository
// 文件功能描述：
//
// 创建标识：xycui 2014/12/11 14:02:37
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
    public class PrivilegeRepository:Repository<Privilege>
    {
        public PrivilegeRepository()
        {

        }

        public PrivilegeRepository(TestDbContext dbContext) : base(dbContext)
        {

        }
    }
}
