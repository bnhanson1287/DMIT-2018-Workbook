using StaffSystem.DAL;
using StaffSystem.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffSystem.BLL
{
    [DataObject]
    public class StaffController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Staff> ListStaff()
        {
            using(var context = new StaffContext())
            {
                return context.Staff.ToList();
            }
        }
    }
}
