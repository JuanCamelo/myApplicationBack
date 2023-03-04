using ApplicationDomian.Models;
using ApplicationDomian.Repository.Contact;
using ApplicationServices.DTOs.Models;
using ApplicationServices.DTOs.ViewModels;
using ApplicationServices.Services.Contract;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ApplicationServices.Services
{
    public class UserApplicationServices : IUserApplicationServices
    {
        private readonly IApplicationDomainRepository<User> _userRepository;
        private readonly IApplicationDomainRepository<Position> _positionRepository;
        private readonly IApplicationDomainRepository<TypeContact> _typeContactRepository;
        private readonly IMapper _mapper;

        public UserApplicationServices(IApplicationDomainRepository<User> userRepository, IMapper mapper,
            IApplicationDomainRepository<Position> positionRepository, IApplicationDomainRepository<TypeContact> typeContactRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _positionRepository = positionRepository;
            _typeContactRepository = typeContactRepository;
        }

        public async Task<UserViewModel> GetByIdUserAsync(string idUser)
        {
            try
            {
                if (string.IsNullOrEmpty(idUser))
                    throw new ArgumentNullException(nameof(idUser));

                if (Guid.TryParse(idUser, out var newGuid))
                    throw new Exception("format invalid");

                User? user = await _userRepository.GetById(newGuid);
                return _mapper.Map<UserViewModel>(user);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<UserViewModel>> GetUserAsync(UserFilters filters)
        {
            try
            {
                IEnumerable<User> users = await _userRepository.GetAll<User>(includes: source => source.Include(c => c.IdTypeContactNavigation)
                                                                                                       .Include(c => c.IdPositionNavigation));
                return _mapper.Map<IEnumerable<UserViewModel>>(users);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<string> PostUserAsync(UserModel userModel)
        {
            try
            {
                User user = _mapper.Map<User>(userModel);
                user.IdPosition = await ExistPosition(userModel.Position);
                user.IdTypeContact = await ExistTypeContact(userModel.TypeContact);

                await _userRepository.Post(user);
                await _userRepository.Save();

                return "Succesfull!";
            }
            catch (Exception)
            {

                throw;
            }
        }
        private async Task<Guid> ExistTypeContact(string type)
        {
            var ifTypeContact = await _typeContactRepository.GetAll<Position>(whereCondition: c => c.Type.Trim().ToUpper()
                                                                                                       .Equals(type.Trim().ToUpper()));
            if (ifTypeContact != null)
                return (await CreateTypeContact(type)).Id;

            return ifTypeContact.FirstOrDefault().Id;
        }
        private async Task<TypeContact> CreateTypeContact(string type)
        {
            try
            {
                TypeContact addTypeContact = _mapper.Map<TypeContact>(type);
                await _typeContactRepository.Post(addTypeContact);
                return addTypeContact;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private async Task<Guid> ExistPosition(string position)
        {
            var ifExistPosition = await _positionRepository.GetAll<Position>(whereCondition: c => c.Name.Trim().ToUpper()
                                                                                                       .Equals(position.Trim().ToUpper()));
            if (ifExistPosition != null)
                return (await CreatePosition(position)).Id;

            return ifExistPosition.FirstOrDefault().Id;
        }
        private async Task<Position> CreatePosition(string position)
        {
            try
            {
                Position addPosition = _mapper.Map<Position>(position);
                await _positionRepository.Post(addPosition);
                return addPosition;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
