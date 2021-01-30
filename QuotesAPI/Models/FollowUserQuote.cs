using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuotesAPI.Models
{
    public class FollowUserQuote
    {
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

    }
}
