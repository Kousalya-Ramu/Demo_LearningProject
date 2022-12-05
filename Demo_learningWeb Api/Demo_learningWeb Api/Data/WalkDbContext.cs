using Demo_learningWeb_Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_learningWeb_Api.Data
{
    public class WalkDbContext: DbContext
    {
        public WalkDbContext(DbContextOptions<WalkDbContext> options): base(options)
        {


        }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> walks { get; set; }
        public DbSet<WalkDifficultyId> walkDifficulties { get; set; }

    }
}
