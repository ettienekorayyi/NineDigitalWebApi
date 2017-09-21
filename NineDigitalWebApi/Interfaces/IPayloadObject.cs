using NineDigitalWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NineDigitalWebApi.Interfaces
{
    public interface IPayloadObject
    {
        Payload[] payload { get; set; }
        int skip { get; set; }
        int take { get; set; }
        int totalRecords { get; set; }
    }
}