using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.Http;
using System.Web.UI.WebControls;
using COM.XXXX.EasyUIModels;
using COM.XXXX.Models.Admin;
using Repository.DAL.Repository;
using Repository.DAL.Repository.Admin;
using Repository.Domain.Infrastructure;

namespace COM.XXXX.WebApi.Admin.Controllers
{

    public class OrganizationApiController : ApiControllerBase<OrganizationRepository, Organization>
    {

        public OrganizationApiController()
        {
            base.SetRepository(); 
        }

        /// <summary>
        /// 获取组织机构TreeGrid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IEnumerable<Organization> GetOrganizationsTree(Guid? id)
        {
            List<Organization> lst=new List<Organization>();
            if (string.IsNullOrEmpty(id.ToString()))
            {
                lst.AddRange(Repository.Query(org => org.POrganizationID == null).OrderBy(org=>org.Sort).ToList());
            }
            else
            {
                lst.AddRange(Repository.Query(org => org.POrganizationID == id).OrderBy(org => org.Sort).ToList());
            }

            for (int i = 0; i < lst.Count; i++)
            {
                var children = GetOrganizationsTree(lst[i].ID);
                if (children.Any() && children!=null)
                {
                    lst[i].children = new List<Organization>();
                    lst[i].children .AddRange(children);
                }
            }

            return lst;
        }

        /// <summary>
        /// 获取组织机构Tree
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IEnumerable<UITree> GetOrganizationsComboTree(Guid? id)
        { 
            List<UITree> treelst=new List<UITree>();
            List<Organization> lst = new List<Organization>();
            if (string.IsNullOrEmpty(id.ToString()))
            {
                lst.AddRange(Repository.Query(org => org.POrganizationID == null).OrderBy(org => org.Sort).ToList());
            }
            else
            {
                lst.AddRange(Repository.Query(org => org.POrganizationID == id).OrderBy(org => org.Sort).ToList());
            }
            foreach (var organization in lst)
            {
                  var tree = new UITree()
                    {
                        id = organization.ID.ToString(),
                        text = organization.Name,
                        iconCls = "",
                    };
                var orgchildren = Repository.Query(org => org.POrganizationID == organization.ID).OrderBy(org => org.Sort).ToList();
                foreach (var child in orgchildren)
                {
                    tree.children.Add(new UITree()
                    {
                        id = child.ID.ToString(),
                        text = child.Name,
                        iconCls = "",
                        children= GetOrganizationsComboTree(child.ID).ToList(),
                    });
                }
                treelst.Add(tree);
            }

            return treelst;
        }

        [HttpPost]
        public IEnumerable<UITree> GetOrganizationsAndUser(Guid? id) 
        {
            List<UITree> treelst = new List<UITree>();
            List<Organization> lst = new List<Organization>();
           
            if (string.IsNullOrEmpty(id.ToString()))
            {
                lst.AddRange(Repository.Query(org => org.POrganizationID == null).OrderBy(org => org.Sort).ToList());
            }
            else
            {
                lst.AddRange(Repository.Query(org => org.POrganizationID == id).OrderBy(org => org.Sort).ToList());
            }
            foreach (var organization in lst)
            {
                var tree = new UITree()
                {
                    id = organization.ID.ToString(),
                    text = organization.Name,
                    iconCls = geticon(organization.OrgType),
                 
                };
                var orgchildren = Repository.Query(org => org.POrganizationID == organization.ID).OrderBy(org => org.Sort).ToList();
                
                foreach (var child in orgchildren)
                {
                    var uitree = new UITree()
                    {
                        id = child.ID.ToString(),
                        text = child.Name,
                        iconCls = geticon(organization.OrgType),
                        attributes = new {Type="organization"},
                       
                    };

                    var userlst = GetSubUsersByOrganizationID(child.ID);
                    var orglst = GetOrganizationsAndUser(child.ID).ToList();

                    uitree.children.AddRange(userlst);
                
                    uitree.children.AddRange(orglst);
                  
                    tree.children.Add(uitree);
                }
              
                treelst.Add(tree);
            }

            return treelst;
        }

        /// <summary>
        /// 根据OrganizationID获取Users
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private  List<UITree> GetSubUsersByOrganizationID(Guid id)
        {
            List<User> userlst = new UserApiController().Repository.Query(user => user.OrganizationID == id).ToList();
            List<UITree> usertreelst = new List<UITree>();
            foreach (User user in userlst)
            {
                usertreelst.Add(new UITree()
                {
                    id = user.ID.ToString(),
                    text = user.RealName,
                    iconCls = geticon(""),
                    attributes = new {Type = "user"}
                });
            }
            return usertreelst;
        }

        private string geticon(string orgtype)
        {
            switch (orgtype)
            {
                case "1":
                    return "icon-organise";
                case "2":
                    return "icon-usergroup";
                default :
                    return "icon-man";
            }
        }
    }
}
