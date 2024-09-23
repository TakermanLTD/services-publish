﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Takerman.Publishing.Data.Entities
{
    public class PlatformLink
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual Platform Platform { get; set; }

        [ForeignKey("PlatformLink_PlatformId")]
        public int PlatformId { get; set; }

        public string Url { get; set; } = string.Empty;
    }
}