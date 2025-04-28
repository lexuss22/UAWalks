using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using UAWalks.API.Data;
using UAWalks.API.Model.Domain;
using UAWalks.API.Model.DTO;

namespace UAWalks.API.Repository
{
    public class RegionRepository : IRegionRepository
    {
        private readonly UAWalksDbContext dbContext;

        public RegionRepository(UAWalksDbContext uAWalksDbContext)
        {
            dbContext = uAWalksDbContext;
        }


        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
           return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> AddAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (existingRegion == null) 
            { 
                return null; 
            }

            existingRegion.Name = region.Name;
            existingRegion.Code = region.Code;
            existingRegion.Area = region.Area;
            existingRegion.Lat = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;

            await dbContext.SaveChangesAsync();
            return existingRegion;
        }


        public async Task<Region?> DeleteAsync(Guid id)
        {
            var region = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (region == null)
            {
                return null;
            }

            dbContext.Regions.Remove(region);
            await dbContext.SaveChangesAsync();
            return region;
        }
    }
}
