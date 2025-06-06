using Common.DTO;
using DataAccess.DBContexts.ProjectSuiteDB.Models;
using DataAccess.Repositories.ProjectSuite.Interfaces;
using DataAccess.Services.Interfaces;
using DataAccess.UnitOfWorks._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBaseUnitOfWork _unitOfWork;
        public UserService(IUserRepository userRepository,IBaseUnitOfWork baseUnitOfWork) 
        {
            _userRepository = userRepository;
            _unitOfWork = baseUnitOfWork;
        }
        public async Task<UserDTO> GetEmployeeDetailsAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                return null;

            return new UserDTO
            {
                UserId = user.UserId,
                EmployeeName = user.EmployeeName,
                Email = user.Email
            };
        }
        public async Task AddEmployeeAsync(UserDTO userDTO)
        {
            var user = new User
            {
                EmployeeName = userDTO.EmployeeName,
                Email = userDTO.Email
            };

            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<IEnumerable<UserDTO>> GetAllEmployeesAsync()
        {
            var employees = await _userRepository.GetAllAsync();

            return employees.Select(e => new UserDTO
            {
                UserId = e.UserId,
                EmployeeName = e.EmployeeName,
                Email = e.Email,
            });
        }
        public async Task<bool> UpdateEmployeeAsync(int id, UserDTO updateUserDTO)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return false; // Not found
            }

            user.EmployeeName = updateUserDTO.EmployeeName;
            user.Email = updateUserDTO.Email;

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _userRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return false; // Not found
            }

            _userRepository.Remove(employee);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

    }
}
