using HiwayGo_API.Entity;
using HiwayGo_API.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiwayGo_API.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepo;
        private readonly IUserRoleRepository _roleRepo;
        private readonly IJwtService _jwtService;

        public UserLogic(IUserRepository userRepo, IUserRoleRepository roleRepo, IJwtService jwtService)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;
            _jwtService = jwtService;
        }

        public async Task<User> CreateAsync(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            var role = await _roleRepo.GetByIdAsync(user.UserRoleId);
            if (role == null) throw new InvalidOperationException("User role not found.");

            // potential place for further validation (unique NIC/email, password hashing, etc.)
            return await _userRepo.InsertAsync(user);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _userRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepo.SelectAllAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _userRepo.SelectByIdAsync(id);
        }

        public async Task<User?> GetByNicAsync(string nic)
        {
            if (string.IsNullOrWhiteSpace(nic)) return null;
            return await _userRepo.GetByNicAsync(nic);
        }

        public async Task UpdateAsync(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            var existing = await _userRepo.SelectByIdAsync(user.Id);
            if (existing == null) throw new InvalidOperationException("User not found.");

            var role = await _roleRepo.GetByIdAsync(user.UserRoleId);
            if (role == null) throw new InvalidOperationException("User role not found.");

            await _userRepo.UpdateAsync(user);
        }

        // Reset password implementation (simple replace). Consider hashing in production.
        public async Task<bool> ResetPasswordAsync(string email, string newPassword)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(newPassword))
            {
                return false;
            }

            var user = await _userRepo.GetByEmailAsync(email);
            if (user == null) return false;

            user.Password = newPassword;
            await _userRepo.UpdateAsync(user);
            return true;
        }

        // Very simple authentication: compares plain text password. Replace with hashing in production.
        public async Task<string?> LoginAsync(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return null;

            var user = await _userRepo.GetByEmailAsync(email);
            if (user == null) return null;

            if (user.Password != password) return null;

            var token = _jwtService.GenerateToken(user);
            return token;
        }
    }
}