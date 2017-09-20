using Newtonsoft.Json;
using NineDigitalWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NineDigitalWebApi.DataManagement
{
    public class QuerySelector
    {
        public object ExecuteQuery(object obj)
        {
            if (obj.GetType() == typeof(string))
            {
                return JsonConvert.DeserializeObject<PayloadObject>((string)obj).payload
                 .Where(x => x.drm = true && x.episodeCount > 0).ToArray();

            }
            else if (obj.GetType() == typeof(PayloadObject))
            {
                return ((PayloadObject)obj).payload
                    .Where(x => x.drm = true && x.episodeCount > 0).ToArray();
            }
            else
            {
                return null;
            }
        }
    }
}