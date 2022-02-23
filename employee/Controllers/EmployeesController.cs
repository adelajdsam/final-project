using employee.Data.Models.Services;
using employee.Data.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public EmployeesService _employeesService;

        public EmployeesController(EmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        [HttpGet("get-all-employees")]
        public IActionResult GetAllBooks()
        {
            var allEmployees = _employeesService.GetAllEmployees();
            return Ok(allEmployees);
        }

        [HttpGet("get_employee_by_id/{id}")]
        public IActionResult GetAllBooks(int id)
        {
            var employee = _employeesService.GetEmployeeById(id);
            return Ok(employee);
        }

        [HttpPost("add-employee")]
        public IActionResult AddEmployee([FromBody]EmployeeVM empolyee)
        {
            _employeesService.AddEmployee(empolyee);
            return Ok();
        }

        [HttpPut("update-employee-by-id/{id}")]
        public IActionResult UpdateEmployeeById(int id, [FromBody] EmployeeVM employee)
        {
            var updatedEmployee = _employeesService.UpdateEmployeeById(id, employee);
            return Ok(updatedEmployee);
        }

        [HttpDelete("delete-employee-by-id/{id}")]
        public IActionResult DeleteEmployeeById(int id)
        {
            _employeesService.DeleteEmployeeById(id);
            return Ok();
        }
    }
}
