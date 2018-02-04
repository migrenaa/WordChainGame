using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordChainGame.DTO.Topic
{
    public class TopicModel 
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public int GameId { get; set; }
        public string Name { get; set; }
        public int WordsCount { get; set; }
    }
}
