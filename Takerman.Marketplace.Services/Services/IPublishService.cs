using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takerman.Marketplace.Services.Dtos;

namespace Takerman.Marketplace.Services.Services
{
    public interface IPublishService
    {
        Task<bool> PublishAsync(PostDto model);
    }
}
