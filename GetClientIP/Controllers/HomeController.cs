using GetClientIP.Interface;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetClientIP.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetIPService _iIPService;

        public HomeController(IGetIPService getIPService)
        {
            _iIPService = getIPService;
        }

        public ActionResult Index()
        {
            TestIP();

            return View();
        }

        public void TestIP()
        {
            //arrange
            string expected = "115.11.123.111";

            //act
            string actual = _iIPService.GetIP();

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}