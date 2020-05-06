using Repository;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
  public  class CompanyService : Service<Company, ICompanyRepository>, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public override ICompanyRepository Repository
        {
            get; protected set;
        }
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
            Repository = _companyRepository;
        }
    }
}
