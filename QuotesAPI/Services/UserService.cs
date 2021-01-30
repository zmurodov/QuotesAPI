using QuotesAPI.Dtos.User;
using QuotesAPI.Models;
using QuotesAPI.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesAPI.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public void Add(UserCreateDto value)
        {
            var user = new User
            {
                Id = _context.IncrementUserId(),
                Username = value.Name,
                Email = value.Email
            };
            _context.Users.Add(user);
        }
        public void Update(int id, UserCreateDto value)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            user.Username= value.Name?? user.Username;
            user.Email = value.Email ?? user.Email;
        }

        public void Remove(int id)
        {
            if (Exists(id))
            {
                _context.Users.RemoveAt(_context.Users.FindIndex(u => u.Id == id));
            }
        }


        public bool Exists(int id)
        {
            if (_context.Users.Count == 0) return false;

            return _context.Users.FindIndex(u => u.Id == id) != -1;
        }
    }
}
