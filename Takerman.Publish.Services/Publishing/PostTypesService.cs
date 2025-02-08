using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Takerman.Publish.Data;
using Takerman.Publish.Data.Entities;
using Takerman.Publish.Services.Services.Abstraction;

namespace Takerman.Publish.Services.Services
{
    public class PostTypesService(DefaultContext _context) : IPostTypesService
    {
        public async Task<PostType> Create(PostType PostType)
        {
            var result = await _context.PostTypes.AddAsync(PostType);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<PostType> Delete(int id)
        {
            var result = _context.PostTypes.Remove(await Get(id));

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public Task<PostType> Get(int id)
        {
            return _context.PostTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<PostType>> GetAll()
        {
            return _context.PostTypes.ToListAsync();
        }

        public async Task<PostType> Update(PostType PostType)
        {
            var result = _context.PostTypes.Update(PostType);

            await _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}
