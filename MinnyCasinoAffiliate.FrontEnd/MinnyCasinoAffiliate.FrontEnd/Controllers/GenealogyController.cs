using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinnyCasinoAffiliate.Entities.BO;
using MinnyCasinoAffiliate.Entities.DTO;
using MinnyCasinoAffiliate.FrontEnd.Models;
using MinnyCasinoAffiliate.Wrapper;
using MinnyCasinoAffiliate.Wrapper.Models;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MinnyCasinoAffiliate.FrontEnd.Controllers
{
    public class GenealogyController : Controller
    {
        // GET: /<controller>/
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
                    GenealogyVM genealogyVM = new GenealogyVM();
                    genealogyVM.Fullname = String.Format("{0} {1}", userInfo.FirstName, userInfo.LastName);
                    genealogyVM.Username = userAuth.UserName;

                    return View(genealogyVM);
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
