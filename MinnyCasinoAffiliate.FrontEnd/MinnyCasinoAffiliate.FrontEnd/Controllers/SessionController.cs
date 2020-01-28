using System.Collections.Generic;
using MinnyCasinoAffiliate.Entities.DTO;
using MinnyCasinoAffiliate.Entities.BO;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net;
using MinnyCasinoAffiliate.Wrapper.Models;
using System.Data;
namespace MinnyCasinoAffiliate.FrontEnd.Controllers
{
    public class SessionController : ControllerBase
    {
        public string USER_SESSION { get; private set; } = "USER_SESSION";
        public string USER_SESSION_COOKIE { get; private set; } = "USER_SESSION_COOKIE";

        public bool CreateSession([FromBody] UserResponseBO UserResponseBO, CookieCollection ResponseCookies, ISession session)
        {
            session.SetString(USER_SESSION, JsonConvert.SerializeObject(UserResponseBO.UserInfo));
            session.SetString(USER_SESSION_COOKIE, JsonConvert.SerializeObject(ResponseCookies));
            return true;
        }

        public SessionBO GetSession(ISession session)
        {
            string _currentUserSession = session.GetString(USER_SESSION);
            string _currentUserSessionCookie = session.GetString(USER_SESSION_COOKIE);

            if (_currentUserSession != null)
            {
                SessionBO sessionBO = new SessionBO();
                sessionBO.SessionCookies = JsonConvert.DeserializeObject<CookieCollection>(_currentUserSessionCookie);
                sessionBO.UserInfo = JsonConvert.DeserializeObject<TblUserInfo>(_currentUserSession);

                return sessionBO;
            }
            else
            {
                throw new System.ArgumentException("User session invalid or expired.");
            }




        }

        public bool DestroySession(ISession session)
        {
            session.Clear();
            return true;
        }
    }
}
