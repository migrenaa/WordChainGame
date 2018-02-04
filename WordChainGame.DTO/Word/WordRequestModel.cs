using System.ComponentModel.DataAnnotations;

namespace WordChainGame.DTO.Word
{
    public class WordRequestModel
    {
        [Required]
        public string Word { get; set; }
    }
}
