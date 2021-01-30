using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesAPI.Dtos.Quote
{
    public class QuoteCreateDto
    {
        [Required]
        public string Quote { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int AuthorId { get; set; }
    }
}
