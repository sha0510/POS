using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Datamodel;

namespace DAL.DALClasses
{
    public class ServiceTypeDAL
    {
        POSDB db;
        static ServiceTypeDAL instance;

        public static ServiceTypeDAL getInstance()
        {
            if (instance == null)
            {
                instance = new ServiceTypeDAL();
            }

            return instance;
        }

        public ServiceTypeDAL()
        {
            db = new POSDB();
        }

        public servicetype selectSingle(servicetype findItem)
        {
            servicetype selectedItem= db.servicetypes.SingleOrDefault(item => item.id == findItem.id);

            return selectedItem;
        }

        public List<servicetype> selectAll()
        {
            return db.servicetypes.ToList();
        }

        public void insert(servicetype newItem)
        {
            db.servicetypes.Add(newItem);
            db.SaveChanges();
        }

        public void update(servicetype editItem)
        {
            servicetype selectedItem = db.servicetypes.SingleOrDefault(item => item.id == editItem.id);
            selectedItem.name = editItem.name;
            selectedItem.description = editItem.description;
            db.SaveChanges();
        }

        public void delete(servicetype deleteItem)
        {
            servicetype selectedItem = db.servicetypes.First(item => item.id == deleteItem.id);
            db.servicetypes.Remove(selectedItem);
            db.SaveChanges();
        }
    }
}
