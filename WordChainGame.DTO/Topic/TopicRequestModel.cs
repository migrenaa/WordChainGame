using System.ComponentModel.DataAnnotations;

namespace WordChainGame.DTO.Topic
{
    public class TopicRequestModel
    {
        [Required]
        public string Name { get; set; }
    }
}
