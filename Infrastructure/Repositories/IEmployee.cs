using ApplicationCore.EmployeeModel;
using Infrastructure.Data.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetCustomers();
        Task<ServiceResult<Employee>> GetCustomer(int id);
        Task<Response> PostCustomers(Employee customer);
        Task<Response> PutCustomers(int id, Employee customers);
        Task<Response> DeleteCustomers(int id);
    }
}
