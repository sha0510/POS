using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Datamodel;

namespace DAL.DALClasses
{
    public class PostcodeDAL
    {
        POSDB db;
        static PostcodeDAL instance;

        public static PostcodeDAL getInstance()
        {
            if (instance == null)
            {
                instance = new PostcodeDAL();
            }

            return instance;
        }

        public PostcodeDAL()
        {
            db = new POSDB();
        }

        public postcode selectSingle(postcode findItem)
        {
            postcode selectedItem = db.postcodes.SingleOrDefault(item => item.id == findItem.id);

            return selectedItem;
        }

        public List<postcode> selectAll()
        {
            return db.postcodes.ToList();
        }

        public void insert(postcode newItem)
        {
            db.postcodes.Add(newItem);
            db.SaveChanges();            
        }

        public void update(postcode editItem)
        {
            postcode selectedItem = db.postcodes.SingleOrDefault(item => item.id == editItem.id);
            selectedItem.code = editItem.code;
            db.SaveChanges();
            
        }

        public void delete(postcode deleteItem)
        {
            postcode selectedItem= db.postcodes.First(item => item.id == deleteItem.id);
            db.postcodes.Remove(selectedItem);
            db.SaveChanges();
        }
    }
}
