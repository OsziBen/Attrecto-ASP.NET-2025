﻿using CourseController.Data;

namespace CourseController.Interfaces
{
    public interface IUserRepository
    {
        Task CreateAsync(User data);
        Task<bool> DeleteAsync(int id);
        Task<List<User>> GetAllAsync();
        Task<List<User>> GetAllAdultUsersAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> UpdateAsync(int id, User data);
    }
}