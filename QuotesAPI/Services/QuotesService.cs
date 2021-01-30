using QuotesAPI.Dtos.Quote;
using QuotesAPI.Models;
using QuotesAPI.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesAPI.Services
{
    public class QuotesService
    {
        private readonly ApplicationDbContext _context;

        public QuotesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<QuoteModel> GetAll()
        {
            return _context.quotes;
        }

        public List<QuoteModel> QuotesByCategoryName(string category)
        {
            return _context.quotes.FindAll(q =>
                  q.CategoryId == _context.Categories.FirstOrDefault(s =>
                        s.Name.ToLower() == category.ToLower()).Id);
        }

        public List<QuoteModel> QuotesByCategoryId(int categoryId)
        {
            return _context.quotes.FindAll(q =>
                  q.CategoryId == categoryId);
        }

        public QuoteModel RandomQuote()
        {
            if (_context.quotes.Count == 0) 
                return null;

            int RandomId = new Random().Next(0, _context.quotes.Count);
            return _context.quotes[RandomId];
        }

        public QuoteModel GetById(int id)
        {
            return _context.quotes.FirstOrDefault(q => q.Id == id);
        }

        public void AddQuote(QuoteCreateDto value)
        {
            var quote = new QuoteModel
            {
                Id = _context.IncrementQuoteId(),
                CategoryId = value.CategoryId,
                AuthorId = value.AuthorId,
                Quote = value.Quote,
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now,
            };
            _context.quotes.Add(quote);
        }

        public void UpdateQuote(int id, QuoteCreateDto value)
        {
            var quote = _context.quotes.FirstOrDefault(q => q.Id == id);
            var creationTime = quote.CreatedTime;
            
            quote.Quote = value.Quote ?? quote.Quote;
            quote.CategoryId = value.CategoryId;
            quote.AuthorId = value.AuthorId;
            quote.UpdatedTime = DateTime.Now;
            quote.CreatedTime = creationTime;
        }

        public void RemoveQuote(int id)
        {
            if (Exists(id))
            {
                _context.quotes.RemoveAt( _context.quotes.FindIndex(q => q.Id == id));
            }
        }

        public bool Exists(int id)
        {
            if (_context.quotes.Count == 0) return false;

            var res = _context.quotes.FindIndex(q => q.Id == id) != -1;
            return res;
        }

        public void RemoveAll()
        {
            if (_context.quotes.Count == 0) 
                return;
            _context.quotes.RemoveAll(IsDayElapsed);
        }

        private bool IsDayElapsed(QuoteModel item)
        {
            var res = DateTime.Now.Subtract(item.CreatedTime).TotalMinutes > 1440;
            return res;
        }
    }
}
