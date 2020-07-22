using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            //ViewBag - передает даные в представление, кратакая форма записи if/else
            ViewBag.Start = hour < 12 ? "Good Morning" : "Good Evening";
            return View("MyView");
        }
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }
        // происхходить сохранения обьекта GuestResponse в хранилище 
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                // ВИЗУАЛИЗАЦИЯ  представления "Thanks" и передать ему обьект модели GuestResponse
                return View("Thanks", guestResponse);
            }
            else
                return View();
        }
        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(r=>r.WillAtend==true));
        }
    }
}
