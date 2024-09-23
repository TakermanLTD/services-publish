using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Takerman.Publishing.Data;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Dtos;
using Takerman.Publishing.Services.Services.Abstraction;

namespace Takerman.Publishing.Services.Services
{
    public class ProjectPlatformsService(DefaultContext _context) : IProjectPlatformsService
    {
        public Task<ProjectPlatform> Get(int id)
        {
            return _context.ProjectPlatforms.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProjectPlatform> Get(int projectId, int platformId, int postTypeId)
        {
            return await _context.ProjectPlatforms.FirstOrDefaultAsync(x => x.ProjectId == projectId && x.PlatformId == platformId && x.PostTypeId == postTypeId);
        }

        public Task<List<ProjectPlatform>> GetAll()
        {
            return _context.ProjectPlatforms.ToListAsync();
        }

        public async Task<List<ProjectPlatform>> GetAll(int projectId, int postTypeId)
        {
            var result = await _context.ProjectPlatforms
                .Where(x => x.ProjectId == projectId && x.PostTypeId == postTypeId)
                .ToListAsync();

            return result;
        }

        public async Task<ProjectPlatform> Create(ProjectPlatform model)
        {
            var result = await _context.ProjectPlatforms.AddAsync(model);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<ProjectPlatform> Delete(ProjectPlatformSecretDto model)
        {
            var entity = await Get(model.ProjectId, model.PlatformId, model.PostTypeId);

            if (entity != null)
            {
                var secrets = _context.ProjectPlatformSecrets.Where(x => x.ProjectPlatformId == entity.Id);

                _context.ProjectPlatformSecrets.RemoveRange(secrets);

                await _context.SaveChangesAsync();
            }

            var result = _context.ProjectPlatforms.Remove(entity);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<ProjectPlatform> Update(ProjectPlatformSecretDto model)
        {
            var projectPlatform = await Get(model.ProjectId, model.PlatformId, model.PostTypeId);
            projectPlatform ??= await Create(new ProjectPlatform()
            {
                PlatformId = model.PlatformId,
                PostTypeId = model.PostTypeId,
                ProjectId = model.ProjectId,
            });

            await _context.SaveChangesAsync();

            foreach (var secret in model.Secrets)
            {
                var existing = await _context.ProjectPlatformSecrets.FirstOrDefaultAsync(x => x.ProjectPlatformId == projectPlatform.Id && x.PlatformSecretId == secret.Key);

                if (existing == null)
                {
                    await _context.ProjectPlatformSecrets.AddAsync(new ProjectPlatformSecret()
                    {
                        PlatformSecretId = secret.Key,
                        ProjectPlatformId = projectPlatform.Id,
                        Value = secret.Value
                    });
                }
                else
                {
                    existing.Value = secret.Value;
                }
            }

            await _context.SaveChangesAsync();

            projectPlatform = await Get(model.ProjectId, model.PlatformId, model.PostTypeId);

            return projectPlatform;
        }
    }
}