using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Red_Social_Proyecto.Database;
using Red_Social_Proyecto.Dtos;
using Red_Social_Proyecto.Dtos.Task;
using Red_Social_Proyecto.Dtos.ValidationsDto;
using Red_Social_Proyecto.Entities;
using Red_Social_Proyecto.Services.Interfaces;

namespace Red_Social_Proyecto.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly TodoListDBContext _context;
        private readonly IMapper _mapper;

        public PublicationService(TodoListDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<PublicationDto>> CreatePublicationAsync(PublicationCreateDto model)
        {
            var publicationEntity = _mapper.Map<PublicationEntity>(model);

            publicationEntity.PublicationDate = DateTime.UtcNow; 

            _context.Publications.Add(publicationEntity);
            await _context.SaveChangesAsync();

            var publicationDto = _mapper.Map<PublicationDto>(publicationEntity);

            return new ResponseDto<PublicationDto>
            {
                Status = true,
                StatusCode = 201,
                Message = "Publicación creada correctamente",
                Data = publicationDto
            };
        }

        public async Task<List<PublicationDto>> GetPublicationsByUserAsync(Guid userId)
        {
            var publications = await _context.Publications
                .Where(p => p.UserId == userId.ToString())
                .ToListAsync();

            return _mapper.Map<List<PublicationDto>>(publications);
        }

        public async Task<ResponseDto<bool>> DeletePublicationAsync(Guid publicationId)
        {
            var publication = await _context.Publications.FindAsync(publicationId);
            if (publication == null)
            {
                return new ResponseDto<bool>
                {
                    Status = false,
                    StatusCode = 404,
                    Message = "Publicación no encontrada",
                    Data = false
                };
            }

            _context.Publications.Remove(publication);
            await _context.SaveChangesAsync();

            return new ResponseDto<bool>
            {
                Status = true,
                StatusCode = 200,
                Message = "Publicación eliminada correctamente",
                Data = true
            };
        }

    }
}
