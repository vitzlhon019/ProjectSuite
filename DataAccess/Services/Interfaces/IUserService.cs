using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetEmployeeDetailsAsync(int id);
        Task AddEmployeeAsync(UserDTO employeeDto);
        Task<IEnumerable<UserDTO>> GetAllEmployeesAsync();
        Task<bool> UpdateEmployeeAsync(int id, UserDTO updateEmployeeDTO);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
