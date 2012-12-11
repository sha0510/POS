using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Datamodel;

namespace DAL.DALClasses
{
    public class LoginInfoDAL
    {
        POSDB db;
        static LoginInfoDAL instance;

        public static LoginInfoDAL getInstance()
        {
            if (instance == null)
            {
                instance = new LoginInfoDAL();
            }

            return instance;
        }

        public LoginInfoDAL()
        {
            db = new POSDB();
        }

        public logininfo selectSingle(logininfo findItem)
        {
            logininfo selectedItem = db.logininfoes.SingleOrDefault(item => item.user_userid == findItem.user_userid);

            return selectedItem;
        }

        public logininfo selectSingle(user findItem)
        {
            logininfo selectedItem = db.logininfoes.SingleOrDefault(item => item.user_userid == findItem.userid);

            return selectedItem;
        }

        public List<logininfo> selectAll()
        {
            return db.logininfoes.ToList();
        }

        public void insert(logininfo newItem)
        {
            db.logininfoes.Add(newItem);
            db.SaveChanges();            
        }

        public void update(logininfo editItem)
        {
            logininfo selectedItem = db.logininfoes.SingleOrDefault(item => item.user_userid == editItem.user_userid);
            selectedItem.lastlogindate = editItem.lastlogindate;
            selectedItem.lockedout = editItem.lockedout;
            selectedItem.cumulativefailures = editItem.cumulativefailures;
            selectedItem.updatedate = editItem.updatedate;
            db.SaveChanges();
        }

        public void delete(logininfo deleteItem)
        {
            logininfo selectedItem= db.logininfoes.First(item => item.user_userid == deleteItem.user_userid);
            db.logininfoes.Remove(selectedItem);
            db.SaveChanges();
        }
    }
}
