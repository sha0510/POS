using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Datamodel;

namespace DAL.DALClasses
{
    public class MenuDAL
    {
        POSDB db;
        static MenuDAL instance;

        public static MenuDAL getInstance()
        {
            if (instance == null)
            {
                instance = new MenuDAL();
            }

            return instance;
        }

        public MenuDAL()
        {
            db = new POSDB();
        }

        public menu selectSingle(menu findItem)
        {
            menu selectedItem = db.menus.SingleOrDefault(item => item.id == findItem.id);

            return selectedItem;
        }

        public List<menu> selectAll()
        {
            return db.menus.ToList();
        }

        public void insert(menu newItem)
        {
            db.menus.Add(newItem);
            db.SaveChanges();
        }

        public void update(menu editItem)
        {
            menu selectedItem = db.menus.SingleOrDefault(item => item.id == editItem.id);
            selectedItem.name = editItem.name;
            selectedItem.description = editItem.description;
            selectedItem.position = editItem.position;
            selectedItem.buttoncolor = editItem.buttoncolor;
            selectedItem.buttontextcolor = editItem.buttontextcolor;
            db.SaveChanges();
        }

        public void delete(menu deleteItem)
        {
            menu selectedItem= db.menus.First(item => item.id == deleteItem.id);
            db.menus.Remove(selectedItem);
            db.SaveChanges();
        }
    }
}
