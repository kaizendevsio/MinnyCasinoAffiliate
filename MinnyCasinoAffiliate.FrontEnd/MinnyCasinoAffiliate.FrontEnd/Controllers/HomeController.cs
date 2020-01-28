using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MinnyCasinoAffiliate.FrontEnd.Models;
using MinnyCasinoAffiliate.Entities.BO;
using MinnyCasinoAffiliate.Wrapper;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MinnyCasinoAffiliate.API.Controllers;
using MinnyCasinoAffiliate.Wrapper.Models;
using MinnyCasinoAffiliate.Entities.DTO;

namespace MinnyCasinoAffiliate.FrontEnd.Controllers
{
    public class HomeController : Controller { 
    //{
    //    private readonly ILogger<HomeController> _logger;

    //    public HomeController(ILogger<HomeController> logger)
    //    {
    //        _logger = logger;
    //    }

        public IActionResult Index()
        {
            return Redirect("Login");
        }

        [Route("Login")]
        [HttpGet]
        public IActionResult LogIn()
        {

            return View();
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] UserBO userBO)
        {

            try
            {
                ApiRequest apiRequest = new ApiRequest();
                ResponseBO _res = await apiRequest.PostAsync("User/Authenticate", userBO);

                UserResponseBO apiResponse = JsonConvert.DeserializeObject<UserResponseBO>(_res.ResponseResult);

                if (apiResponse.HttpStatusCode == "200")
                {
                    SessionController sessionController = new SessionController();
                    sessionController.CreateSession(apiResponse, _res.ResponseCookies, HttpContext.Session);

                    TblUserInfo tblUserInfo = apiResponse.UserInfo;
                    TblUserAuth tblUserAuth = apiResponse.UserAuth;
                    TblUserRole tblUserRole = apiResponse.UserRole;



                    //if (tblUserRole.AccessRole.Equals("Admin") || tblUserRole.AccessRole.Equals("SuperAdmin"))
                    //{
                    //    apiResponse.RedirectUrl = "/Admin/";
                    //}
                    //else
                    //{
                    //    apiResponse.RedirectUrl = "/Dashboard/";
                    //}
                    apiResponse.RedirectUrl = "/Dashboard/";
                    return Ok(apiResponse);
                }
                else
                {
                    apiResponse.RedirectUrl = "/User/Login/Failed";
                    return BadRequest(apiResponse);
                }
            }
            catch (System.Exception e)
            {
                UserResponseBO apiResponse = new UserResponseBO();
                apiResponse.RedirectUrl = "/User/Login/Failed";
                apiResponse.Message = e.Message;
                return BadRequest(apiResponse);
                //return Redirect("~/User/Login/Failed");

            }

        }

        [Route("Signup")]
        [HttpGet]
        public IActionResult SignUp()
        {
           
            return View();
        }

        [Route("Logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            SessionController sessionController = new SessionController();
            sessionController.DestroySession(HttpContext.Session);

            return Redirect("~/Login");
        }

        [Route("Signup")]
        [System.Web.Http.AllowAnonymous, System.Web.Http.HttpPost]
        public ActionResult SignUp(ApplicationVM model)
        {

            if (ModelState.IsValid)
            {

                //foreach (var file_ in file)
                //{
                //    if (file_.ContentType == "application/pdf" || file_.ContentType == "image/jpeg" || file_.ContentType == "application/msword" || file_.ContentType == "text/csv" || file_.ContentType == "application/vnd.ms-excel" || file_.ContentType == "image/png" || file_.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" || file_.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
                //    {
                //        var b = file_.ContentType;

                //        files.Add(ConvertToByte(file_));
                //        filenames.Add(file_.FileName);
                //    }
                //}

               
                //var obj = MinnyCasinoAffiliate.Wrapper.Post<bool>("User/Create", model);



            }

            else
            {
                //retain and display error message
                ViewBag.ErrorMessage = "INVALID INPUT";
            }

            return Redirect("LogIn");
        }

        //public byte[] ConvertToByte(HttpPostedFileBase file_)
        //{
        //    //byte[] fileByte = null;
        //    //BinaryReader rdr = new BinaryReader(file_.InputStream);
        //    //fileByte = rdr.ReadBytes((int)file_.ContentLength);
        //    //return fileByte;
        //}
 
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public interface ILogger<T>
    {
    }
}
