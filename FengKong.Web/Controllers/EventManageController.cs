using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FengKong.Models;
using FengKong.Web.Codes;
using FengKong.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FengKong.Web.Controllers
{
    public class EventManageController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AppInfoManage()
        {
            return View();
        }
        public IActionResult AppInfoManageResult()
        {
            var list = MongoDbHelper.SearchAppInfoList("");
            foreach (var item in list)
            {
                var app_event_list = MongoDbHelper.SearchEventInfoList(item.app_id, "");
                foreach (var even in app_event_list)
                {
                    var event_policy_list = MongoDbHelper.SearchPolicyInfoList(item.app_id, even.event_code, "");
                    foreach (var policy in event_policy_list)
                    {
                        even.policy_list.Add(policy);
                    }
                    item.events.Add(even);
                }
            }
            return View(list);
        }
        public IActionResult AppInfoEdit(string appid = "")
        {
            AppInfoModel model = new AppInfoModel();
            model.events = new List<EventInfoModel>();

            if (!string.IsNullOrWhiteSpace(appid))
            {
                var list = MongoDbHelper.SearchAppInfoList(appid);
                model = list.First();
            }

            return View(model);
        }

        public IActionResult AppInfoSave(AppInfoModel model)
        {
            if (string.IsNullOrWhiteSpace(model.app_id))
            {
                return Content("app_id Empty");
            }
            var res = MongoDbHelper.InsertAppInfo(model);

            return Content(res ? "OK" : "ERROR");
        }

        public IActionResult EventInfoManage()
        {
            var appList = MongoDbHelper.SearchAppInfoList("");
            ViewBag.AppInfoList = appList;
            return View();
        }

        public IActionResult EventInfoManageResult()
        {
            var list = MongoDbHelper.SearchEventInfoList("", "");
            return View(list);
        }
        public IActionResult EventInfoEdit(string appid = "", string eventcode = "")
        {
            if (string.IsNullOrWhiteSpace(appid))
            {
                return Content("app_id Empty");
            }
            EventInfoModel model = new EventInfoModel();

            if (!string.IsNullOrWhiteSpace(appid) && !string.IsNullOrWhiteSpace(eventcode))
            {
                var list = MongoDbHelper.SearchEventInfoList(appid, eventcode);
                if (list.Count > 0)
                {
                    model = list.First();
                }

            }
            model.app_id = appid;

            return View(model);
        }

        public IActionResult EventInfoSave(EventInfoModel model)
        {
            if (string.IsNullOrWhiteSpace(model.app_id))
            {
                return Content("app_id Empty");
            }
            if (string.IsNullOrWhiteSpace(model.event_code))
            {
                return Content("event_code Empty");
            }

            var list = MongoDbHelper.SearchEventInfoList(model.app_id, model.event_code);
            if (list.Any())
            {
                MongoDbHelper.DeleteEventInfo(model);
            }

            var res = MongoDbHelper.InsertEventInfo(model);


            return Content(res ? "OK" : "ERROR");
        }


        public IActionResult PolicyInfoManage()
        {
            var appList = MongoDbHelper.SearchAppInfoList("");
            ViewBag.AppInfoList = appList;

            var eventList = MongoDbHelper.SearchEventInfoList("", "");
            ViewBag.EventInfoList = eventList;

            return View();
        }

        public IActionResult PolicyInfoManageResult()
        {
            var list = MongoDbHelper.SearchPolicyInfoList("", "", "");
            return View(list);
        }
        public IActionResult PolicyInfoEdit(string appid = "", string eventcode = "", string policycode = "")
        {
            if (string.IsNullOrWhiteSpace(appid))
            {
                return Content("app_id Empty");
            }
            if (string.IsNullOrWhiteSpace(eventcode))
            {
                return Content("eventcode Empty");
            }
            PolicyInfoModel model = new PolicyInfoModel();

            if (!string.IsNullOrWhiteSpace(appid) && !string.IsNullOrWhiteSpace(eventcode) && !string.IsNullOrWhiteSpace(policycode))
            {
                var list = MongoDbHelper.SearchPolicyInfoList(appid, eventcode, policycode);
                if (list.Count > 0)
                {
                    model = list.First();
                }

            }
            model.app_id = appid;
            model.event_code = eventcode;

            return View(model);
        }

        public IActionResult PolicyInfoSave(PolicyInfoModel model, string policy_id)
        {
            if (string.IsNullOrWhiteSpace(model.app_id))
            {
                return Content("app_id Empty");
            }
            if (string.IsNullOrWhiteSpace(model.event_code))
            {
                return Content("event_code Empty");
            }
            if (string.IsNullOrWhiteSpace(model.policy_code))
            {
                return Content("policy_code Empty");
            }
            var list = MongoDbHelper.SearchPolicyInfoList(model.app_id, model.event_code, model.policy_code);
            if (list.Any())
            {
                MongoDbHelper.DeletePolicyInfo(model);
            }
            if (model.field.Count > 0)
            {
                model.field = model.field[0].Split(',').ToList();
            }
            var res = MongoDbHelper.InsertPolicyInfo(model);


            return Content(res ? "OK" : "ERROR");
        }
        public IActionResult PushAppInfoToNginx(string appid = "")
        {
            if (string.IsNullOrWhiteSpace(appid))
            {
                return Content("app_id Empty");
            }
            var app_list = appid.Split(',');
            string strRes = string.Empty;
            foreach (var item in app_list)
            {
                strRes += item + "_";
            }
            strRes = strRes.Trim('_');

            return Content("app_id " + strRes);
        }
    }
}