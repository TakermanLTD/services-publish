﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Dtos;

namespace Takerman.Publishing.Services.Services.Abstraction
{
    public interface IPlatformPostTypesService
    {
        Task<PlatformPostType> Create(int platformId, int postTypeId);

        Task<bool> Delete(int id);

        Task<PlatformPostType> Get(int id);

        Task<List<PlatformPostType>> GetAll(int platformID);

        Task<List<int>> Update(PlatformPostTypesDto PostTypes);
    }
}
