using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotels.Data;
using Hotels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotels.Controllers
{
	public class DashboardController : Controller
	{
		private readonly ApplicationDbContext _context;
		public DashboardController(ApplicationDbContext context)
		{
			_context = context;
		}
        public IActionResult Update(Hotel hotel)
        {
            _context.hotel.Update(hotel);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
		public IActionResult Rooms()
		{
			var hotel = _context.hotel.ToList();
			ViewBag.hotel = hotel;
			//ViewBag.currentuser = Request.Cookies["UserName"];
			ViewBag.currentuser = HttpContext.Session.GetString("UserName");
			var rooms = _context.rooms.ToList();
			return View(rooms);
			
		}
		public IActionResult Edit(int id)
		{
			var hotelEdit = _context.hotel.SingleOrDefault(x => x.Id == id);
			return View(hotelEdit);
		}

		public IActionResult Delete(int id)
		{


			var hotelDelete = _context.hotel.SingleOrDefault(x => x.Id == id);
			_context.hotel.Remove(hotelDelete);
			_context.SaveChanges();
			TempData["Delete"] = "ok";
			return RedirectToAction("Index");
		}
		public IActionResult RoomDetails()
		{
            var hotel = _context.hotel.ToList();
            ViewBag.hotel = hotel;
            ViewBag.currentuser = HttpContext.Session.GetString("UserName");
            var rooms = _context.rooms.ToList();
			ViewBag.rooms = rooms;
            var roomDetails = _context.roomDetails.ToList();
            return View(roomDetails);




        }
        public IActionResult CreateNewRoos (Rooms rooms)
		{
			_context.rooms.Add(rooms);
			_context.SaveChanges();
			return RedirectToAction("Rooms");
		}
		public IActionResult CreateNewRoomDetails(RoomDetails roomDetails)
		{
			_context.roomDetails.Add(roomDetails);
			_context.SaveChanges();
			return RedirectToAction("roomDetails");
		}

		[HttpPost]
		public IActionResult Index(string city)
		{
			var findhotel = _context.hotel.Where(x => x.City.Contains(city));
			ViewBag.hotel = findhotel;

			return View(findhotel);
		}

		public IActionResult CreateNewHotel(Hotel hotels)
		{
			if (ModelState.IsValid)
			{
                _context.hotel.Add(hotels);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            var hotel = _context.hotel.ToList();
            return View("index",hotel);
		}

		[Authorize]
		public IActionResult Index()
		{
			var currentuser = HttpContext.User.Identity.Name;
			ViewBag.currentuser = currentuser;
			//CookieOptions option = new CookieOptions();
			//option . Expires = DateTime.Now.AddMinutes(20);
			//Response.Cookies.Append("UserName", currentuser, option);
			HttpContext.Session.SetString("UserName", currentuser);
			var hotel = _context.hotel.ToList();
			return View(hotel);
		}
		
	}


}






