using QuotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesAPI.Persistance
{
    public class ApplicationDbContext
    {
        private int quoteID = 0;
        private int categoryID = 0;
        private int userID = 0;
        private int followID = 0;

        public List<QuoteModel> quotes = new List<QuoteModel>();

        public List<Category> Categories = new List<Category>();

        public List<User> Users = new List<User>();

        public List<FollowUserQuote> UserFollowing = new List<FollowUserQuote>();

        public int IncrementQuoteId()
        {
            return ++quoteID;
        }

        public int IncrementCategoryId()
        {
            return ++categoryID;
        }

        public int IncrementUserId()
        {
            return ++userID;
        }

        public int IncrementFollowId()
        {
            return ++followID;
        }
    }
}
