﻿using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Team.Bloging.Web
{
    public class HomeController : AbpController
    {
        public ActionResult Index()
        {
            return Redirect("/blog/");
        }
    }
}