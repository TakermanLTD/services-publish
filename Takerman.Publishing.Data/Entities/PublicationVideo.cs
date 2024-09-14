using System.ComponentModel.DataAnnotations;
using Takerman.Publishing.Data.DTOs;

namespace Takerman.Publishing.Data.Entities
{
    public class PublicationVideo : PublicationVideoDto
    {
        public DateTime DatePublished { get; set; } = DateTime.Now;

        [Key]
        public int Id { get; set; }

        public bool IsArchived { get; set; }
    }
}