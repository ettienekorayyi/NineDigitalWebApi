
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
        public bool IsValid(object json)
        {
            var temp = json;
            try
            {
                json = (temp.GetType() == typeof(PayloadObject))  ? JsonConvert.SerializeObject(temp) 
                    : ((string)temp);
                if ((json.ToString().Trim().StartsWith("{")  && json.ToString().Trim().EndsWith("}")) ||
                            json.ToString() != String.Empty)
                {
                    try
                    {
                        JObject obj = JObject.Parse(json.ToString());
                        JSchema schema = JSchema.Parse(json.ToString());
                        var payloadObject = JsonConvert.DeserializeObject<PayloadObject>(json.ToString());
                        if (payloadObject.payload != null) return obj.IsValid(schema);

                        return false;
                    }
                    catch (Exception ex)
                    {
                        return Utility.ErrorLogger(ex);
                    }
                }
                else return false;
            }
            catch (NullReferenceException nullException)
            {
                return ErrorLogger(nullException);
            }
            catch (Exception exception)
            {
                return ErrorLogger(exception);
            }
        }

        public static bool ErrorLogger(_Exception exception)
        {
            var path = Environment.GetFolderPath(Environment
                        .SpecialFolder.MyDocuments) + Constants.filePath;
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("Message :" + exception.Message + "<br/>"
                    + Environment.NewLine + "StackTrace :" + exception.StackTrace +
                    "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine(Environment.NewLine +
                    "-----------------------------------------------------------------------------"
                    + Environment.NewLine);
            }
            return false;
        }
    }
}