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
using JW;

namespace Guestbook.Controllers
{
    [Route("Guestbook")]
    public class GuestbookController : Controller
    {
        private readonly GuestbookDataContext _db;
        private readonly ILogger<GuestbookController> _logger;
        private readonly SystemConfig _config;

        public GuestbookController(ILogger<GuestbookController> logger, GuestbookDataContext db, SystemConfig config)
        {
            _logger = logger;
            _db = db;
            _config = config;
        }

        [Route("Index"), Route("")]
        public IActionResult Index(int offset = 1)
        {
            int maxPerPage = 10;
            int total = _db.GuestbookItem.Take(1000).ToArray().Length;
            int queryOffset = maxPerPage * (offset - 1);

            GuestbookItem[] gbItems = _db.GuestbookItem.OrderByDescending(x => x.Created)
                                                       .Skip(queryOffset)
                                                       .Take(maxPerPage)
                                                       .ToArray();
            ViewBag.HaveData = gbItems.Length > 0;

            Pager pagination = new Pager(total, offset, maxPerPage);
            ViewBag.Pagination = pagination;

            GuestBookViewModel viewModel = new GuestBookViewModel { 
                GuestbookItems = gbItems,
                Pagination = pagination
            };

            return View(viewModel);
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
            ViewBag.RecaptchaSiteKey = _config.RecaptchaSiteKey;
            return View();
        }

        [HttpPost, Route("Create")]
        public IActionResult Create(GuestbookItem gbItem)
        {
            gbItem.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            gbItem.Created = DateTime.Now;

            ReCaptchaV2 recaptcha = new ReCaptchaV2();
            long new_id = 0;

            if (ModelState.IsValid && recaptcha.Verify(_config.RecaptchaSecretKey, gbItem.Recaptcha, gbItem.IPAddress))
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
                ViewBag.RecaptchaSiteKey = _config.RecaptchaSiteKey;
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
