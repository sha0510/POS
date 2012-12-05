using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Objects.DataClasses;
using System.Data.Metadata.Edm;
using DAL.Datamodel;

namespace DAL.DALClasses
{
    static class EntityUtil
    {
       // private POSDB db;

        public static TEntity SelectSingle<TEntity>(Expression<Func<TEntity>> predicate) where TEntity : EntityObject
        {
            POSDB db = new POSDB();
            
            return null;  
        }

        //public void selectList()
        //{

        //}

        //public void insert()
        //{
            
        //}

        //public void update()
        //{

        //}
        
        //public void delete()
        //{
        //}

        private static string GetEntitySetName<TEntity>(TEntity entity) where TEntity : EntityObject
        {
            //POSDB db = new POSDB();
            
            //var container = db.MetadataWorkspace.GetEntityContainer(db.DefaultContainerName, DataSpace.CSpace);

            //string setName = (from meta in container.BaseEntitySets
            //                  where meta.ElementType.Name == typeof(TEntity).Name
            //                  select meta.Name).First();

            return null;// setName;
        }
    }
}
