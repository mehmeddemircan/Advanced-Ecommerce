﻿using Advanced_Ecommerce.Core.DataAccess;
using Advanced_Ecommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.DataAccess.Abstract
{
    public interface ISubCategoryRepository : IBaseRepository<SubCategory> 
    {
    }
}
