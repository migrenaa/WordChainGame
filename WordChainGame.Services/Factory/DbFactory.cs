
namespace WordChainGame.Services.Factory
{
    using WordChainGame.Data.Model;

    public class DbFactory : IDbFactory
    {
        WordChainGameContext dbContext;

        public WordChainGameContext Init()
        {
            return dbContext ?? (dbContext = new WordChainGameContext());
        }
    }
}
