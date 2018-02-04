using System.Linq;
using WordChainGame.Common.Enumerations;
using WordChainGame.Data.Entities;
using WordChainGame.Services.Repositories;

namespace WordChainGame.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<Topic> topics;
        private readonly IGenericRepository<Word> words;
        private readonly IGenericRepository<InappropriateWordRequest> inappropriateWordRequests;
        private readonly IGenericRepository<User> users;

        public UserService(IGenericRepository<Topic> topics, IGenericRepository<Word> words,
            IGenericRepository<InappropriateWordRequest> inappropriateWordRequests, IGenericRepository<User> users)
        {
            this.topics = topics;
            this.words = words;
            this.users = users;
            this.inappropriateWordRequests = inappropriateWordRequests;
        }
        public void DeleteUserEntities(string userId)
        {
            var topicsToDelete = topics.Get(x => x.AuthorId == userId);

            foreach (var topic in topicsToDelete)
            {
                this.topics.Delete(topic);
            }

            var wordsToDelete = words.Get(x => x.AuthorId == userId);

            foreach (var word in wordsToDelete)
            {
                this.words.Delete(word);
            }

            var inappropriateWordRequestsToDelete = inappropriateWordRequests.Get(x => x.RequesterId == userId);

            foreach (var request in inappropriateWordRequestsToDelete)
            {
                this.inappropriateWordRequests.Delete(request);
            }
            
        }

        public User GetAdmin()
        {
            return this.users.Get(x => x.Roles.Select(r => r.RoleId).Contains(UserRole.Admin.ToString()))?.SingleOrDefault();
        }
    }
}
