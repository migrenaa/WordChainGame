﻿using System.Collections.Generic;

namespace WordChainGame.Data.Entities
{
    public partial class Topic
    {
        public Topic()
        {
            this.Words = new HashSet<Word>();
        }
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public int GameId { get; set; }
        public string Name { get; set; }
        public int WordsCount { get; set; }
        public Game Game { get; set; }
        public virtual ICollection<Word> Words { get; set; }
    }
}