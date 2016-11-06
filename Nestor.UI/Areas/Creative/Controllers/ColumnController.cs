using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nestor.Business;
using Nestor.Models;
using Nestor.Models.Entities;
using Nestor.UI.Areas.Creative.Models;

namespace Nestor.UI.Areas.Creative.Controllers
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
        /// 栏目主页
        /// </summary>
        /// <param name="id"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Index(int id, int page = 1)
        {
            var column = this.columnBusiness.Get(id);
            if (column == null)
                return HttpNotFound();

            if (column.Type != (int)ColumnType.Creative)
                return HttpNotFound();

            if (page < 1)
                page = 1;

            CreativeColumnModel model = new CreativeColumnModel();
            model.Column = column;
            //model.Sibling = column.ParentColumn.ChildrenColumns.OrderBy(r => r.Sort).ToList();
            model.TotalCount = column.Articles.Count();
            model.CurrentPage = page;
            model.TotalPage = (model.TotalCount + pageSize - 1) / pageSize;
            model.Articles = column.Articles.OrderByDescending(r => r.PublishDate).OrderByDescending(r => r.AddTime).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            
            return View(model);
        }
        #endregion //Action
    }
}