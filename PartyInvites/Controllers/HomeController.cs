using Microsoft.AspNetCore.Mvc;
using System;
using PartyInvites.Models;
using System.Linq;
using PartyInvites.Data;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        private readonly PartyInvitesContext _context;

        public HomeController(PartyInvitesContext context)
        {
            _context = context;
        }

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
                _context.Add(guestResponse);
                _context.SaveChanges();
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
        }

        public int PageSize = 4;

        public ViewResult ListResponses(int guestsPage = 1)
        {
            return View(new GuestsListViewModel
            {
                GuestResponses = _context.GuestResponses.Where(r => r.WillAttend == true).Skip((guestsPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = guestsPage,
                    ItemsPerPage = PageSize,
                    Totalitems = _context.GuestResponses.Count()
                }
            });
        }

        public ViewResult ShowResponseDetails(int id) {
            GuestResponse guestResponse = _context.GuestResponses.Single(r => r.ID == id);
            return View(guestResponse);
        }
    }
}