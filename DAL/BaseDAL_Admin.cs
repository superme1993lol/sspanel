using Model.admin;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class BaseDAL_Admin
    {
        public stadminContext dbcontext;
        public BaseDAL_Admin(stadminContext _dbcontext = null)
        {
            if (_dbcontext != null)
            {
                dbcontext = _dbcontext;
            }
        }


    }
}
