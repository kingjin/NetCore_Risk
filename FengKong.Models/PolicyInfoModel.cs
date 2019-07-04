using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace FengKong.Models
{
    public class PolicyInfoModel
    {
        public PolicyInfoModel()
        {
            field = new List<string>();
        }
        public ObjectId _id { set; get; }
        public string app_id { get; set; }
        public string event_code { get; set; }

        public string policy_code { get; set; }

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
