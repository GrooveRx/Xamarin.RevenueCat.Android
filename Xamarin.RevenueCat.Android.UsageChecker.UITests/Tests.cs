﻿using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace Xamarin.RevenueCat.Android.UsageChecker.UITests
{
    [TestFixture]
    public class Tests
    {
        private AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = ConfigureApp.Android.StartApp();
        }

        [Test]
        public void AppDidLaunch()
        {
            app.WaitForElement(c => c.Id("content"));
            app.Screenshot("App launched");
        }

        [Test]
        public void CheckRevenueCatVersion()
        {
            AppResult versionElement = app.WaitForElement(c => c.Id("txtRevenueCatVersion")).First();
            Assert.AreEqual("RevenueCat 3.4.1", versionElement.Text);
            app.Screenshot("RevenueCat Version");
        }

        [Test]
        public void CheckBillingSupported()
        {
            AppResult billingSupportedElement = app.WaitForElement(c => c.Id("txtIsBillingSupported")).First();
            Assert.AreEqual("Billing Supported: True", billingSupportedElement.Text);
            app.Screenshot("Billing Supported");
        }

        [Test]
        public void CheckAdjustNetworkAttribution()
        {
            AppResult txtAdjustNetworkElement = app.WaitForElement(c => c.Id("txtAdjustNetwork")).First();
            Assert.AreEqual("ADJUST", txtAdjustNetworkElement.Text);
            app.Screenshot("Adjust Attribution Network");
        }
    }
}
