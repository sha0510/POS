using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Datamodel;

namespace DAL.DALClasses
{
    public class CompanyinfoDAL
    {
        POSDB db;
        static CompanyinfoDAL instance;

        public static CompanyinfoDAL getInstance()
        {
            if (instance == null)
            {
                instance = new CompanyinfoDAL();
            }

            return instance;
        }

        public CompanyinfoDAL()
        {
            db = new POSDB();
        }

        public companyinfo selectSingle(companyinfo findItem)
        {
            companyinfo selectedItem = db.companyinfoes.SingleOrDefault(item => item.id == findItem.id);

            return selectedItem;
        }

        public List<companyinfo> selectAll()
        {
            return db.companyinfoes.ToList();
        }

        public void insert(companyinfo newItem)
        {
            db.companyinfoes.Add(newItem);
            db.SaveChanges();            
        }

        public void update(companyinfo editItem)
        {
            companyinfo selectedItem = db.companyinfoes.SingleOrDefault(item => item.id == editItem.id);
            selectedItem.name = editItem.name;
            selectedItem.address_id = editItem.address_id;
            selectedItem.phone = editItem.phone;
            selectedItem.fax = editItem.fax;
            selectedItem.servicephone = editItem.servicephone;
            selectedItem.email = editItem.email;
            selectedItem.website = editItem.website;
            selectedItem.vatregistrationnumber = editItem.vatregistrationnumber;
            db.SaveChanges();
            
        }

        public void delete(companyinfo deleteItem)
        {
            companyinfo selectedItem= db.companyinfoes.First(item => item.id == deleteItem.id);
            db.companyinfoes.Remove(selectedItem);
            db.SaveChanges();
        }
    }
}
