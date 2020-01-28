using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinnyCasinoAffiliate.API.Controllers;
using MinnyCasinoAffiliate.Entities.BO;
using MinnyCasinoAffiliate.Entities.DTO;
using MinnyCasinoAffiliate.FrontEnd.Models;
using MinnyCasinoAffiliate.Wrapper;
using MinnyCasinoAffiliate.Wrapper.Models;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MinnyCasinoAffiliate.FrontEnd.Controllers
{
    public class DashboardController : Controller
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

                _res = await apiRequest.GetAsync("User/Wallet", session.SessionCookies);
                apiResponse = JsonConvert.DeserializeObject<UserResponseBO>(_res.ResponseResult);

                List<UserWalletBO> userWallets = apiResponse.UserWallet;

                if (apiResponse.HttpStatusCode == "200")
                {
                    DashboardVM dashboardVM = new DashboardVM();
                    dashboardVM.Fullname = String.Format("{0} {1}", userInfo.FirstName, userInfo.LastName);
                    dashboardVM.TotalCustomer = (int)userWallets.Find(i => i.WalletCode == "DLN").Balance;
                    dashboardVM.TotalFirstDeposit = (int)userWallets.Find(i => i.WalletCode == "IDC").Balance;
                    dashboardVM.TotalHits = (int)userWallets.Find(i => i.WalletCode == "HIT").Balance;
                    dashboardVM.TotalIncome = (int)userWallets.Find(i => i.WalletCode == "TIN").Balance;
                    dashboardVM.TotalSignUps = (int)userWallets.Find(i => i.WalletCode == "TCR").Balance;
                    dashboardVM.Username = userAuth.UserName;

                    return View(dashboardVM);
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
