using Microsoft.AspNetCore.Mvc;
using QuotesAPI.Dtos.Category;
using QuotesAPI.Models;
using QuotesAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesAPI.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoriesController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET api/categories
        [HttpGet]
        public ActionResult<List<Category>> Get()
        {
            return _categoryService.GetAll();
        }

        // GET api/categories/5
        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            if (!_categoryService.Exists(id))
                return NotFound();

            return _categoryService.GetById(id);
        }


        // POST api/categories
        [HttpPost]
        public IActionResult Post([FromBody] CategoryCreateDto value)
        {
            _categoryService.Add(value);
            return Ok();
        }

        // PUT api/categories/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoryCreateDto value)
        {
            if (!_categoryService.Exists(id))
                return NotFound();

            _categoryService.Update(id, value);

            return Ok();

        }

        // DELETE api/categories/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_categoryService.Exists(id))
                return NotFound();

            _categoryService.Remove(id);

            return Ok();
        }
    }
}
