﻿using Microsoft.AspNetCore.Mvc;
namespace HotelierProject.WebUI.ViewComponents.Default
{
	public class _ScriptsPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
