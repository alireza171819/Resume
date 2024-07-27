using Resume.Bussines.Security;
using Resume.Bussines.Services.Interface;
using Resume.DAL.Models.Users;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.Account;
using Resume.DAL.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bussines.Services.implementation
{
    public class UserService : IUserService
    {
        #region Fildes
        private readonly IUserRepository _userRepository;
        #endregion

        #region Ctor
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion
                    
        #region Methods

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<UpdateUserViewModel> GetForEditByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                return null;


            return new UpdateUserViewModel()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                Username = user.Username,
                Phone = user.Phone,
                Gender = user.Gender,
                DateOfBirth = user.DateOfBirth,

            };
        }
        public Task<IList<ListUserModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<InsertUserResult> InsertAsync(InsertUserViewModel model)
        {
            try
            {
                var user = new User();
                user.Username = model.Username;   
                user.Email = model.Email;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Phone = model.Phone;
                user.CreatedOnUtc = DateTime.UtcNow;
                user.DateOfBirth = model.DateOfBirth;
                user.Active = true;
                user.Deleted = false;  
                user.Gender = model.Gender;
                user.Password = model.Password.Trim().EncodePasswordMd5();
                await _userRepository.InsertAsync(user);
                await _userRepository.SaveChangeAsync();
                return InsertUserResult.Success;
            }
            catch (Exception)
            {
                return InsertUserResult.Error;
            }
        }

        public async Task<FilterUserViewModel> SearchAsync(FilterUserViewModel searchModel)
        {
            var users = await _userRepository.SearchAsync(searchModel);
            return users;
        }

        public async Task<UpdateUserResult> UpdateAsync(UpdateUserViewModel updateModel)
        {
            var user = _userRepository.GetByIdAsync(updateModel.Id).Result;
            if (user == null)
            {
                return UpdateUserResult.UserNotFound;
            }
            if (await _userRepository.DuplicatedEmailAsync(user.Id, updateModel.Email.ToLower().Trim()))
            {
                return UpdateUserResult.EmailDuplicated;
            }
            if (await _userRepository.DuplicatedPhoneAsync(user.Id, updateModel.Phone))
            {
                return UpdateUserResult.PhoneDuplicated;
            }
            
            user.FirstName = updateModel.FirstName;
            user.LastName = updateModel.LastName;
            user.Email = updateModel.Email;
            user.Phone = updateModel.Phone;
            user.DateOfBirth = updateModel.DateOfBirth;
            user.Gender = updateModel.Gender;

            try
            {
                _userRepository.UpdateAsync(user);
                await _userRepository.SaveChangeAsync();
                return UpdateUserResult.Success;
            }
            catch (Exception)
            {
                return UpdateUserResult.Error;
            }
        }

        public async Task<LoginResult> LoginAsync(LoginViewModel loginModel) 
        {
            loginModel.Username = loginModel.Username.Trim().ToLower();
            var user = await _userRepository.GetByEmailAsync(loginModel.Username);
            if (user == null)
            {
                return LoginResult.UserNotFound;
            }
            string hashPassword = loginModel.Password.Trim().EncodePasswordMd5();
            if (user.Password != hashPassword)
            {
                return LoginResult.PasswordError;
            }

            return LoginResult.Success;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            email = email.Trim().ToLower();
            return await _userRepository.GetByEmailAsync(email);
        }

        public async Task<InfoUserViewModel> GetInfoAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            return new InfoUserViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                Gender = user.Gender,
                Phone = user.Phone,
                Username = user.Username
            };
        }
        #endregion
    }
}
