﻿using HotelierProject.WebUI.Dtos.RoomDto;
using HotelierProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelierProject.WebUI.ViewComponents.Default
{
	public class _OurRoomsPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _OurRoomsPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:60522/api/Room");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
