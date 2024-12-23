﻿using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartmentsAsync(); 
        Task<Department> GetDepartmentByIdAsync(int id);     
        Task AddDepartmentAsync(Department department);        
        Task UpdateDepartmentAsync(Department department);      
        Task DeleteDepartmentAsync(int id);
    }
}
