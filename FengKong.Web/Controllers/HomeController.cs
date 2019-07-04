using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FengKong.Web.Models;
using FengKong.Web.Codes;
using FengKong.Models;

namespace FengKong.Web.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult RiskAPI(string app_id, string event_code)
        {
            FengKongLogModel logInfo = new FengKongLogModel()
            {
                app_id = app_id,
                create_date = DateTime.Now,
                event_code = event_code,
                in_pamrs = DateTime.Now.Ticks.ToString()
            };

            if (string.IsNullOrWhiteSpace(app_id))
            {
                return Content("app_id Empty");
            }
            var res = MongoDbHelper.InsertFengKongLog(logInfo);

            return Content(res ? "OK" : "ERROR");
        }


    }
}
//