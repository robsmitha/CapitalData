﻿using CapitalData.Models;
using Microsoft.AspNetCore.Mvc;

namespace CapitalData.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Header", new HeaderViewModel());
        }
    }
}
