using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Guestbook.Models;
using Guestbook.Entity;
using Microsoft.EntityFrameworkCore;
using Guestbook.Utils;

namespace Guestbook.Controllers
{
    [Route("Guestbook")]
    public class GuestbookController : Controller
    {
        private readonly GuestbookDataContext _db;
        private readonly ILogger<GuestbookController> _logger;
        private readonly String RecaptchaPrivateKey = "xxxx";
        private readonly String RecaptchaSiteKey = "xxxxx";

        public GuestbookController(ILogger<GuestbookController> logger, GuestbookDataContext db)
        {
            _logger = logger;
            _db = db;
        }

        [Route("Index"), Route("")]
        public IActionResult Index()
        {
            GuestbookItem[] gbItems = _db.GuestbookItem.OrderByDescending(x => x.Created).Take(30).ToArray();
            ViewBag.HaveData = gbItems.Length > 0;

            return View(gbItems);
        }

        [Route("Form")]
        public IActionResult Form()
        {
            return Redirect("/Guestbook/Create");

            //ViewBag.RecaptchaSiteKey = RecaptchaPublicKey;
            //return View();
        }

        [HttpGet, Route("Create")]
        public IActionResult Create()
        {
            ViewBag.RecaptchaSiteKey = RecaptchaSiteKey;
            return View();
        }

        [HttpPost, Route("Create")]
        public IActionResult Create(GuestbookItem gbItem)
        {
            gbItem.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            gbItem.Created = DateTime.Now;

            ReCaptchaV2 recaptcha = new ReCaptchaV2();
            long new_id = 0;

            if (ModelState.IsValid && recaptcha.Verify(RecaptchaPrivateKey, gbItem.Recaptcha, gbItem.IPAddress))
            {
                _db.GuestbookItem.Add(gbItem);
                _db.SaveChanges();
                DbContextId id = _db.ContextId;
                new_id = gbItem.Id;
            } else if (ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Error! Invalid recaptcha.");
            }

            if (new_id > 0)
            {
                //return Redirect("/Guestbook/Item?Id=" + new_id.ToString());
                return Redirect("/Guestbook/Index");
            }
             else
            {
                ViewBag.RecaptchaSiteKey = RecaptchaSiteKey;
                return View();
            }
        }

        [Route("Item")]
        public IActionResult Item(String Id)
        {

            GuestbookItem gbItem = new GuestbookItem();
            gbItem = _db.GuestbookItem.Find(Int64.Parse(Id));

            return View(gbItem);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
