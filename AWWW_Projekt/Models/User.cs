using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AWWW_Projekt.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public UserRole UserRole { get; set; }
        public string PasswordHash { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime RegisteredAt { get; set; }
        //public ICollection<Post> Posts { get; set; }
    }



}
