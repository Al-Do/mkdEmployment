﻿using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
  public  class CompanyRepository : Repository<Company>, ICompanyRepository
    {
    }
}
