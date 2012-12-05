using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Datamodel;

namespace DAL.DALClasses
{
    public class RawStockProductDAL
    {
        POSDB db;
        static RawStockProductDAL instance;

        public static RawStockProductDAL getInstance()
        {
            if (instance == null)
            {
                instance = new RawStockProductDAL();
            }

            return instance;
        }

        public RawStockProductDAL()
        {
            db = new POSDB();
        }

        public rawstockproduct selectSingle(rawstockproduct findItem)
        {
            rawstockproduct selectedRawStockProduct = db.rawstockproducts.SingleOrDefault(item => item.id == findItem.id);

            return selectedRawStockProduct;
        }

        public List<rawstockproduct> selectAll()
        {
            return db.rawstockproducts.ToList();
        }

        public void insert(rawstockproduct newItem)
        {
            db.rawstockproducts.Add(newItem);
            db.SaveChanges();
        }

        public void update(rawstockproduct editItem)
        {
            rawstockproduct selectedRawStockProsuct = db.rawstockproducts.SingleOrDefault(item => item.id == editItem.id);
            selectedRawStockProsuct.code = editItem.code;
            selectedRawStockProsuct.name = editItem.name;            
            selectedRawStockProsuct.quantity = editItem.quantity;
            selectedRawStockProsuct.buyingprice = editItem.buyingprice;
            db.SaveChanges();

        }

        public void delete(rawstockproduct deleteItem)
        {
            rawstockproduct selectedItem= db.rawstockproducts.First(item => item.id == deleteItem.id);
            db.rawstockproducts.Remove(selectedItem);
            db.SaveChanges();
        }
    }
}
