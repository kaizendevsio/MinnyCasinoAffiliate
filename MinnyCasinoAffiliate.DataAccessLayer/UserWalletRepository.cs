﻿using System;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using MinnyCasinoAffiliate.Entities.DTO;
using MinnyCasinoAffiliate.Entities.BO;
using MinnyCasinoAffiliate.Entities.Enums;
using MinnyCasinoAffiliate.DataAccessLayer;
using System.Collections.Generic;

namespace MinnyCasinoAffiliate.DataAccessLayer
{
   public class UserWalletRepository
    {
        public bool Create(TblUserAuth userAuth, Minny_Casino_AffiliateContext db)
        {
            // ENUMERATE ALL WALELT TYPES
            var _q = from a in db.TblWalletType
                     //where a.Type == (int)WalletType.CurrencyValue
                     select new TblWalletType
                     {
                         Name = a.Name,
                         Desc = a.Desc,
                         Type = a.Type,
                         Code = a.Code,
                         Id = a.Id
                     };

            List<TblWalletType> _qWalletTypeRes = _q.ToList<TblWalletType>();

            for (int i = 0; i < _qWalletTypeRes.Count; i++)
            {
                var _userWallet = new TblUserWallet();

                _userWallet.UserAuthId = userAuth.Id;
                _userWallet.WalletTypeId = _qWalletTypeRes[i].Id;
                _userWallet.Balance = 0.0m;
                _userWallet.IsEnabled = true;

                db.TblUserWallet.Add(_userWallet);
            }

            db.SaveChanges();
            return true;
        }

        public List<TblUserWallet> Get(TblUserAuth userAuth, Minny_Casino_AffiliateContext db)
        {
            var _qUi = from a in db.TblUserWallet
                       join b in db.TblWalletType on a.WalletTypeId equals b.Id
                       where a.UserAuthId == userAuth.Id
                       select new TblUserWallet
                       {
                           Id = a.Id,
                           UserAuthId = a.UserAuthId,
                           WalletTypeId = a.WalletTypeId,
                           IsEnabled = a.IsEnabled,
                           Balance = a.Balance,
                           CreatedOn = a.CreatedOn,
                           ModifiedOn = a.ModifiedOn,
                           WalletType = a.WalletType
                       };

            List<TblUserWallet> userWallet = _qUi.ToList<TblUserWallet>();

            return userWallet;
        }

        public List<UserWalletBO> GetBO(TblUserAuth userAuth, Minny_Casino_AffiliateContext db)
        {
            var _qUi = from a in db.TblUserWallet
                       join b in db.TblWalletType on a.WalletTypeId equals b.Id
                       join c in db.TblExchangeRate on a.WalletType.CurrencyId equals c.SourceCurrencyId
                       where a.UserAuthId == userAuth.Id
                       select new UserWalletBO
                       {
                           Id = a.Id,
                           UserAuthId = a.UserAuthId,
                           WalletTypeId = a.WalletTypeId,
                           IsEnabled = a.IsEnabled,
                           Balance = a.Balance,
                           BalanceFiat = a.Balance * c.Value,
                           CreatedOn = a.CreatedOn,
                           ModifiedOn = a.ModifiedOn,
                           WalletType = a.WalletType,
                           WalletName = a.WalletType.Name,
                           WalletCode = a.WalletType.Code
                       };

            List<UserWalletBO> userWallet = _qUi.ToList<UserWalletBO>();

            return userWallet;
        }
    }
}
