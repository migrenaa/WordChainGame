
namespace WordChainGame.Services.Factory
{
    using WordChainGame.Data.Model;

    public interface IDbFactory
    {
        WordChainGameContext Init();
    }
}
