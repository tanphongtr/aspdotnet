using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetAPI.Entites
{
    public class Product
    {
        // [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        // relationship one to one with User
        public int UserId { get; set; }
        public User User { get; set; }

        public Product(string name, int categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }
    }
}
