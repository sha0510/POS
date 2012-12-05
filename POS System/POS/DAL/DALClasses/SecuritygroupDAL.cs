using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Datamodel;

namespace DAL.DALClasses
{
    public class SecuritygroupDAL
    {
        POSDB db;
        static SecuritygroupDAL instance;

        public static SecuritygroupDAL getInstance()
        {
            if (instance == null)
            {
                instance = new SecuritygroupDAL();
            }

            return instance;
        }

        public SecuritygroupDAL()
        {
            db = new POSDB();
        }

        public securitygroup selectSingle(securitygroup findItem)
        {
            securitygroup selectedItem = db.securitygroups.SingleOrDefault(item => item.id == findItem.id);

            return selectedItem;
        }

        public List<securitygroup> selectAll()
        {
            return db.securitygroups.ToList();
        }

        public void insert(securitygroup newItem)
        {
            db.securitygroups.Add(newItem);
            db.SaveChanges();
        }

        public void update(securitygroup editItem)
        {
            securitygroup selectedItem = db.securitygroups.SingleOrDefault(item => item.id == editItem.id);
            selectedItem.name = editItem.name;
            selectedItem.description = editItem.description;
            db.SaveChanges();
        }

        public void delete(securitygroup deleteItem)
        {
            securitygroup selectedItem = db.securitygroups.First(item => item.id == deleteItem.id);
            db.securitygroups.Remove(selectedItem);
            db.SaveChanges();
        }
    }
}
