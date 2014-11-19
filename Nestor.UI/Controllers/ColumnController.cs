using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nestor.Business;
using Nestor.Models;
using Nestor.Models.Entities;
using Nestor.UI.Models;

namespace Nestor.UI.Controllers
{
    /// <summary>
    /// 栏目控制器
    /// </summary>
    public class ColumnController : Controller
    {
        #region Field
        /// <summary>
        /// 栏目业务
        /// </summary>
        private ColumnBusiness columnBusiness;
        #endregion //Field

        #region Constructor
        public ColumnController()
        {
            this.columnBusiness = new ColumnBusiness();
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 栏目页面
        /// </summary>
        /// <param name="id">栏目ID</param>
        /// <returns></returns>
        public ActionResult Index(int id)
        {
            var column = this.columnBusiness.Get(id);
            if (column == null)
                return HttpNotFound();

            if (column.IsAuth && !User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account", new { returnUrl = "/Column/" + id.ToString() });


            if (column.Type == (int)ColumnType.Parent)
            {
                TopColumnModel data = new TopColumnModel();
                data.Column = column;
                data.Children = column.ChildrenColumns.ToList();

                return View("Index", data);
            }
            else if (column.Type == (int)ColumnType.Link)
            {
                return RedirectToAction("Index", new { controller = "Article", id = column.Link });
            }
            else if (column.Type == (int)ColumnType.General)
            {
                GeneralColumnModel data = new GeneralColumnModel();

                data.Column = column;
                if (column.ParentColumn != null)
                {
                    data.Parent = column.ParentColumn;
                    data.Sibling = data.Parent.ChildrenColumns.OrderBy(r => r.Sort).ToList();
                    data.Articles = column.Articles.OrderByDescending(r => r.PublishDate).OrderByDescending(r => r.AddTime).ToList();
                }
                else
                {
                    data.Parent = null;
                    data.Sibling = new List<Column>();
                    data.Articles = column.Articles.OrderByDescending(r => r.PublishDate).OrderByDescending(r => r.AddTime).ToList();
                }

                return View("List", data);
            }

            return HttpNotFound();
        }
        #endregion //Action
    }
}