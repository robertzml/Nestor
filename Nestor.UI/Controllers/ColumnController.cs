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

        private int pageSize = 15;
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
        public ActionResult Index(int id, int page = 1)
        {
            var column = this.columnBusiness.Get(id);
            if (column == null)
                return HttpNotFound();

            if (column.IsAuth && !User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account", new { returnUrl = "/Column/" + id.ToString() });

            if (page < 1)
                page = 1;

            if (column.Type == (int)ColumnType.Parent)
            {
                if (column.ParentColumn == null)
                    return HttpNotFound();

                TopColumnModel data = new TopColumnModel();
                data.Parent = column.ParentColumn;
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
                    data.TotalCount = column.Articles.Count();
                    data.CurrentPage = page;
                    data.TotalPage = (data.TotalCount + pageSize - 1) / pageSize;
                    data.Articles = column.Articles.OrderByDescending(r => r.PublishDate).OrderByDescending(r => r.AddTime).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                }
                else
                {
                    data.Parent = null;
                    data.Sibling = new List<Column>();
                    data.TotalCount = column.Articles.Count();
                    data.CurrentPage = page;
                    data.TotalPage = (data.TotalCount + pageSize - 1) / pageSize;
                    data.Articles = column.Articles.OrderByDescending(r => r.PublishDate).OrderByDescending(r => r.AddTime).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                }

                return View("List", data);
            }
            else if (column.Type == (int)ColumnType.Outter)
            {
                Response.Redirect(column.Link);
            }

            return HttpNotFound();
        }
        #endregion //Action
    }
}