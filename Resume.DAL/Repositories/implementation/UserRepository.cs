using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.Users;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.implementation;

public class UserRepository : IUserRepository
{
    #region Filds

    private readonly ResumeContext _resumeContext;

    #endregion

    #region Ctor

    public UserRepository(ResumeContext resumeContext)
    {
        _resumeContext = resumeContext;
    }

    #endregion
    public async Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _resumeContext.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<InsertUserResult> InsertAsync(User user)
    {
        try
        {
            await _resumeContext.Users.AddAsync(user);
            return InsertUserResult.Success;
        }
        catch (Exception)
        {
            return InsertUserResult.Error;
        }
    }

    public UpdateUserResult UpdateAsync(User user)
    {
        try
        {
            _resumeContext.Users.Update(user);
            return UpdateUserResult.Success;
        }
        catch (Exception)
        {
            return UpdateUserResult.Error;
        }
    }

    public async Task<IList<User>> GetAllAsync()
    {
        return await _resumeContext.Users.ToListAsync(); 
    }

    public async Task<FilterUserViewModel> SearchAsync(FilterUserViewModel searchModel)
    {
        var query = _resumeContext.Users.AsQueryable();

        if (!String.IsNullOrEmpty(searchModel.Username)) 
        {
            query = query.Where(u => u.Username.Contains(searchModel.Username));
        }

        if (!String.IsNullOrEmpty(searchModel.Phone))
        {
            query = query.Where(u => u.Phone.Contains(searchModel.Phone));
        }

        if (!String.IsNullOrEmpty(searchModel.Email))
        {
            query = query.Where(u => u.Email.Contains(searchModel.Email));
        }

        if (!String.IsNullOrEmpty(searchModel.Gender))
        {
            query = query.Where(u => u.Gender == searchModel.Gender);
        }
        await searchModel.Paging(query.Select(user => new InfoUserViewModel()
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Phone = user.Phone,
            Gender = user.Gender,
            DateOfBirth = user.DateOfBirth,
        }));

        return searchModel;
    }

    public async Task<bool> DuplicatedEmailAsync(int id, string email)
    {
        return await _resumeContext.Users
            .AnyAsync(user => user.Email == email && user.Id != id);
    }

    public async Task<bool> DuplicatedPhoneAsync(int id, string mobile)
    {
        return await _resumeContext.Users
            .AnyAsync(user => user.Phone == mobile && user.Id != id);
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await _resumeContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task SaveChangeAsync()
    {
        await _resumeContext.SaveChangesAsync();
    }
}
