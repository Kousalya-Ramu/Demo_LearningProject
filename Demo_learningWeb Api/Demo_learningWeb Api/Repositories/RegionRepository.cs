using Demo_learningWeb_Api.Data;
using Demo_learningWeb_Api.Models;
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

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
           return await walkDbContext.Regions.ToListAsync();
        }
    }
}
