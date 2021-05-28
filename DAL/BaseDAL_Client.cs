using Model.client;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace DAL
{
    public class BaseDAL_Client
    {
        public stclientContext dbcontext;
        public BaseDAL_Client(stclientContext _dbcontext = null)
        {
            if (_dbcontext != null)
            {
                dbcontext = _dbcontext;
            }
        }
    }
}
