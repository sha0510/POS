using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Datamodel;

namespace DAL.DALClasses
{
    public class ProductDAL
    {
        POSDB db;
        static ProductDAL instance;

        public static ProductDAL getInstance()
        {
            if (instance == null)
            {
                instance = new ProductDAL();
            }

            return instance;
        }

        public ProductDAL()
        {
            db = new POSDB();
        }

        public product selectSingle(product findItem)
        {
            product selectedItem = db.products.SingleOrDefault(item => item.id == findItem.id);

            return selectedItem;
        }

        public List<product> selectAll()
        {
            return db.products.ToList();
        }

        public void insert(product newItem)
        {
            db.products.Add(newItem);
            db.SaveChanges();
        }

        public void update(product editItem)
        {
            product selectedItem = db.products.SingleOrDefault(item => item.id == editItem.id);
            selectedItem.code = editItem.code;
            selectedItem.name = editItem.name;
            selectedItem.receiptdescription = editItem.receiptdescription;
            selectedItem.status = editItem.status;
            selectedItem.prepproduct = editItem.prepproduct; 
            selectedItem.preplocation = editItem.preplocation;
            selectedItem.buyingprice = editItem.buyingprice;
            selectedItem.dineinprice = editItem.dineinprice;
            selectedItem.collectionprice = editItem.collectionprice;
            selectedItem.waitingprice = editItem.waitingprice;
            selectedItem.deliveryprice = editItem.deliveryprice;
            selectedItem.allprice = editItem.allprice;
            selectedItem.stockproduct = editItem.stockproduct;
            selectedItem.stockquantity = editItem.stockquantity;
            selectedItem.discountable = editItem.discountable;
            selectedItem.popupmessage = editItem.popupmessage;
            selectedItem.lookupcode = editItem.lookupcode;
            selectedItem.receiptcopies = editItem.receiptcopies;
            selectedItem.productcategory_id = editItem.productcategory_id;
            selectedItem.menu_id = editItem.menu_id;

            db.SaveChanges();
            

        }

        public void delete(product deleteItem)
        {
            product selectedItem = db.products.First(item => item.id == deleteItem.id);
            db.products.Remove(selectedItem);
            db.SaveChanges();
        }
    }
}
