﻿using AuthorityManagement.BLL;
using AuthorityManagement.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthorityManagement.UI.Portal.Controllers
{
    public class UserInfoController : Controller
    {
        //在这里需要依赖接口编程
        private IUserInfoService _userInfoService = new UserInfoService();
        // GET: UserInfo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllUserInfos()
        {
            //Json格式的要求{total:22, rows:{}}
            //实现对用户分页的查询，rows：一共多少条数据，page：请求的当前第几页
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            int total = 0;

            //调用分页的方法，传递参数，拿到分页之后的数据
            var data = _userInfoService.LoadPageEntities(pageIndex, pageSize, out total, u => true, true, u => u.ID);

            //构造成Json的格式传递
            var result = new { total = total, rows = data };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}