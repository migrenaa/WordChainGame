using WordChainGame.Data.Entities;

namespace WordChainGame.Services.Services
{
    public interface IUserService
    {
        void DeleteUserEntities(string userId);
    }
}
