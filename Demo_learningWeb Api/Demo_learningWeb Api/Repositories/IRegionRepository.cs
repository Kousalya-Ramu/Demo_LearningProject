using Demo_learningWeb_Api.Models;
using Demo_learningWeb_Api.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_learningWeb_Api.Repositories
{
    public interface IRegionRepository
    {
       Task<IEnumerable<Region>> GetAllAsync();
        Task<Region> GetAsync(Guid id);

        Task<Region> AddAsyn(Region region);
        Task <Region> AddAsyn(RegionDto region);
        Task<Region> DeleteAsync(Guid id);

        
        Task<RegionDto> UpdateAsync(Guid id, RegionDto region);
    }
}
