﻿using AutoMapper;
using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Data.Entities;

namespace Takerman.Publishing.Common
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<PlatformLink, PlatformLinkDto>();
            CreateMap<ProjectPlatform, ProjectPlatformDto>();
            CreateMap<PublicationBlogpost, PublicationBlogpostDto>();
            CreateMap<PublicationPicture, PublicationPictureDto>();
            CreateMap<PublicationSelling, PublicationSellingDto>();
            CreateMap<PublicationShort, PublicationShortDto>();
            CreateMap<PublicationTweet, PublicationTweetDto>();
            CreateMap<PublicationVideo, PublicationVideoDto>();

            CreateMap<PlatformLinkDto, PlatformLink>();
            CreateMap<ProjectPlatformDto, ProjectPlatform>();
            CreateMap<PublicationBlogpostDto, PublicationBlogpost>();
            CreateMap<PublicationPictureDto, PublicationPicture>();
            CreateMap<PublicationSellingDto, PublicationSelling>();
            CreateMap<PublicationShortDto, PublicationShort>();
            CreateMap<PublicationTweetDto, PublicationTweet>();
            CreateMap<PublicationVideoDto, PublicationVideo>();

            AllowNullCollections = true;
            AddGlobalIgnore("Item");
        }
    }
}