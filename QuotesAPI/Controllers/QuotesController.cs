using EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotesAPI.Dtos.Category;
using QuotesAPI.Dtos.Quote;
using QuotesAPI.Dtos.User;
using QuotesAPI.Models;
using QuotesAPI.Persistance;
using QuotesAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {

        private QuotesService _myService;
        private readonly CategoryService _categoryService;
        private readonly UserService _userService;
        private readonly FollowService _followService;
        private readonly IEmailSender _emailSender;

        public QuotesController(QuotesService myService,
            CategoryService categoryService,
            UserService userService,
            FollowService followService,
            IEmailSender emailSender)
        {
            _myService = myService;
            _categoryService = categoryService;
            _userService = userService;
            _followService = followService;
            _emailSender = emailSender;
        }

        // GET api/quotes
        [HttpGet]
        public ActionResult<List<QuoteGetDto>> Get()
        {
            var quotes = _myService.GetAll();
            var res = new List<QuoteGetDto>();

            foreach(var q in quotes)
            {
                var user = _userService.GetById(q.AuthorId);
                var category = _categoryService.GetById(q.CategoryId);

                var qgetdto = new QuoteGetDto
                {
                    Id = q.Id,
                    Quote = q.Quote,
                    Category = new CategoryGetDto { Id = category.Id, Name = category.Name },
                    User = new UserGetDto { Id = user.Id, Username = user.Username, Email = user.Email}
                };

                res.Add(qgetdto);
            }

            return res;
        }

        // GET api/quotes/send-daily
        [HttpGet("send-daily")]
        public ActionResult SendDaily()
        {
            var follows = _followService.All();
            if (follows.Count == 0)
                return NoContent();
            var quote = _myService.RandomQuote();
            var emails = new List<string>();

            foreach(var follow in follows)
            {
                var user = _userService.GetById(follow.UserId);
                emails.Add(user.Email);
            }
            var message = new Message(emails, "Daily Quotes", quote.Quote);
            _emailSender.SendEmail(message);

            return Ok();
        }

        // GET api/quotes/5
        [HttpGet("{id}")]
        public ActionResult<QuoteModel> Get(int id)
        {
            if (!_myService.Exists(id))
                return NotFound();

            return _myService.GetById(id);
        }

        // GET api/quotes/category/abc
        [HttpGet("category/{category}")]
        public ActionResult<List<QuoteModel>> Get(string category)
        {
            if (!_categoryService.Exists(category))
                return NotFound();

            return _myService.QuotesByCategoryName(category);
        }

        // GET api/quotes/random
        [HttpGet("random")]
        public ActionResult<QuoteModel> Random()
        {
            return _myService.RandomQuote();
        }

        // POST api/quotes
        [HttpPost]
        public IActionResult Post([FromBody] QuoteCreateDto value)
        {
            _myService.AddQuote(value);
            return Ok();
        }

        // PUT api/quotes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] QuoteCreateDto value)
        {
            if (!_myService.Exists(id))
               return NotFound();

            _myService.UpdateQuote(id, value);

            return Ok();

        }

        // DELETE api/quotes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_myService.Exists(id))
                return NotFound();

            _myService.RemoveQuote(id);

            return Ok();
        }

        // DELETE api/quotes/clear
        [HttpDelete("clear")]
        public IActionResult DeleteByOffset()
       {
            _myService.RemoveAll();
            return Ok();
        }

        [HttpGet("follow/{user_id}")]
        public ActionResult Follow(int user_id)
        {
            if (!_userService.Exists(user_id))
                return NotFound();

            _followService.Follow(user_id);
            return Ok();
        }

        [HttpGet("unfollow/{user_id}")]
        public ActionResult Unfollow(int user_id)
        {
            if (!_userService.Exists(user_id))
                return NotFound();
            _followService.Unfollow(user_id);
            return Ok();
        }


    }
}
