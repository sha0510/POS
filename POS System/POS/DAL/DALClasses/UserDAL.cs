using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Datamodel;

namespace DAL.DALClasses
{
    public class UserDAL
    {
        POSDB db;
        static UserDAL instance;

        public static UserDAL getInstance()
        {
            if (instance == null)
            {
                instance = new UserDAL();
            }

            return instance;
        }

        public UserDAL()
        {
            db = new POSDB();
        }

        public user selectSingle(user findItem)
        {
            user selectedItem = db.users.SingleOrDefault(item => item.id == findItem.id);

            return selectedItem;
        }

        public List<user> selectAll()
        {
            return db.users.ToList();
        }

        public void insert(user newItem)
        {
            db.users.Add(newItem);
            db.SaveChanges();
        }

        public void update(user editItem)
        {
            user selectedItem = db.users.SingleOrDefault(item => item.id == editItem.id);
            selectedItem.userid = editItem.userid;
            selectedItem.password = editItem.password;
            selectedItem.staff_id = editItem.staff_id;
            selectedItem.status = editItem.status;
            selectedItem.securitygroup_id = editItem.securitygroup_id;
            db.SaveChanges();
        }

        public void delete(user deleteItem)
        {
            user selectedItem = db.users.First(item => item.id == deleteItem.id);
            db.users.Remove(selectedItem);
            db.SaveChanges();
        }
    }
}
