using System;
using System.Net;

using ConsoleWebServer.Framework;
using ConsoleWebServer.Framework.Http;
using ConsoleWebServer.Framework.Http.Contracts;

using NUnit.Framework;
using Moq;

namespace ConsoleWebServer.Tests.Http
{
    [TestFixture]
    public class ResponseProviderTests
    {
        [Test]
        public void Constructor_ShouldThrow_WhenIHttpRequestManagerParameterIsNotValid()
        {
            IHttpRequestManager requestManager = null;
            var actionInvoker = new Mock<IActionInvoker>();
            var staticFileHandler = new Mock<IStaticFileHandler>();
            var createResponse = new Mock<Func<Version, HttpStatusCode, string, IHttpResponse>>();

            staticFileHandler.Setup(handler => handler.CanHandle(It.IsAny<IHttpRequest>())).Returns(true);

            Assert.That(
                () => new ResponseProvider(requestManager, actionInvoker.Object, staticFileHandler.Object, createResponse.Object),
                Throws.ArgumentNullException.With.Message.Contain("requestManager"));
        }
    }
}
