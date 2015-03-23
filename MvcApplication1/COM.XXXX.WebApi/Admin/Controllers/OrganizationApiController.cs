using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using COM.XXXX.Models.Admin;
using Repository.DAL.Repository.Admin;

namespace COM.XXXX.WebApi.Admin.Controllers
{

    public class OrganizationApiController : ApiControllerBase<OrganizationRepository, Organization>
    {
        public OrganizationApiController()
        {
            base.SetRepository(); 
        }

        [HttpPost]
        public IEnumerable<Organization> GetOrganizationsTree(Guid? id)
        {
            List<Organization> lst=new List<Organization>();
            if (string.IsNullOrEmpty(id.ToString()))
            {
                lst.AddRange(Repository.Query(org => org.POrganizationID == null).ToList());
            }
            else
            {
                lst.AddRange(Repository.Query(org=>org.POrganizationID==id).ToList());
            }

            for (int i = 0; i < lst.Count; i++)
            {
                var children = GetOrganizationsTree(lst[i].ID);
                if (children.Count() > 0 && children!=null)
                {
                    lst[i].children = new List<Organization>();
                    lst[i].children .AddRange(children);
                }
            }

            return lst;
        }
    }
}
