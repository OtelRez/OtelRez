﻿using Microsoft.AspNetCore.Mvc;
using OtelRez.BL.Managers.Abstract;
using OtelRez.Entity.Entities.Concrete;

namespace OtelRez.MVC.Models.Components
{
    public class OdaTurleriViewComponent : ViewComponent
    {
        private readonly IManager<OdaTur> turler;

        public OdaTurleriViewComponent(IManager<OdaTur> turler)
        {
            this.turler = turler;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var turs = turler.GetAll();
            return View(turs);
        }
    }
}
