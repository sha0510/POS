using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Datamodel;

namespace DAL.DALClasses
{
    public class SecuritygroupPermissionDAL
    {
        POSDB db;
        static SecuritygroupPermissionDAL instance;

        public static SecuritygroupPermissionDAL getInstance()
        {
            if (instance == null)
            {
                instance = new SecuritygroupPermissionDAL();
            }

            return instance;
        }

        public SecuritygroupPermissionDAL()
        {
            db = new POSDB();
        }

        public securitygrouppermission selectSingle(securitygrouppermission findItem)
        {
            securitygrouppermission selectedItem = db.securitygrouppermissions.SingleOrDefault(item => item.id == findItem.id);

            return selectedItem;
        }

        public List<securitygrouppermission> selectAll()
        {
            return db.securitygrouppermissions.ToList();
        }

        public void insert(securitygrouppermission newItem)
        {
            db.securitygrouppermissions.Add(newItem);
            db.SaveChanges();
        }

        public void update(securitygrouppermission editItem)
        {
            securitygrouppermission selectedItem = db.securitygrouppermissions.SingleOrDefault(item => item.id == editItem.id);
            selectedItem.permissions_id = editItem.permissions_id;
            selectedItem.securitygroup_id = editItem.securitygroup_id;
            db.SaveChanges();
        }

        public void delete(securitygrouppermission deleteItem)
        {
            securitygrouppermission selectedItem = db.securitygrouppermissions.First(item => item.id == deleteItem.id);
            db.securitygrouppermissions.Remove(selectedItem);
            db.SaveChanges();
        }
    }
}
