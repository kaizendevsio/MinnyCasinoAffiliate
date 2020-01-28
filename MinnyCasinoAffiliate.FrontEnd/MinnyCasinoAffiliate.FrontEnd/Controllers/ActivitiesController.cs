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
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Data; 

namespace MinnyCasinoAffiliate.FrontEnd.Controllers
{
    public class ActivitiesController : Controller
    { 
        public async Task<IActionResult> Index()
        {
            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                SessionBO session = sessionController.GetSession(HttpContext.Session);

                ApiRequest apiRequest = new ApiRequest();
                ResponseBO _res = await apiRequest.GetAsync("User/Profile", session.SessionCookies);
                UserResponseBO apiResponse = JsonConvert.DeserializeObject<UserResponseBO>(_res.ResponseResult);

                TblUserInfo userInfo = apiResponse.UserInfo;
                TblUserAuth userAuth = apiResponse.UserAuth;

                if (apiResponse.HttpStatusCode == "200")
                {
                    ActivityVM activityVM = new ActivityVM();
                    activityVM.Fullname = String.Format("{0} {1}", userInfo.FirstName, userInfo.LastName);
                    activityVM.Username = userAuth.UserName;

                    return View(activityVM);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }


            }
            catch (System.Exception e)
            {
                return RedirectToAction("Login", "Home");

            }
            
        }

    } 
}
