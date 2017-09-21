using Newtonsoft.Json;
using NineDigitalWebApi.Interfaces;
using NineDigitalWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace NineDigitalWebApi.DataManagement
{
    public static class CustomQueryManagement 
    {
        public static ResponseObject PopulateObject(Payload[] dataSource)
        {
            try
            {
                ResponseObject responseObject = new ResponseObject()
                {
                    response = new Response[dataSource.Length]
                };
                int counter = 0;
                foreach (var item in dataSource)
                {
                    responseObject.response[counter++] = new Response
                    {
                        image = item.image.showImage,
                        slug = item.slug,
                        title = item.title
                    };
                }
                return responseObject;
            }
            catch(ArgumentNullException arg)
            {
                new ApplicationException("Parameter value is null!", arg);
            }
            return null;
        }
    }
}