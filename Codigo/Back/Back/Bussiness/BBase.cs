using HirCasa.Back.Persistence.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HirCasa.Back.Bussiness
{
    public class BBase
    {
        protected DbHirCasa dbContext;
        public BBase()
        {
            dbContext = new DbHirCasa();
        }
        public BBase(DbHirCasa fAST_POS)
        {
            dbContext = fAST_POS;
        }
    }
}
