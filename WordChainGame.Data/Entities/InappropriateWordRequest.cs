using System;

namespace WordChainGame.Data.Entities
{
    public partial class InappropriateWordRequest
    { 
        public int Id { get; set; }
        public int InappropriateWordId { get; set; }
        public bool IsInappropriate { get; set; }
        public DateTime DateCreated { get; set; }
        public Word InappropriateWord { get; set; }
    }
}
