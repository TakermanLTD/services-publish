using Microsoft.Extensions.Logging;
using System.Data.Entity;
using Takerman.Publishing.Data;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Services.Abstraction;

namespace Takerman.Publishing.Services.Services
{
    public class PostTypeService(DefaultContext _context) : IPostTypeService
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

            return result.Entity;
        }

        public Task<PostType> Get(int id)
        {
            return _context.PostTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<PostType>> GetAll()
        {
            return await _context.PostTypes.ToListAsync();
        }

        public async Task<PostType> Update(PostType PostType)
        {
            var result = _context.PostTypes.Update(PostType);

            await _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}
