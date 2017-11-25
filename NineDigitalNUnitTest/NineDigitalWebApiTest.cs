using NUnit.Framework;
using NineDigitalNUnitTest.Common;
using System.Web.Http;
using NineDigitalWebApi.Controllers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using NineDigitalWebApi.Models;
using System.Web.Http.Results;
using System.Net.Http;
using System;
using System.Net;
using System.IO;

namespace NineDigitalNUnitTest
{
    [TestFixture]
    public class NineDigitalWebApiTest
    {
        private NineDigitalController controller;

        [SetUp]
        public void Setup()
        {
            controller = new NineDigitalController();
        }

        [TestCase(Constants.validPayloadRequest, typeof(NotFoundResult))]
        [TestCase(Constants.invalidJsonData, typeof(OkNegotiatedContentResult<ResponseObject>))]
        public void ShouldRespondWithOkNegotiatedContentResult([FromBody]string payloadObject, Type typeCondition)
        {
            controller.Post(payloadObject);
            IHttpActionResult actionResult = controller.GetJsonResult();
            Assert.IsTrue(actionResult.GetType() == typeCondition);
        }

        [TestCase(Constants.invalidJsonData, HttpStatusCode.BadRequest)]
        [TestCase(Constants.invalidJsonData, HttpStatusCode.Accepted)]
        public void ShouldRespondWithBadRequest([FromBody]string payloadObject, HttpStatusCode httpStatusCode)
        {
            IHttpActionResult actionResult = controller.Post(payloadObject);
            var type = ((NegotiatedContentResult<CustomErrorMessage>)NineDigitalController.JsonData).StatusCode;
            Assert.AreEqual(type, httpStatusCode);
        }

        [TestCase(Constants.validPayloadRequest, Constants.validResponseObject)]
        [TestCase(Constants.invalidJsonData, Constants.validResponseObject)]
        public void ShouldReturnResponseObject([FromBody]string payloadObject, string responseObject)
        {
            controller.Post(payloadObject);
            var actual = ((OkNegotiatedContentResult<ResponseObject>)NineDigitalController.JsonData).Content;
            var expected = JsonConvert.DeserializeObject<ResponseObject>(responseObject);
            Assert.AreEqual(expected.GetType(), actual.GetType());
        }
    }
}
