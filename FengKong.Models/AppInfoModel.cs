using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FengKong.Models
{
    [BsonIgnoreExtraElements]
    public class AppInfoModel
    {
        public AppInfoModel()
        {
            events = new List<EventInfoModel>();
        }
        public ObjectId id { get; set; }
        public string app_name { get; set; }
        public string app_id { get; set; }
        public List<EventInfoModel> events { get; set; }
    }
}
