using Common.DTO;
using DataAccess.Services.Interfaces;
using DataAccess.UnitOfWorks._Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBaseUnitOfWork _baseUnitOfWork;
        private readonly IUserService _userService;
        public UserController(IUserService userService, IBaseUnitOfWork baseUnitOfWork) {
            _baseUnitOfWork = baseUnitOfWork;
            _userService = userService;
        }
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {

            var employeeDTOs = await _userService.GetAllEmployeesAsync();

            return Ok(employeeDTOs);
        }
        [HttpPost]
        [Route("AddUser")]
        public async Task<ActionResult> AddUser([FromBody] UserDTO employeeDto)
        {
            if (employeeDto == null)
                return BadRequest("Invalid User data.");

            await _userService.AddEmployeeAsync(employeeDto);

            return Ok();
        }

        [HttpGet]
        [Route("GetUser/{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            var userDto = await _userService.GetEmployeeDetailsAsync(id);

            if (userDto == null)
                return NotFound();

            return Ok(userDto);
        }

        [HttpPut]
        [Route("UpdateUser/{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] UserDTO updateEmployeeDTO)
        {
            if (updateEmployeeDTO == null)
            {
                return BadRequest("User data is required.");
            }

            var updated = await _userService.UpdateEmployeeAsync(id, updateEmployeeDTO);

            if (!updated)
            {
                return NotFound($"User with ID {id} not found.");
            }

            return Ok();
        }

        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var deleted = await _userService.DeleteEmployeeAsync(id);

            if (!deleted)
            {
                return NotFound($"User with ID {id} not found.");
            }

            return NoContent();
        }
    }
}
