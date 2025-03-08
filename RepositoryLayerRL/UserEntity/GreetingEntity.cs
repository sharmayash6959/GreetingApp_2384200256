﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.UserEntity
{
    public class GreetingEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
