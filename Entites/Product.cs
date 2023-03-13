using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetAPI.Entites
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        // product category foreign key
        public int CategoryId { get; set; }

        // product category navigation property
        public Category Category { get; set; }

        public Product(string name)
        {
            Name = name;
        }
    }
}

