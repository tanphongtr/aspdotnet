using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetAPI.Entites
{
    public class User
    {
        // [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public Product Product { get; set; }
    }
}

