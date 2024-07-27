using Resume.DAL.Models.Users;
using Resume.DAL.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<InsertUserResult> InsertAsync(User user);

        UpdateUserResult UpdateAsync(User user);

        Task<bool> DeleteAsync(int id);

        Task<User> GetByIdAsync(int id);

        Task<bool> DuplicatedEmailAsync(int id, string email);

        Task<bool> DuplicatedPhoneAsync(int id, string mobile);

        Task<User> GetByEmailAsync(string email);

        Task<FilterUserViewModel> SearchAsync(FilterUserViewModel searchModel);

        Task SaveChangeAsync();
    }
}
