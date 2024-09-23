﻿using System.ComponentModel.DataAnnotations;

namespace Takerman.Publishing.Data.Entities
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}