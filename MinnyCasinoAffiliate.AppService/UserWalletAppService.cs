using MinnyCasinoAffiliate.Entities.DTO;
using MinnyCasinoAffiliate.Entities.BO;
using MinnyCasinoAffiliate.Entities.Enums;
using MinnyCasinoAffiliate.DataAccessLayer;
using System.Collections.Generic;

namespace MinnyCasinoAffiliate.AppService
{
    public class UserWalletAppService
    {
       public bool Create(TblUserAuth tblUserAuth, Minny_Casino_AffiliateContext db = null)
        {
            if (db != null)
            {
                UserWalletRepository userWalletRepository = new UserWalletRepository();
                return userWalletRepository.Create(tblUserAuth, db);
            }
            else
            {
                using (db = new Minny_Casino_AffiliateContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        UserWalletRepository userWalletRepository = new UserWalletRepository();  
                        transaction.Commit();

                        return userWalletRepository.Create(tblUserAuth, db);
                    }
                }
            }
           
        }

        public List<TblUserWallet> Get(TblUserAuth tblUserAuth, Minny_Casino_AffiliateContext db = null)
        {
            if (db != null)
            {
                UserWalletRepository userWalletRepository = new UserWalletRepository();
                return userWalletRepository.Get(tblUserAuth, db);
            }
            else
            {
                using (db = new Minny_Casino_AffiliateContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        UserWalletRepository userWalletRepository = new UserWalletRepository();
                        return userWalletRepository.Get(tblUserAuth, db);
                    }
                }
            }
            
        }
        public List<UserWalletBO> GetBO(TblUserAuth tblUserAuth, Minny_Casino_AffiliateContext db = null)
        {
            if (db != null)
            {
                UserWalletRepository userWalletRepository = new UserWalletRepository();
                return userWalletRepository.GetBO(tblUserAuth, db);
            }
            else
            {
                using (db = new Minny_Casino_AffiliateContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        UserWalletRepository userWalletRepository = new UserWalletRepository();
                        return userWalletRepository.GetBO(tblUserAuth, db);
                    }
                }
            }

        }

    }
}
