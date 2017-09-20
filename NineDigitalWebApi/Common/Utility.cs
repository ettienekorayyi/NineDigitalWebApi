
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

namespace NineDigitalWebApi.Utility
{
    public class Utility : ApiController
    {

        public bool IsValid(object json)
        {
            var temp = json;
            try
            {
                json = (temp.GetType() == typeof(PayloadObject)) 
                    ? JsonConvert.SerializeObject(temp) : ((string)temp);

                if ((json.ToString().Trim().StartsWith("{")
                    && json.ToString().Trim().EndsWith("}")) ||
                        (json.ToString().Trim().StartsWith("[")
                        && json.ToString().Trim().EndsWith("]")) ||
                            json.ToString() != String.Empty)
                {
                    try
                    {
                        JObject obj = JObject.Parse(json.ToString());
                        JSchema schema = JSchema.Parse(json.ToString());
                        return obj.IsValid(schema);
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}