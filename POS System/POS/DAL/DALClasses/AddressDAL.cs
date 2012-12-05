using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Datamodel;

namespace DAL.DALClasses
{
    public class AddressDAL
    {        
        POSDB db;
        static AddressDAL instance;

        public static AddressDAL getInstance()
        {
            if (instance == null)
            {
                instance = new AddressDAL();
            }

            return instance;
        }

        public AddressDAL()
        {
            db = new POSDB();
        }

        public address selectSingle(address findItem)
        {
            address selectedItem = db.addresses.SingleOrDefault(item => item.id == findItem.id);

            return selectedItem;
        }

        public List<address> selectAll()
        {
            return db.addresses.ToList();
        }

        public void insert(address newItem)
        {
            db.addresses.Add(newItem);
            db.SaveChanges();            
        }

        public void update(address editItem)
        {
            address selectedItem = db.addresses.SingleOrDefault(item => item.id == editItem.id);
            selectedItem.buildingname = editItem.buildingname;
            selectedItem.houseno = editItem.houseno;
            selectedItem.street = editItem.street;
            selectedItem.locality = editItem.locality;
            selectedItem.postaltown = editItem.postaltown;
            selectedItem.country = editItem.country;
            selectedItem.postcode_id = editItem.postcode_id;
            db.SaveChanges();
            
        }

        public void delete(address deleteItem)
        {
            address selectedItem= db.addresses.First(item => item.id == deleteItem.id);
            db.addresses.Remove(selectedItem);
            db.SaveChanges();
        }
    }
}
