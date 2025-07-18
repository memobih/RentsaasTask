using Microsoft.AspNetCore.Mvc;
using RentsaasTask.Interfaces;
using RentsaasTask.Models;
using RentsaasTask.DataTransferObjects;

namespace RentsaasTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? search, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var (employees, totalCount) = await _employeeService.GetAllAsync(search, page, pageSize);

                return Ok(new
                {
                    totalCount,
                    page,
                    pageSize,
                    employees
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving employees. {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var employee = await _employeeService.GetByIdAsync(id);
                if (employee == null)
                    return NotFound();

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving employee. {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _employeeService.AddAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating employee. {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmployeeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _employeeService.UpdateAsync(id, dto);
                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating employee. {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _employeeService.DeleteAsync(id);
                if (!deleted)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting employee. {ex.Message}");
            }
        }
    }
}
