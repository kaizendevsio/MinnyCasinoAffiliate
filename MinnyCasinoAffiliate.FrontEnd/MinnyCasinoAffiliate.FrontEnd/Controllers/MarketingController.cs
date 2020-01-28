using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MinnyCasinoAffiliate.FrontEnd.Models;
using MinnyCasinoAffiliate.Entities.BO;
using MinnyCasinoAffiliate.Wrapper;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using MinnyCasinoAffiliate.API.Controllers;
using MinnyCasinoAffiliate.Wrapper.Models;
using MinnyCasinoAffiliate.Entities.DTO;
using System.Collections.Generic;
using RestSharp;

using System.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Data;
using System.IO;

namespace MinnyCasinoAffiliate.FrontEnd.Controllers
{
    public class MarketingController : Controller
    {
        //{
        //    private readonly ILogger<MarketingController> _logger;

        //    public MarketingController(ILogger<MarketingController> logger)
        //    {
        //        _logger = logger;
        //    }

        public IActionResult Index()
        {
            return View();
        }

    }
}
