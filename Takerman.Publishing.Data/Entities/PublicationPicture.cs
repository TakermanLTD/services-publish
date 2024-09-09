using System.ComponentModel.DataAnnotations;
using Takerman.Publishing.Data.DTOs;

namespace Takerman.Publishing.Data.Entities
{
    public class PublicationPicture : PublicationPictureDto
    {
        [Key]
        public int Id { get; set; }

        public DateTime DatePublished { get; set; } = DateTime.Now;

        public bool IsArchived { get; set; }
    }
}