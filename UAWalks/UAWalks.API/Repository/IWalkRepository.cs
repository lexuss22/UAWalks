using UAWalks.API.Model.Domain;

namespace UAWalks.API.Repository
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetAsync();
        Task<Walk?> GetAsyncById(Guid id);
        Task<Walk?> CreateAsync(Walk walk);
        Task<Walk?> UpdateAsync(Guid id,Walk walk);
        Task<Walk?> DeleteAsync(Guid id);
    }
}
