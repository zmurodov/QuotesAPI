using QuotesAPI.Dtos.Category;
using QuotesAPI.Dtos.User;
using QuotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesAPI.Dtos.Quote
{
    public class QuoteGetDto
    {
        public int Id { get; set; }
        public string Quote { get; set; }
        public CategoryGetDto Category { get; set; }
        public UserGetDto User{ get; set; }
    }
}
