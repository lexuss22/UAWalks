using UAWalks.API.Model.DTO;

namespace UAWalks.API.Repository
{
    public interface ILog
    {
        public Task<string?> Loging(RequestLoginDto request);
    }
}
