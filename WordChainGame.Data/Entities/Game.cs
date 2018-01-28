using System;
using System.Collections.Generic;

namespace WordChainGame.Data.Entities
{
    public partial class Game
    {
        public Game()
        {
            this.Topics = new HashSet<Topic>();
        }
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
