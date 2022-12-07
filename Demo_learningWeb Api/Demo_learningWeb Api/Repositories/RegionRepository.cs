using Demo_learningWeb_Api.Data;
using Demo_learningWeb_Api.Models;
using Demo_learningWeb_Api.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_learningWeb_Api.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly WalkDbContext walkDbContext;

        public RegionRepository(WalkDbContext walkDbContext)
        {
            this.walkDbContext = walkDbContext;
           
        }

        public async Task<Region> AddAsyn(Region region)
        {
            region.id = Guid.NewGuid();
           await walkDbContext.AddAsync(region);
           await walkDbContext.SaveChangesAsync();
            return region;

        }

        public async Task<Region> AddAsyn(RegionDto region)
        {
            return await walkDbContext.Regions.FirstOrDefaultAsync();
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await walkDbContext.Regions.FirstOrDefaultAsync(x => x.id == id);
            if(region== null)
            {
                return null;
            }
            walkDbContext.Regions.Remove(region);
            await walkDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
           return await walkDbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
            return await walkDbContext.Regions.FirstOrDefaultAsync(x => x.id == id);
        }

        

        public async Task<RegionDto> UpdateAsync(Guid id, RegionDto region)
        {
                var exisitingregion = await walkDbContext.Regions.FirstOrDefaultAsync(x => x.id == id);
                if (exisitingregion == null)
                {
                    return null;
                }
                exisitingregion.Code = region.Code;
                exisitingregion.Name = region.Name;
                exisitingregion.lat = region.lat;
                exisitingregion.Long = region.Long;
                exisitingregion.Populatation = (long)region.Populatation;

                await walkDbContext.SaveChangesAsync();
                return exisitingregion;
            }

        
    }
}
