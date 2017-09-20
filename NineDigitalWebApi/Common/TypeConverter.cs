using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NineDigitalWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NineDigitalWebApi.Common
{
    public class TypeConverter
    {
        public object ConvertTo(object type)
        {
            try
            {
                if (type.GetType() == typeof(string))
                {
                    return type.ToString();
                }
                else if (type.GetType() == typeof(JObject))
                {
                    return ((JObject)type).ToObject<PayloadObject>();
                }
                else
                {
                    return null;
                }
            }
            catch(NullReferenceException)
            {
                return null;
            }
        }
    }
}