
using Services.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
   public interface IDisplayPostService
    {
        JobPostingModel GetPosting(int jobPostingID);
        List<ShortJobPosting> GetPostingsByRegion(int regionId);
    }
}
