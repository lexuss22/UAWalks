using UAWalks.API.Model.Domain;
using UAWalks.API.Model.DTO;

namespace UAWalks.API.Repository
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
        Task<Region> GetByIdAsync(Guid id);
        Task<Region> AddAsync(Region region);
        Task<Region> UpdateAsync(Guid id,Region region);
        Task<Region> DeleteAsync(Guid id);
    }
}
