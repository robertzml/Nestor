﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Nestor.Models
{
    public enum ErrorCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Display(Name = "成功")]
        Success = 0,

        /// <summary>
        /// 错误
        /// </summary>
        [Display(Name = "错误")]
        Error = 1,

        /// <summary>
        /// 异常
        /// </summary>
        [Display(Name = "异常")]
        Exception = 2,

        /// <summary>
        /// 未实现程序
        /// </summary>
        [Display(Name = "未实现程序")]
        NotImplement = 3,

        /// <summary>
        /// 对象已删除
        /// </summary>
        [Display(Name = "对象已删除")]
        ObjectDeleted = 4,

        /// <summary>
        /// 对象未找到
        /// </summary>
        [Display(Name = "对象未找到")]
        ObjectNotFound = 5,

        /// <summary>
        /// 数据库写入失败
        /// </summary>
        [Display(Name = "数据库写入失败")]
        DatabaseWriteError = 6,

        /// <summary>
        /// 用户名称重复
        /// </summary>
        [Display(Name = "用户名称重复")]
        DuplicateUserName = 11,

        /// <summary>
        /// 密码错误
        /// </summary>
        [Display(Name = "密码错误")]
        WrongPassword = 12,

        /// <summary>
        /// 用户不存在
        /// </summary>
        [Display(Name = "用户不存在")]
        UserNotExist = 13,

        /// <summary>
        /// 用户已禁用
        /// </summary>
        [Display(Name = "用户已禁用")]
        UserDisabled = 14,

        /// <summary>
        /// 链接栏目不能发文章
        /// </summary>
        [Display(Name = "链接栏目不能发文章")]
        LinkColumnNoArticle = 15,

        /// <summary>
        /// 父级栏目不能发文章
        /// </summary>
        [Display(Name = "父级栏目不能发文章")]
        ParentColumnNoArticle = 16
    }
}
