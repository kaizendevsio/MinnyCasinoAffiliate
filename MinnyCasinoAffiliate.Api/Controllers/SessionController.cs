﻿using System.Collections.Generic;
using MinnyCasinoAffiliate.Entities.DTO;
using MinnyCasinoAffiliate.Entities.BO;
using MinnyCasinoAffiliate.AppService;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace MinnyCasinoAffiliate.API.Controllers
{
    public class SessionController : ControllerBase
    {
        public string USER_SESSION { get; private set; } = "USER_SESSION";
        public bool CreateSession([FromBody] UserResponseBO userAuthResponse, ISession session)
        {
            session.SetString(USER_SESSION, JsonConvert.SerializeObject(userAuthResponse.UserAuth));
            return true;
        }

        public TblUserAuth GetSession(ISession session)
        {
            string _currentUserSession = session.GetString(USER_SESSION);

            if (_currentUserSession != null)
            {
                TblUserAuth userAuth = JsonConvert.DeserializeObject<TblUserAuth>(_currentUserSession);
                return userAuth;
            }
            else
            {
                throw new System.ArgumentException("User session invalid or expired.");
            }
        }
    }
}
