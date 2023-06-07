using HotelierProject.BusinessLayer.Abstract;
using HotelierProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}

		[HttpPost]
		public IActionResult AddBooking(Contact contact)
		{
			contact.Date = DateTime.Parse(DateTime.Now.ToString());
			_contactService.TInsert(contact);
			return Ok();
		}
	}
}
