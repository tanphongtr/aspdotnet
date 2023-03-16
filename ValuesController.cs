using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetAPI.Entites;
using AspNetAPI.EF;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetAPI
{
    public class ProductModelView {

        [Required]
        public string Name { get; set; }
        // public int Id { get; set; }

        public int CategoryId { get; set; }

        public ProductModelView(string name, int categoryId) {
            Name = name;
            // Id = 1;
            CategoryId = categoryId;
        }
    }

    public class CategoryModelView {

        [Required]
        public string Name { get; set; }
        public int Id { get; set; }

        public CategoryModelView(string name) {
            Name = name;
            // Id = 1;
        }
    }
    

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            Console.WriteLine(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // FromBody as a json object by default
        [HttpPost("json")]
        public void PostJson([FromBody] ProductModelView value)
        {
            Product product = new Product(
                // value.Id,
                value.Name,
                value.CategoryId
            );
            ApiDbContext db = new ApiDbContext();
            db.Products.Add(product);
            db.SaveChanges();

            // 201 Created

            // return Ok(product);

        }

        // add a new product and return the product
        [HttpPost("product")]
        public IActionResult PostProduct([FromBody] ProductModelView value)
        {
            Console.WriteLine(" --- value --- ");
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            ApiDbContext db = new ApiDbContext();
            Product product = new Product(
                // value.Id,
                name: value.Name,
                categoryId: value.CategoryId
            );
            db.Products.Add(product);
            var isSaved = db.SaveChanges();
            if(isSaved == 0) {
                return BadRequest("Cannot create new product");
            }

            // 201 Created
            Console.WriteLine(value);
            
            return Ok(value);
        }

        // add a new category and return the category
        [HttpPost("category")]
        public IActionResult PostCategory([FromBody] CategoryModelView value)
        {
            Console.WriteLine(" --- value --- ");
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            ApiDbContext db = new ApiDbContext();
            Category category = new Category(
                // value.Id,
                value.Name
            );
            // create a new category and return the category
            db.Categories.Add(category);
            var isSaved = db.SaveChanges();
            if(isSaved == 0) {
                return BadRequest("Cannot create new category");
            }

            var savedEntity = db.Categories.FirstOrDefault(e => e.Id == category.Id);


            // 201 Created
            Console.WriteLine(value);
            
            return Ok(savedEntity);
        }
    }
}

