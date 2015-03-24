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

        public class UITree
        {
            public string id { get; set; }
            public string text { get; set; }
            public string iconCls { get; set; }
            public string Checked { get; set; }
            public string state { get; set; }
            public object attributes { get; set; }
            List<UITree> _children = new List<UITree>();
            public List<UITree> children
            {
                get { return _children; }
                set { _children = value; }
            }
        }

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

        [HttpPost]
        public IEnumerable<UITree> GetOrganizationsComboTree(Guid? id)
        { 
            List<UITree> treelst=new List<UITree>();
            List<Organization> lst = new List<Organization>();
            if (string.IsNullOrEmpty(id.ToString()))
            {
                lst.AddRange(Repository.Query(org => org.POrganizationID == null).ToList());
            }
            else
            {
                lst.AddRange(Repository.Query(org => org.POrganizationID == id).ToList());
            }
            foreach (var organization in lst)
            {
                  var tree = new UITree()
                    {
                        id = organization.ID.ToString(),
                        text = organization.Name,
                        iconCls = ""
                    };
                var orgchildren = GetOrganizationsTree(organization.ID);
                foreach (var child in orgchildren)
                {
                    tree.children.Add(new UITree()
                    {
                        id = child.ID.ToString(),
                        text = child.Name,
                        iconCls = ""
                    });
                }
                treelst.Add(tree);
            }

            return treelst;
        }
    }
}
