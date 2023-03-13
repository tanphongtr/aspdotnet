using System;
namespace AspNetAPI.Entites
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category(string name)
        {
            Name = name;
        }
        public ICollection<Product>? Products { get; set; }
    }

}

