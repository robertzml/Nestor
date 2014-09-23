using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nestor.Business;
using Nestor.Common;
using Nestor.Models;
using Nestor.Models.Entities;
using Nestor.UI.Filters;
using Nestor.UI.Services;

namespace Nestor.UI.Areas.Admin.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    [EnhancedAuthorize]
    public class UserController : Controller
    {
        #region Field
        /// <summary>
        /// 用户业务
        /// </summary>
        private UserBusiness userBusiness;
        #endregion //Field

        #region Constructor
        public UserController()
        {
            this.userBusiness = new UserBusiness();
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            User user = PageService.GetCurrentUser(User.Identity.Name);
            var data = this.userBusiness.GetList(user.UserType);

            return View(data);
        }

        /// <summary>
        /// 用户添加
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 用户添加
        /// </summary>
        /// <param name="model">用户模型</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(User model)
        {
            if (ModelState.IsValid)
            {
                string confirm = Request.Form["confirmPassword"];

                if (confirm != model.Password)
                {
                    ModelState.AddModelError("", "两次输入密码不一致");
                    return View(model);
                }

                model.Status = 0;

                ErrorCode result = this.userBusiness.Create(model);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "添加用户成功";
                    return RedirectToAction("List");
                }
                else
                {
                    ModelState.AddModelError("", "添加用户失败, " + result.DisplayName());
                }
            }

            return View(model);
        }

        /// <summary>
        /// 用户编辑
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = this.userBusiness.Get(id);
            return View(data);
        }

        /// <summary>
        /// 用户编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(User model)
        {
            if (ModelState.IsValid)
            {
                ErrorCode result = this.userBusiness.Update(model);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "编辑用户成功";
                    return RedirectToAction("List");
                }
                else
                {
                    ModelState.AddModelError("", "编辑用户失败, " + result.DisplayName());
                }
            }

            return View(model);
        }
        #endregion //Action
    }
}