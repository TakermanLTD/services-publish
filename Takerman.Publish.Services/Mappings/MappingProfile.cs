using AutoMapper;
using Takerman.Publish.Data.Entities;
using Takerman.Publish.Services.Dtos;

namespace Takerman.Publish.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
            CreateMap<List<Post>, List<PostDto>>();
            CreateMap<List<PostDto>, List<Post>>();
        }
    }
}