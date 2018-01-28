using System.Linq;
using System.Web.Http;
using WordChainGame.Data.Entities;
using WordChainGame.Services.Repositories;

namespace WordChainGame.Web.Controllers
{
    public class TopicController : ApiController
    {
        private readonly IGenericRepository<Topic> topicsRepository;

        public TopicController(IGenericRepository<Topic> topicsRepository)
        {
            this.topicsRepository = topicsRepository;
        }

        // GET: Topic
        public IQueryable<Topic> GetCustomerList()
        {
            var topics = topicsRepository.GetAll();
            return topicsRepository.GetAll();
        }
    }
}