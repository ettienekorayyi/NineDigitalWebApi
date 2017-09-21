using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NineDigitalWebApi.Models;
using NineDigitalWebApi.Formatter;
using System.Web.Http.Results;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using NineDigitalWebApi.Common;
using NineDigitalWebApi.DataManagement;

namespace NineDigitalWebApi.Controllers
{
    public class NineDigitalController : ApiController
    {
        public static IHttpActionResult JsonData { get; private set; }

        [HttpPost]
        public IHttpActionResult Post([FromBody]object payloadObject)
        {
            var type = new TypeConverter().ConvertTo(payloadObject);
         
            if (new Utility().IsValid(type) == true && type != null)
            {
                return JsonData = Ok(CustomQueryManagement
                    .PopulateObject((Payload[])new QuerySelector()
                    .ExecuteQuery(type)));
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, new CustomErrorMessage
                {
                    Error = "Could not decode request: JSON parsing failed",
                });
            }
        }

        [HttpGet]
        public IHttpActionResult GetJsonResult()
        {
            if (JsonData == null)
            {
                return NotFound();
            }
            return JsonData;
        }

    }
}
