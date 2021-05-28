using Model.ssr;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class BaseDAL_Ssr
    {
        public stssrContext dbcontext;
        public BaseDAL_Ssr(stssrContext _dbcontext = null)
        {
            if (_dbcontext != null)
            {
                dbcontext = _dbcontext;
            }
        }
    }
}
