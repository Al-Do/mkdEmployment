
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
  public  class RegionService : Service<Region, IRegionRepository>, IRegionService
    {
        private readonly IRegionRepository _regionRepository;
        public override IRegionRepository Repository
        {
            get; protected set;
        }
        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
            Repository = _regionRepository;
        }
    }
}
