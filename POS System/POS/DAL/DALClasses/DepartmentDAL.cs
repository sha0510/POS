using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Datamodel;

namespace DAL.DALClasses
{
    public class DepartmentDAL
    {
        POSDB db;
        static DepartmentDAL instance;

        public static DepartmentDAL getInstance()
        {
            if (instance == null)
            {
                instance = new DepartmentDAL();
            }

            return instance;
        }

        public DepartmentDAL()
        {
            db = new POSDB();
        }

        public department selectSingle(department findItem)
        {
            department selectedItem = db.departments.SingleOrDefault(item => item.id == findItem.id);

            return selectedItem;
        }

        public List<department> selectAll()
        {
            return db.departments.ToList();
        }

        public void insert(department newItem)
        {
            db.departments.Add(newItem);
            db.SaveChanges();
        }

        public void update(department editItem)
        {
            department selectedItem = db.departments.SingleOrDefault(item => item.id == editItem.id);
            selectedItem.name = editItem.name;
            selectedItem.description = editItem.description;
            db.SaveChanges();
        }

        public void delete(department deleteItem)
        {
            department selectedItem = db.departments.First(item => item.id == deleteItem.id);
            db.departments.Remove(selectedItem);
            db.SaveChanges();
        }
    }
}
