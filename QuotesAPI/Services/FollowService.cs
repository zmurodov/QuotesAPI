using QuotesAPI.Models;
using QuotesAPI.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesAPI.Services
{
    public class FollowService
    {
        private readonly ApplicationDbContext _context;

        public FollowService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<FollowUserQuote> All()
        {
            return _context.UserFollowing;
        }

        public void Follow(int userId)
        {
            var follow = new FollowUserQuote
            {
                Id = _context.IncrementFollowId(),
                UserId = userId
            };

            _context.UserFollowing.Add(follow);
        }

        public void Unfollow(int userId)
        {
            _context.UserFollowing.RemoveAt(
                _context.UserFollowing.FindIndex(f => f.UserId == userId));

        }
    }
}
