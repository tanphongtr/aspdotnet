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

        public ProductModelView(string name) {
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
                value.Name
            );
            ApiDbContext db = new ApiDbContext();
            db.Products.Add(product);
            db.SaveChanges();

            // 201 Created

            // return Ok(product);

        }

        // add a new product and return the product
        [HttpPost("product")]
        public IActionResult PostProduct([FromBody] Product value)
        {
            Console.WriteLine(" --- value --- ");
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            ApiDbContext db = new ApiDbContext();
            db.Products.Add(value);
            var isSaved = db.SaveChanges();
            if(isSaved == 0) {
                return BadRequest("Cannot create new product");
            }

            // 201 Created
            return Ok(value);
        }
    }
}

