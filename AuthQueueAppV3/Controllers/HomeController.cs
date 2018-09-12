using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuthQueueAppV3.Models;
using AuthQueueAppV3.Services;
using AuthQueueAppV3.ViewModels;
namespace AuthQueueAppV3.Controllers
{
    public class HomeController : Controller
    {
        private IQuoteData _QuoteData;

        public HomeController(IQuoteData quoteData)
        {
            _QuoteData = quoteData;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult QuoteLookup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult QuoteLookup(FindBookingNumModel model)
        {
            if (ModelState.IsValid)
            {
                //return View("Details", model.QuoteNo);
                //return View("Details", model.QuoteNo);
                //return RedirectToAction(nameof(Details), new { quoteno = model.QuoteNo });
                return RedirectToAction(nameof(AuthQueueFix), new { quoteno = model.QuoteNo});

            }
            else return View("Index");
        }

        public IActionResult Details(Int32 QuoteNo)
        {
            // return Content(QuoteNo.ToString());
            var model = _QuoteData.Get(QuoteNo);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult AuthQueueFix(Int32 QuoteNo)
        {
            var model = _QuoteData.Get(QuoteNo);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            var model2 = _QuoteData.AuthQueueFix(model.BkgNo, model.AccountCode_Client, model.OwUId);

            return RedirectToAction(nameof(AuthQueueFixed), new { Bkgno = model2.BkgNo});
        }

        public IActionResult AuthQueueFixed(Int32 BkgNo)
        {
            return View();
        }
    }
}
