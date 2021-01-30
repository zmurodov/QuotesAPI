using Microsoft.AspNetCore.Mvc;
using QuotesAPI.Dtos.User;
using QuotesAPI.Models;
using QuotesAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        // GET api/users
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return _userService.GetAll();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            if (!_userService.Exists(id))
                return NotFound();

            return _userService.GetById(id);
        }


        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody] UserCreateDto value)
        {
            _userService.Add(value);
            return Ok();
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserCreateDto value)
        {
            if (!_userService.Exists(id))
                return NotFound();

            _userService.Update(id, value);

            return Ok();

        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_userService.Exists(id))
                return NotFound();

            _userService.Remove(id);

            return Ok();
        }
    }
}
