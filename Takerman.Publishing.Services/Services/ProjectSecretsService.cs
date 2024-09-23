using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Takerman.Publishing.Data;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Dtos;
using Takerman.Publishing.Services.Services.Abstraction;

namespace Takerman.Publishing.Services.Services
{
    public class ProjectSecretsService(ILogger<ProjectSecretsService> _logger, DefaultContext _context) : IProjectSecretsService
    {
        public Task<List<ProjectSecret>> Get(int projectId)
        {
            return _context.ProjectSecrets.Where(x => x.ProjectId == projectId).ToListAsync();
        }

        public Task<List<ProjectSecret>> Get(int projectId, int platformId)
        {
            return _context.ProjectSecrets.Where(x => x.ProjectId == projectId && x.PlatformId == platformId).ToListAsync();
        }

        public async Task<List<ProjectSecret>> Delete(ProjectSecretDto model)
        {
            var secrets = await Get(model.ProjectId, model.PlatformId);

            _context.ProjectSecrets.RemoveRange(secrets);

            await _context.SaveChangesAsync();

            return secrets;
        }

        /*
        public async Task<ProjectSecret> Update(ProjectSecretDto model)
        {
            var secrets = await Get(model.ProjectId, model.PlatformId);
            secrets ??= await Create(new ProjectPlatform()
            {
                PlatformId = model.PlatformId,
                ProjectId = model.ProjectId,
            });

            await _context.SaveChangesAsync();

            foreach (var secret in model.Secrets)
            {
                var existing = await _context.ProjectSecrets.FirstOrDefaultAsync(x => x.ProjectPlatformId == secrets.Id && x.PlatformSecretId == secret.Key);

                if (existing == null)
                {
                    await _context.ProjectSecrets.AddAsync(new ProjectSecret()
                    {
                        PlatformSecretId = secret.Key,
                        ProjectPlatformId = secrets.Id,
                        Value = secret.Value
                    });
                }
                else
                {
                    existing.Value = secret.Value;
                }
            }

            await _context.SaveChangesAsync();

            secrets = await Get(model.ProjectId, model.PlatformId);

            return secrets;
        }
        */
    }
}
