using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Datamodel;

namespace DAL.DALClasses
{
    public class StaffDAL
    {
        POSDB db;
        static StaffDAL instance;

        public static StaffDAL getInstance()
        {
            if (instance == null)
            {
                instance = new StaffDAL();
            }

            return instance;
        }

        public StaffDAL()
        {
            db = new POSDB();
        }

        public staff selectSingle(staff findItem)
        {
            staff selectedItem = db.staffs.SingleOrDefault(item => item.id == findItem.id);

            return selectedItem;
        }

        public List<staff> selectAll()
        {
            return db.staffs.ToList();
        }

        public void insert(staff newItem)
        {
            db.staffs.Add(newItem);
            db.SaveChanges();
        }

        public void update(staff editItem)
        {
            staff selectedItem = db.staffs.SingleOrDefault(item => item.id == editItem.id);
            selectedItem.code = editItem.code;
            selectedItem.lastname = editItem.lastname;
            selectedItem.firstname = editItem.firstname;
            selectedItem.dateofbirth = editItem.dateofbirth;
            selectedItem.designation = editItem.designation;
            selectedItem.phone = editItem.phone;
            selectedItem.mobile = editItem.mobile;
            selectedItem.email = editItem.email;
            selectedItem.hiredate = editItem.hiredate;
            selectedItem.status = editItem.status;
            selectedItem.address_id = editItem.address_id;
            selectedItem.department_id = editItem.department_id;
            selectedItem.image = editItem.image;
            db.SaveChanges();

        }

        public void delete(staff deleteItem)
        {
            staff selectedItem = db.staffs.First(item => item.id == deleteItem.id);
            db.staffs.Remove(selectedItem);
            db.SaveChanges();
        }
    }
}
