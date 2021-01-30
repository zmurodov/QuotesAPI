using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuotesAPI.Models
{
    public class QuoteModel
    {
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("quote")]
        public string Quote { get; set; }

        [Required]
        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }

        [Required]
        [JsonPropertyName("author_id")]
        public int AuthorId { get; set; }
        
        [JsonIgnore]
        public DateTime CreatedTime { get; set; }

        [JsonIgnore]
        public DateTime UpdatedTime { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }

        [JsonIgnore]
        public virtual User User{ get; set; }

    }
}
