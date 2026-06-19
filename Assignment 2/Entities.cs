using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2
{
    public class Entities
    {
        [Table("Users")]
        public class User
        {
            [Key]
            public int Id { get; set; }

            [Column("FirstName")]
            public string FirstName { get; set; } = string.Empty;

            [Column("LastName")]
            public string LastName { get; set; } = string.Empty;

            [Column("Email")]
            public string Email { get; set; } = string.Empty;
        }
    }
}