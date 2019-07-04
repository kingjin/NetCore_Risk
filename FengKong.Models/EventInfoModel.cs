using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace FengKong.Models
{
    public class EventInfoModel
    {
        public EventInfoModel()
        {
            policy_list = new List<PolicyInfoModel>();
        }
        public ObjectId _id { set; get; }
        public string app_id { set; get; }
        public string event_name { set; get; }
        public string event_code { set; get; }
        public string event_type { set; get; }
        public List<PolicyInfoModel> policy_list { set; get; }

    }
}
