
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NineDigitalWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json.Schema;
using System.IO;
using NineDigitalWebApi.Common;
using System.Runtime.InteropServices;

namespace NineDigitalWebApi.Common
{
    public class Utility : ApiController
    {
        public static bool IsValid(object json)
        {
            string jsonString = string.Empty;
            try
            {
                jsonString = (json.GetType() == typeof(PayloadObject)) ? JsonConvert.SerializeObject(json) : ((string)json);
                if ((jsonString.Trim().StartsWith("{")  && jsonString.Trim().EndsWith("}")))
                {
                    var payloadObject = JsonConvert.DeserializeObject<PayloadObject>(jsonString);
                    if (payloadObject.payload != null) return JObject.Parse(jsonString)
                            .IsValid(JSchema.Parse(jsonString));
                    else return false;
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}