using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Takerman.Publishing.Data;
using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Abstraction;

namespace Takerman.Publishing.Services
{
    public class PictureService(DefaultContext _context, IMapper _mapper) : IPictureService
    {
        public async Task<PublicationPictureDto> Create(PublicationPictureDto model)
        {
            var entity = _mapper.Map<PublicationPicture>(model);
            await _context.PublicationPictures.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.PublicationPictures.FirstOrDefaultAsync(x => x.Id == id);
            _context.PublicationPictures.Remove(entity);
            return true;
        }

        public async Task<PublicationPictureDto> Get(int id)
        {
            return await _context.PublicationPictures.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PublicationPictureDto>> GetAll(Project project)
        {
            return await _context.PublicationPictures
                .Where(x => x.ProjectId == (int)project)
                .OrderBy(x => x.Id)
                .Select(x => _mapper.Map<PublicationPictureDto>(x))
                .ToListAsync();
        }

        public async Task<List<PublicationPictureDto>> Publish(PublicationPictureDto publication)
        {
            var result = await Create(publication);
            return [result];
        }

        public async Task<PublicationPictureDto> Update(PublicationPictureDto publication)
        {
            var result = _context.PublicationPictures.Update((PublicationPicture)publication);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}