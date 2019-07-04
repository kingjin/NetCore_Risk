using FengKong.Models;
using FengKong.Web.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengKong.Web.Codes
{
    public class MongoDbHelper
    {
        public static IMongoDatabase MongodbWrite
        {
            get
            {
                string connectionName = "mongodb://127.0.0.1:27017";
                var Client = new MongoClient(connectionName);

                var database = Client.GetDatabase("FengKong");
                return database;
            }
        }

        public static bool InsertAppInfo(AppInfoModel model)
        {
            try
            {
                var coll = MongodbWrite.GetCollection<AppInfoModel>("AppInfo");
                coll.InsertOneAsync(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }

        public static List<AppInfoModel> SearchAppInfoList(string appId)
        {
            var coll = MongodbWrite.GetCollection<AppInfoModel>("AppInfo");
            var now = DateTime.Now;
            Dictionary<string, object> dict = new Dictionary<string, object>();
            if (!string.IsNullOrWhiteSpace(appId))
            {
                dict.Add("app_id", appId);
            }
            //dict.Add("createDate", new BsonDocument("$lte", now));
            //dict.Add("validDate", new BsonDocument("$gte", now));
            var query = new BsonDocument(dict);
            return coll.FindSync(query).ToList();
        }

        public static List<EventInfoModel> SearchEventInfoList(string appId, string eventcode)
        {
            var coll = MongodbWrite.GetCollection<EventInfoModel>("EventInfo");
            var now = DateTime.Now;
            Dictionary<string, object> dict = new Dictionary<string, object>();
            if (!string.IsNullOrWhiteSpace(appId))
            {
                dict.Add("app_id", appId);
            }
            if (!string.IsNullOrWhiteSpace(eventcode))
            {
                dict.Add("event_code", eventcode);
            }
            //dict.Add("createDate", new BsonDocument("$lte", now));
            //dict.Add("validDate", new BsonDocument("$gte", now));
            var query = new BsonDocument(dict);
            return coll.FindSync(query).ToList();
        }


        public static bool InsertEventInfo(EventInfoModel model)
        {
            try
            {
                var coll = MongodbWrite.GetCollection<EventInfoModel>("EventInfo");
                coll.InsertOneAsync(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }

        public static List<PolicyInfoModel> SearchPolicyInfoList(string appId, string eventcode, string policycode)
        {
            var coll = MongodbWrite.GetCollection<PolicyInfoModel>("PolicyInfo");
            var now = DateTime.Now;
            Dictionary<string, object> dict = new Dictionary<string, object>();
            if (!string.IsNullOrWhiteSpace(appId))
            {
                dict.Add("app_id", appId);
            }
            if (!string.IsNullOrWhiteSpace(eventcode))
            {
                dict.Add("event_code", eventcode);
            }
            if (!string.IsNullOrWhiteSpace(policycode))
            {
                dict.Add("policy_code", policycode);
            }
            //dict.Add("createDate", new BsonDocument("$lte", now));
            //dict.Add("validDate", new BsonDocument("$gte", now));
            var query = new BsonDocument(dict);
            return coll.FindSync(query).ToList();
        }

        public static bool DeleteEventInfo(EventInfoModel model)
        {
            try
            {
                var coll = MongodbWrite.GetCollection<EventInfoModel>("EventInfo");

                Dictionary<string, object> dict = new Dictionary<string, object>();
                if (!string.IsNullOrWhiteSpace(model.app_id))
                {
                    dict.Add("app_id", model.app_id);
                }
                if (!string.IsNullOrWhiteSpace(model.event_code))
                {
                    dict.Add("event_code", model.event_code);
                }

                var query = new BsonDocument(dict);
                coll.DeleteManyAsync(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }

        public static bool InsertPolicyInfo(PolicyInfoModel model)
        {
            try
            {
                var coll = MongodbWrite.GetCollection<PolicyInfoModel>("PolicyInfo");
                coll.InsertOneAsync(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }

        public static bool DeletePolicyInfo(PolicyInfoModel model)
        {
            try
            {
                var coll = MongodbWrite.GetCollection<PolicyInfoModel>("PolicyInfo");

                Dictionary<string, object> dict = new Dictionary<string, object>();
                if (!string.IsNullOrWhiteSpace(model.app_id))
                {
                    dict.Add("app_id", model.app_id);
                }
                if (!string.IsNullOrWhiteSpace(model.event_code))
                {
                    dict.Add("event_code", model.event_code);
                }
                if (!string.IsNullOrWhiteSpace(model.policy_code))
                {
                    dict.Add("policy_code", model.policy_code);
                }
                var query = new BsonDocument(dict);
                coll.DeleteManyAsync(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }

        public static bool InsertFengKongLog(FengKongLogModel model)
        {
            try
            {
                var coll = MongodbWrite.GetCollection<FengKongLogModel>("FengKongLog");
                coll.InsertOneAsync(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }


        public static List<FengKongLogModel> SearchFengKongLogList()
        {
            var coll = MongodbWrite.GetCollection<FengKongLogModel>("FengKongLog");
            var now = DateTime.Now;
            Dictionary<string, object> dict = new Dictionary<string, object>();
            //dict.Add("createDate", new BsonDocument("$lte", now));
            //dict.Add("validDate", new BsonDocument("$gte", now));
            var query = new BsonDocument(dict);
            return coll.FindSync(query).ToList();
        }
    }
}