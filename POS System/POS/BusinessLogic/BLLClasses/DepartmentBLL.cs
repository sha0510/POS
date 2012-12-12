using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Datamodel;
using DAL.DALClasses;

namespace BusinessLogic.BLLClasses
{
    public class DepartmentBLL
    {
        DepartmentDAL departmentDAL;

        public void addNewData(department newData)
        {
            departmentDAL = DepartmentDAL.getInstance();

            department existingData = departmentDAL.findByName(newData);

            if (existingData == null)
            {
                departmentDAL.insert(newData);
            }
            else
            {

            }
        }
    }
}
