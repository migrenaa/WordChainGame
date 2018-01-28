using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordChainGame.Data.Entities
{
    public partial class Word
    {
        public Word()
        {
            this.InappropriateWordRequests = new HashSet<InappropriateWordRequest>();
        }
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string WordContent { get; set; }
        public DateTime DateCreated { get; set  ; }
        public Topic Topic { get; set; }
        public virtual ICollection<InappropriateWordRequest> InappropriateWordRequests { get; set; }

    }
}
