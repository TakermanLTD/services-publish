using AutoMapper;

namespace Takerman.Publishing.Common
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            // CreateMap<PlatformLink, PlatformLinkDto>();
            // CreateMap<PlatformLinkDto, PlatformLink>();
            AllowNullCollections = true;
            AddGlobalIgnore("Item");
        }
    }
}