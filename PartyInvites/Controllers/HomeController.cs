using Microsoft.AspNetCore.Mvc;
using System;
using PartyInvites.Models;
using System.Linq;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                //there is a validation error
                return View();
            }
        }

        public int PageSize = 4;

        public ViewResult ListResponses(int guestsPage = 1)
        {
            return View(new GuestsListViewModel
            {
                GuestResponses = Repository.Responses.Where(r => r.WillAttend == true).Skip((guestsPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = guestsPage,
                    ItemsPerPage = PageSize,
                    Totalitems = Repository.Responses.Count()
                }
            });
        }

        public ViewResult ShowResponseDetails(int id) {
            GuestResponse guestResponse = Repository.Responses.Single(r => r.ID == id);
            return View(guestResponse);
        }
    }
}
