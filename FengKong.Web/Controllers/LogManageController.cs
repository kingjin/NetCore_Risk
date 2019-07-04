using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FengKong.Web.Codes;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FengKong.Web.Controllers
{
    public class LogManageController : BaseController
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FengKongLogList()
        {
            var appList = MongoDbHelper.SearchAppInfoList("");
            ViewBag.AppInfoList = appList;

            return View();
        }

        public IActionResult FengKongLogListResult()
        {

            var list = MongoDbHelper.SearchFengKongLogList();
            return View(list);
        }
    }
}
