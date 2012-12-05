using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Datamodel;

namespace DAL.DALClasses
{
    public class CustomerDAL
    {
        POSDB db;
        static CustomerDAL instance;

        public static CustomerDAL getInstance()
        {
            if (instance == null)
            {
                instance = new CustomerDAL();
            }

            return instance;
        }

        public CustomerDAL()
        {
            db = new POSDB();
        }

        public customer selectSingle(customer findItem)
        {
            customer selectedItem = db.customers.SingleOrDefault(item => item.id == findItem.id);

            return selectedItem;
        }

        public List<customer> selectAll()
        {
            return db.customers.ToList();
        }

        public void insert(customer newItem)
        {
            db.customers.Add(newItem);
            db.SaveChanges();
        }

        public void update(customer editItem)
        {
            customer selectedItem = db.customers.SingleOrDefault(item => item.id == editItem.id);
            selectedItem.code = editItem.code;
            selectedItem.type = editItem.type;
            selectedItem.lastname = editItem.lastname;
            selectedItem.firstname = editItem.firstname;            
            selectedItem.phone = editItem.phone;
            selectedItem.mobile = editItem.mobile;
            selectedItem.email = editItem.email;
            selectedItem.status = editItem.status;            
            selectedItem.address_id = editItem.address_id;
            selectedItem.creditlimit = editItem.creditlimit;
            selectedItem.image = editItem.image;
            db.SaveChanges();

        }

        public void delete(customer deleteItem)
        {
            customer selectedItem = db.customers.First(item => item.id == deleteItem.id);
            db.customers.Remove(selectedItem);
            db.SaveChanges();
        }
    }
}
