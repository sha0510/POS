using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.DALClasses;
using DAL.Datamodel;
using NUnit.Framework;

namespace POS.Test.TestCode
{
    class TestMenu
    {
        [Test]
        public void testAddData()
        {
            menu m = new menu();
            m.name = "Pizaa";
            m.description = "Pizza menu";
            m.position = 1;

            MenuDAL menuDAL = MenuDAL.getInstance();
            menuDAL.insert(m);
        }

        [Test]
        public void testGetData()
        {
            MenuDAL menuDal = MenuDAL.getInstance();
            menu m = new menu();
            m.id = 1;
            m = menuDal.selectSingle(m);
            Assert.AreEqual(m.name, "Pizzaa");
        }

        [Test]
        public void testDeleteData()
        {
            MenuDAL menuDal = MenuDAL.getInstance();
            menu m = new menu();
            m.id = 1;
            m = menuDal.selectSingle(m);
            menuDal.delete(m);
            
            //Assert.AreEqual(m.name, "Pizzaa");
        }
    }
}
