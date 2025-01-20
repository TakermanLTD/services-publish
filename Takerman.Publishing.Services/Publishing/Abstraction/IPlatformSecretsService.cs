using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takerman.Publishing.Data.Entities;

namespace Takerman.Publishing.Services.Services.Abstraction
{
    public interface IPlatformSecretsService
    {
        Task<PlatformSecret> Create(PlatformSecret model);

        Task<PlatformSecret> Delete(int id);

        Task<PlatformSecret> Get(int id);

        Task<List<PlatformSecret>> GetAll();

        Task<List<PlatformSecret>> GetAll(int projectPlatformId);

        Task<PlatformSecret> Update(PlatformSecret ProjectPlatformRecord);
    }
}
