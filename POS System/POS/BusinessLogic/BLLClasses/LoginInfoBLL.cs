using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.DALClasses;
using DAL.Model;
using DAL.Datamodel;

namespace BusinessLogic.BLLClasses
{
    public class LoginInfoBLL
    {
        public LoginStatus loginUser(user verifyUser)
        {
            LoginInfoDAL loginInfoDAL = LoginInfoDAL.getInstance(); 
            logininfo loginInfo = loginInfoDAL.selectSingle(verifyUser);
            
            if (loginInfo == null) {
                return LoginStatus.userDoesNotExist();
            }

            if (loginInfo.lockedout==true) {
            //    log(verifyUser.userId
            //        + " "
            //        + "lockedout ");

                return LoginStatus.accountIsLocked();
            }

            UserDAL userDal = UserDAL.getInstance();
            user loginUser = userDal.findByIdAndPassword(verifyUser);

            if (loginUser == null)
            {

            //    loginInfoUpdateLogic.doUpdateForWrongPassword(loginInfo);

            //    log(verifyUser.userId
            //        + " "
            //        + "login failure"
            //        + "number of password provided:"
            //        + loginInfo.cumulativeFailures);

                return LoginStatus.wrongPassword();
            }

            //log(user.userId
            //    + " "
            //    + "login success "
            //    + "number of password provided:"
            //    + user.loginInfo.cumulativeFailures);

            //loginInfoUpdateLogic.doUpdateForCumulativeFailuresReset(user.loginInfo);
            //user.password = null;

            //UserSessionHelper.save(session, user);

            //final Boolean needPasswordChange = userFindLogic
            //                                                .loginExpirationVerify(user);
            //if (needPasswordChange) {
            //    return LoginStatus.paswordWasExpired(user);
            //}

            return LoginStatus.succeed(loginUser);
        }


    }
}
