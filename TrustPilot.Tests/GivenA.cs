using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Moq.Language.Flow;
using NUnit.Framework;
using StructureMap.AutoMocking.Moq;

namespace TrustPilot.Tests
{
    public class ThenAttribute : TestAttribute
    { }

    [TestFixture]
    public abstract class TestBase
    {
        [SetUp]
        public void SetUp()
        {
            Given();
            When();
        }

        protected virtual void Given()
        { }

        protected virtual void When()
        { }
    }

    public abstract class TestBase<T> : TestBase
    {
        public T Target;
    }

    public abstract class GivenA<T> : TestBase<T> where T : class
    {
        private readonly MoqAutoMocker<T> _autoMocker = new MoqAutoMocker<T>();

        protected override void Given()
        {
            Target = _autoMocker.ClassUnderTest;
            base.Given();
        }

        protected Mock<TT> GetMock<TT>() where TT : class
        {
            return Mock.Get(_autoMocker.Get<TT>());
        }

        protected ISetup<TT, TResult> SetupProperty<TT, TResult>(Expression<Func<TT, TResult>> setup) where TT : class
        {
            return Mock.Get(_autoMocker.Get<TT>()).Setup(setup);
        }

        protected void Verify<TT>(Expression<Action<TT>> verify) where TT : class
        {
            Mock.Get(_autoMocker.Get<TT>()).Verify(verify);
        }

        protected void VerifyGet<TT, TResult>(Expression<Func<TT, TResult>> verifyGet) where TT : class
        {
            Mock.Get(_autoMocker.Get<TT>()).VerifyGet(verifyGet);
        }

        protected void VerifySet<TT>(Action<TT> verifySet) where TT : class
        {
            Mock.Get(_autoMocker.Get<TT>()).VerifySet(verifySet);
        }

        protected void Verify<TT>(Expression<Action<TT>> verify, Times times) where TT : class
        {
            Mock.Get(_autoMocker.Get<TT>()).Verify(verify, times);
        }
    }

    public abstract class GivenA<T, TResult> : GivenA<T> where T : class
    {
        public TResult Result;
    }

    /// <summary>
    /// http://blog.devdave.com/2012/05/moq-mocking-httpcontext-in-your-mvc3.html
    /// </summary>
    public class MockContext
    {
        public Mock<RequestContext> RoutingRequestContext { get; private set; }
        public Mock<HttpContextBase> Http { get; private set; }
        public Mock<HttpServerUtilityBase> Server { get; private set; }
        public Mock<HttpResponseBase> Response { get; private set; }
        public Mock<HttpRequestBase> Request { get; private set; }
        public Mock<HttpSessionStateBase> Session { get; private set; }
        public Mock<ActionExecutingContext> ActionExecuting { get; private set; }
        public Mock<HttpCachePolicyBase> CachePolicy { get; private set; }
        public MockController Controller { get; private set; }
        public ControllerContext ControllerContext { get; private set; }

        public HttpCookieCollection Cookies { get; private set; }
        public ViewDataDictionary ViewData { get; private set; }

        public MockContext()
        {
            RoutingRequestContext = new Mock<RequestContext>(MockBehavior.Loose);
            ActionExecuting = new Mock<ActionExecutingContext>(MockBehavior.Loose);
            Http = new Mock<HttpContextBase>(MockBehavior.Loose);
            Server = new Mock<HttpServerUtilityBase>(MockBehavior.Loose);
            Response = new Mock<HttpResponseBase>(MockBehavior.Loose);
            Request = new Mock<HttpRequestBase>(MockBehavior.Loose);
            Session = new Mock<HttpSessionStateBase>(MockBehavior.Loose);
            CachePolicy = new Mock<HttpCachePolicyBase>(MockBehavior.Loose);
            Cookies = new HttpCookieCollection();
            ViewData = new ViewDataDictionary();
            Controller = new MockController { ViewData = ViewData };
            ControllerContext = new ControllerContext { HttpContext = Http.Object, Controller = Controller };

            RoutingRequestContext.SetupGet(c => c.HttpContext).Returns(Http.Object);
            ActionExecuting.SetupGet(c => c.HttpContext).Returns(Http.Object);
            Http.SetupGet(c => c.Request).Returns(Request.Object);
            Http.SetupGet(c => c.Response).Returns(Response.Object);
            Http.SetupGet(c => c.Server).Returns(Server.Object);
            Http.SetupGet(c => c.Session).Returns(Session.Object);
            Request.Setup(c => c.Cookies).Returns(Cookies);
            Response.Setup(c => c.Cache).Returns(CachePolicy.Object);
        }

        public void AddModelError()
        {
            ViewData.ModelState.AddModelError("sdfds", "sdfds");
        }

        public void MakeAjaxRequest()
        {
            Request.SetupGet(x => x.Headers).Returns(new WebHeaderCollection { { "X-Requested-With", "XMLHttpRequest" } });
        }

        public ControllerContext MockHttpContext
        {
            get { return ControllerContext; }
        }

        public class MockController : Controller
        { }
    }
}
