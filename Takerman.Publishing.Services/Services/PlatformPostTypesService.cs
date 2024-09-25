using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Takerman.Publishing.Data;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Dtos;
using Takerman.Publishing.Services.Services.Abstraction;

namespace Takerman.Publishing.Services.Services
{
    public class PlatformPostTypesService(ILogger<PlatformPostTypesService> _logger, DefaultContext _context) : IPlatformPostTypesService
    {
        public async Task<PlatformPostType> Create(int platformId, int postTypeId)
        {
            var newPlatformPostType = new PlatformPostType()
            {
                PlatformId = platformId,
                PostTypeId = postTypeId
            };

            var result = await _context.PlatformPostTypes.AddAsync(newPlatformPostType);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.PlatformPostTypes.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                _logger.LogError("There is no such platform post type. Exception when deleting platform post type.");

                return false;
            }

            _context.PlatformPostTypes.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<PlatformPostType> Get(int id)
        {
            return await _context.PlatformPostTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PlatformPostType>> GetAll(int platformID)
        {
            var result = await _context.PlatformPostTypes
                .Where(x => x.PlatformId == platformID)
                .OrderBy(x => x.Id)
                .ToListAsync();

            return result;
        }

        public async Task<List<Platform>> GetAvailable(int projectId, int postTypeId)
        {
            var platforms = await _context.PlatformPostTypes.Where(x=>x.PostTypeId == postTypeId).ToListAsync();
            
            var secrets = await _context.ProjectSecrets
                .Where(x => x.ProjectId == projectId && platforms.Select(y => y.Id).Contains(x.PlatformId))
                .Select(x=>x.PlatformId).ToListAsync();

            var result = await _context.Platforms.Where(x=>secrets.Contains(x.Id)).ToListAsync();
            
            return result;
        }

        public async Task<List<int>> Update(PlatformPostTypesDto model)
        {
            var postTypes = await _context.PostTypes.ToListAsync();

            var platformPostTypes = await _context.PlatformPostTypes.Where(x => x.PlatformId == model.PlatformId).ToListAsync();

            foreach (var postType in postTypes)
            {
                var existing = await _context.PlatformPostTypes.FirstOrDefaultAsync(x => x.PlatformId == model.PlatformId && x.PostTypeId == postType.Id);

                if (existing != null && !model.PostTypes.Contains(postType.Id))
                    _context.PlatformPostTypes.Remove(existing);
                else if (existing == null && model.PostTypes.Contains(postType.Id))
                    _context.PlatformPostTypes.Add(new PlatformPostType() { PlatformId = model.PlatformId, PostTypeId = postType.Id });
            }
            await _context.SaveChangesAsync();

            var result = await _context.PlatformPostTypes.Where(x => x.PlatformId == model.PlatformId).Select(x => x.PostTypeId).ToListAsync();

            return result;
        }
    }
}