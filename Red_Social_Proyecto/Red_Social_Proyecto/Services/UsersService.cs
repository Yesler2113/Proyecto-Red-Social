using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Red_Social_Proyecto.Database;
using Red_Social_Proyecto.Dtos;
using Red_Social_Proyecto.Dtos.Task;
using Red_Social_Proyecto.Dtos.ValidationsDto;
using Red_Social_Proyecto.Entities;
using Red_Social_Proyecto.Services.Interfaces;

namespace Red_Social_Proyecto.Services
{
    public class UsersService : IUsersService
    {
        private readonly TodoListDBContext _context;
        private readonly IMapper _mapper;

        public UsersService(TodoListDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<UsersDto>> CreateUserAsync(UsersCreateDto model)
        {
            var usersEntity = _mapper.Map<UsersEntity>(model);

            usersEntity.RegistrationDate = DateTime.UtcNow;

            _context.Users.Add(usersEntity);
            await _context.SaveChangesAsync();

            var usersDto = _mapper.Map<UsersDto>(usersEntity);

            return new ResponseDto<UsersDto>
            {
                Status = true,
                StatusCode = 201,
                Message = "Usuario Creado Correctamente",
                Data = usersDto

            };
        }


    }

    //public class UsersService : IUsersService
    //{
    //    private readonly TodoListDBContext _context;
    //    private readonly IMapper _mapper;
    //    private readonly UserManager<UsersEntity> _userManager;  // Cambio aquí

    //    public UsersService(TodoListDBContext context, IMapper mapper, UserManager<UsersEntity> userManager)
    //    {
    //        _context = context;
    //        _mapper = mapper;
    //        _userManager = userManager;
    //    }


    //    public async Task<ResponseDto<UsersDto>> CreateUserAsync(UsersCreateDto model)
    //    {
    //        var user = new UsersEntity { UserName = model.UserName, Email = model.Email, RegistrationDate = DateTime.UtcNow }; // Cambio aquí para instanciar UsersEntity
    //        var result = await _userManager.CreateAsync(user, model.Password);

    //        if (result.Succeeded)
    //        {
    //            var usersEntity = _mapper.Map<UsersEntity>(model);

    //            var usersDto = _mapper.Map<UsersDto>(user); // Cambio aquí para usar el usuario ya creado y no duplicar la información

    //            return new ResponseDto<UsersDto>
    //            {
    //                Status = true,
    //                StatusCode = 201,
    //                Message = "Usuario Creado Correctamente",
    //                Data = usersDto
    //            };
    //        }
    //        else
    //        {
    //            return new ResponseDto<UsersDto>
    //            {
    //                Status = false,
    //                StatusCode = 400,
    //                Message = String.Join("; ", result.Errors.Select(e => e.Description)),
    //                Data = null
    //            };
    //        }
    //    }


}





