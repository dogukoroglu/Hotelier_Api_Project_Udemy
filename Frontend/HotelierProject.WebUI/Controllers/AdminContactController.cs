using HotelierProject.WebUI.Dtos.ContactDto;
using HotelierProject.WebUI.Dtos.SendMessageDto;
using HotelierProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelierProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {

		private readonly IHttpClientFactory _httpClientFactory;

		public AdminContactController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Inbox()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:60522/api/Contact");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		public async Task<IActionResult> Sendbox()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:60522/api/SendMessage");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultSendboxDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult AddSendMessage()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddSendMessage(CreateSendMessageDto createSendMessageDto)
		{
			createSendMessageDto.SenderMail = "admin@gmail.com";
			createSendMessageDto.SenderName = "admin";
			createSendMessageDto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createSendMessageDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:60522/api/SendMessage", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Sendbox");
			}
			return View();
		}

		public PartialViewResult SidebarAdminContactPartial()
        {
            return PartialView();
        }
		public PartialViewResult SidebarAdminContactCategoryPartial()
		{
			return PartialView();
		}

		public async Task<IActionResult> MessageDetailsBySendbox(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"http://localhost:60522/api/SendMessage/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<GetMessageByIdDto>(jsonData);
				return View(values);
			}
			return View();
		}

		public async Task<IActionResult> MessageDetailsByInbox(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"http://localhost:60522/api/Contact/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<InboxContactDto>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
