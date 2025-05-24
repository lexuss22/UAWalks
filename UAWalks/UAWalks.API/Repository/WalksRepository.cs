using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using UAWalks.API.Data;
using UAWalks.API.Model.Domain;

namespace UAWalks.API.Repository
{
    public class WalksRepository : IWalkRepository
    {
        private readonly UAWalksDbContext uAWalksDbContext;

        public WalksRepository(UAWalksDbContext uAWalksDbContext)
        {
            this.uAWalksDbContext = uAWalksDbContext;
        }

        public async Task<IEnumerable<Walk>> GetAsync()
        {
            return await uAWalksDbContext.Walks.ToListAsync();
        }

        public async Task<Walk?> GetAsyncById(Guid id)
        {
            return await uAWalksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Walk?> CreateAsync(Walk walk)
        {
            await uAWalksDbContext.Walks.AddAsync(walk);
            await uAWalksDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var exWalk = await uAWalksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (exWalk == null) return null;

            exWalk.Name = walk.Name;
            exWalk.Length = walk.Length;
            exWalk.RegionId = walk.RegionId;
            exWalk.DifficultyId = walk.DifficultyId;
            await uAWalksDbContext.SaveChangesAsync();
            return exWalk;
        }        

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var walk = uAWalksDbContext.Walks.FirstOrDefault(x => x.Id == id);
            if (walk == null) return null;

            uAWalksDbContext.Remove(walk);
            await uAWalksDbContext.SaveChangesAsync();
            return walk;
        }

    }
}
