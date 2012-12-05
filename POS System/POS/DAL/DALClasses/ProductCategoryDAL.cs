using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Datamodel;

namespace DAL.DALClasses
{
    public class ProductCategoryDAL
    {
        POSDB db;
        static ProductCategoryDAL instance;

        public static ProductCategoryDAL getInstance()
        {
            if (instance == null)
            {
                instance = new ProductCategoryDAL();
            }

            return instance;
        }

        public ProductCategoryDAL()
        {
            db = new POSDB();
        }

        public productcategory selectSingle(productcategory findItem)
        {
            productcategory selectedItem = db.productcategories.SingleOrDefault(item => item.id == findItem.id);

            return selectedItem;
        }

        public List<productcategory> selectAll()
        {
            return db.productcategories.ToList();
        }

        public void insert(productcategory newItem)
        {
            db.productcategories.Add(newItem);
            db.SaveChanges();
        }

        public void update(productcategory editItem)
        {
            productcategory selectedItem = db.productcategories.SingleOrDefault(item => item.id == editItem.id);
            selectedItem.categorytype = editItem.categorytype;
            selectedItem.description = editItem.description;
            db.SaveChanges();
        }

        public void delete(productcategory deleteItem)
        {
            productcategory selectedItem = db.productcategories.First(item => item.id == deleteItem.id);
            db.productcategories.Remove(selectedItem);
            db.SaveChanges();
        }
    }
}
