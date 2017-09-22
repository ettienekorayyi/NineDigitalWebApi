using Newtonsoft.Json;
using NineDigitalWebApi.Interfaces;
using NineDigitalWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NineDigitalWebApi.FactoryPattern;

namespace NineDigitalWebApi.DataManagement
{
    public class QuerySelector
    {
        public IPayloadObject ExecuteQuery(object obj)
        {
            try
            {
                PayloadObject payloadObject = null;
                if (obj.GetType() == typeof(string))
                {
                    payloadObject = new PayloadObject();
                    payloadObject.payload = JsonConvert
                            .DeserializeObject<PayloadObject>((string)obj).payload
                            .Where(x => x.drm = true && x.episodeCount > 0).ToArray();
                    return payloadObject;
                }
                else
                {
                    payloadObject = (PayloadObject)new ObjectCreatorFactory().CreateClasses(obj);
                    payloadObject.payload = ((PayloadObject)obj).payload
                                        .Where(x => x.drm = true && x.episodeCount > 0).ToArray();
                    return payloadObject;  
                }
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }
    }
}