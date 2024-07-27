using Resume.DAL.Models.Users;
using Resume.DAL.ViewModels.Account;
using Resume.DAL.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bussines.Services.Interface
{
    public interface IUserService
    {
        Task<InsertUserResult> InsertAsync(InsertUserViewModel model);

        Task<UpdateUserResult> UpdateAsync(UpdateUserViewModel updateModel);

        Task<bool> DeleteAsync(int id);

        Task<UpdateUserViewModel> GetForEditByIdAsync(int id);

        Task<User> GetByEmailAsync(string email);

        Task<FilterUserViewModel> SearchAsync(FilterUserViewModel searchModel);

        Task<LoginResult> LoginAsync(LoginViewModel loginModel);

        Task<InfoUserViewModel> GetInfoAsync(int id);

    }
}
