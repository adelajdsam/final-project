using employee.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace employee.Data.Models.Services
{
    public class EmployeesService
    {
        private AppDbContext _context;
        public EmployeesService(AppDbContext context)
        {
            _context = context;
        }

        public void AddEmployee(EmployeeVM employee)
        {
            var _employee = new Employee()
            {
                Name = employee.Name,
                Email = employee.Email,
                Position = employee.Position,
                Office = employee.Office,
                Phone_nr = employee.Phone_nr,
                Salary = employee.Salary
            };
            _context.Employees.Add(_employee);
            _context.SaveChanges();
        }

        public List<Employee> GetAllEmployees() => _context.Employees.ToList();

        public Employee GetEmployeeById(int employeeId) => _context.Employees.FirstOrDefault(n => n.Id == employeeId);

        public Employee UpdateEmployeeById(int employeeId, EmployeeVM employee)
        {
            var _employee = _context.Employees.FirstOrDefault(n => n.Id == employeeId);
            if (_employee != null)
            {
                _employee.Name = employee.Name;
                _employee.Email = employee.Email;
                _employee.Position = employee.Position;
                _employee.Office = employee.Office;
                _employee.Phone_nr = employee.Phone_nr;
                _employee.Salary = employee.Salary;

                _context.SaveChanges();
            }
            return _employee;
        }

        public void DeleteEmployeeById(int employeeId)
        {
            var _employee = _context.Employees.FirstOrDefault(n => n.Id == employeeId);
            if (_employee != null)
            {
                _context.Employees.Remove(_employee);
                _context.SaveChanges();
            }
        }
    }
}
