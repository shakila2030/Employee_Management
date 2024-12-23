using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Get all employees.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            return Ok(employees);
        }

        /// <summary>
        /// Get an employee by ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        /// <summary>
        /// Create a new employee.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeRepository.AddEmployeeAsync(employee);
                return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Update an existing employee.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest("Employee ID mismatch.");
            }

            if (ModelState.IsValid)
            {
                await _employeeRepository.UpdateEmployeeAsync(employee);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Delete an employee by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }
}
