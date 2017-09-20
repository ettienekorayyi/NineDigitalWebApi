using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NineDigitalWebApi.Controllers;
using Newtonsoft.Json;
using NineDigitalWebApi.Models;
using NineDigitalWebApi.DataManagement;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace NineDigitalUnitTest
{
    [TestClass]
    public class ControllerUnitTest : ApiController
    {
        [TestMethod]
        public void PostValidJson()
        {
            var json = Constants.JsonTestData.validJsonString;
            var expected = new NineDigitalController().Post(json);
            var actual = NineDigitalController.JsonData;
            
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void PostInvalidJson()
        {
            var json = Constants.JsonTestData.invalidJsonData;
            var expected = new NineDigitalController().Post(json);
            var actual = NineDigitalController.JsonData;

            Assert.Fail("The json data cannot be deserialized into Payload Object");
        }
    }
}
