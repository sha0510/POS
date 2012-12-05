using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DAL.DALClasses;
using DAL.Datamodel;

namespace POS.Test.TestCode
{
    
    class TestProduct
    {
        [Test]
        public void testAddData()
        {
            product p = new product();
            p.code = "p001";
            p.name = "Pizza";
            p.allprice = 10;

            ProductDAL productDAL = new ProductDAL();
            productDAL.insert(p);
        }
    }
}
