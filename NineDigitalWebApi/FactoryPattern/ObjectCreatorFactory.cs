using NineDigitalWebApi.Interfaces;
using NineDigitalWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NineDigitalWebApi.FactoryPattern
{
    public class ObjectCreatorFactory
    {
        public IPayloadObject CreateClasses(object dbClasses)
        {
            if (dbClasses.GetType() == typeof(PayloadObject))
            {
                return new PayloadObject();
            }
            return null;
        }
    }
}