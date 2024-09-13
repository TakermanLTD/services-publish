namespace Takerman.Publishing.Data.Entities
{
    public class PlatformLinkDto
    {
        public virtual int Id { get; set; }

        public Platform Platform { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;
    }
}