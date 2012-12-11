using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Datamodel;

namespace DAL.Model
{
    public class LoginStatus
    {
        public const int STATUS_SUCCEED = 101; // Login is Succeed

        public const int STATUS_WRONG_PASSWORD = 201; // Wrong Password

        public const int STATUS_USER_DOES_NOT_EXIST = 202; // User Id does not Exist

        public const int STATUS_ACCOUNT_IS_LOCKED = 203; // Account is Locked

        public const int STATUS_PASSWORD_WAS_EXPIRED = 204; // Password was Expired

        public static LoginStatus succeed(user verifiedUser)
        {
            LoginStatus result = new LoginStatus();
            result.isLogined = true;
            result.status = STATUS_SUCCEED;
            result.loginUser = verifiedUser;
            return result;
        }

        public static LoginStatus wrongPassword()
        {
            LoginStatus result = new LoginStatus();
            result.isLogined = false;
            result.status = STATUS_WRONG_PASSWORD;
            result.loginUser = null;
            return result;
        }

        public static LoginStatus userDoesNotExist()
        {
            LoginStatus result = new LoginStatus();
            result.isLogined = false;
            result.status = STATUS_USER_DOES_NOT_EXIST;
            result.loginUser = null;
            return result;
        }

        public static LoginStatus accountIsLocked()
        {
            LoginStatus result = new LoginStatus();
            result.isLogined = false;
            result.status = STATUS_ACCOUNT_IS_LOCKED;
            result.loginUser = null;
            return result;
        }

        public static LoginStatus paswordWasExpired(user verifiedUser)
        {
            LoginStatus result = new LoginStatus();
            result.isLogined = true;
            result.status = STATUS_PASSWORD_WAS_EXPIRED;
            result.loginUser = verifiedUser;
            return result;
        }

        // logined user info.
        public user loginUser;

        // If succeed login, true.
        public bool isLogined;

        // login status kind.
        public int status;
    }
}
