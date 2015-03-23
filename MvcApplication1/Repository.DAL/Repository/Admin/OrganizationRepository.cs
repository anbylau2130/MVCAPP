using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COM.XXXX.Models.Admin;
using Repository.Domain;
using Repository.Domain.Infrastructure;

namespace Repository.DAL.Repository.Admin
{
    public class OrganizationRepository : Repository<Organization>
    {
          public OrganizationRepository()
        {

        }

          public OrganizationRepository(TestDbContext dbContext)
              : base(dbContext)
        {

        }

        public IEnumerable<Organization> GetOrganiztionByPID(Guid pid)
        {
            return base.Query(org => org.POrganizationID == pid);
        }
    }
}
