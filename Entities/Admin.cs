﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string ImageURL { get; set; }
        public string Role { get; set; }
    }
}
