using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace FengKong.Web.Models
{
    //##APP管理
    public class AppModel
    {
        public AppModel()
        {
            events = new List<EventModel>();
        }
        public BsonObjectId id { get; set; }
        public string app_name { get; set; }
        public string app_id { get; set; }
        public List<EventModel> events { get; set; }
    }
    //##事件管理
    public class EventModel
    {
        public EventModel() {
            policy_list = new List<PolicyModel>();
        }
        public string event_name { set; get; }
        public string event_code { set; get; }
        public string event_type { set; get; }
        public List<PolicyModel> policy_list { set; get; }

    }

    //##策略管理
    public class PolicyModel
    {
        /// <summary>
        /// 对应字段 
        /// </summary>
        public List<string> field { get; set; }
        /// <summary>
        /// 最大限限制
        /// </summary>
        public int max_size { get; set; }
        /// <summary>
        /// 时间片 秒
        /// </summary>
        public int time_slice { get; set; }
        /// <summary>
        /// single-单一策略/group-组合策略
        /// </summary>
        public string policy_type { get; set; }
    }



}
