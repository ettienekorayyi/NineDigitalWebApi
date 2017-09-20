﻿using Newtonsoft.Json;
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
    public class CustomQueryManagement : ApiController
    {
        public ResponseObject PopulateObject(Payload[] dataSource)
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
    }
}