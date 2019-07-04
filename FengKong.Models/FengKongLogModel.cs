using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace FengKong.Models
{
    public class FengKongLogModel
    {
        public FengKongLogModel()
        {

        }
        public ObjectId _id { get; set; }
        public string app_id { get; set; }
        public string event_code { get; set; }
        public DateTime create_date { get; set; }
        public string in_pamrs { get; set; }
    }
}
