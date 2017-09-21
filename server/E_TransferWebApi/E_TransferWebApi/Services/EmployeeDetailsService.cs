using E_TransferWebApi.Models;
using E_TransferWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TransferWebApi.Services
{
    public interface IEmployeeDetailsService
    {
        string AddEmployee(EmployeeDetails employee);
        void EditEmployee(int id, EmployeeDetails employee);
        void DeleteEmployee(int id);
        List<EmployeeDetails> GetAllEmployee();
        EmployeeDetails GetEmployeeById(int id);
    }
    public class EmployeeDetailsService : IEmployeeDetailsService
    {
        IEmployeeDetailsRepo _repository;
        public EmployeeDetailsService(IEmployeeDetailsRepo repository)
        {
            _repository = repository;
        }
        public string AddEmployee(EmployeeDetails employee)
        {
            List<EmployeeDetails> employeechecklist = new List<EmployeeDetails>();
            employeechecklist = _repository.GetAllEmployee();
            foreach(EmployeeDetails emp in employeechecklist)
            {
                if(emp.EmployeeCode == employee.EmployeeCode)
                {
                    return "already exist";
                }
            }
            _repository.AddEmployee(employee);
            return "successful";
        }

        public void DeleteEmployee(int id)
        {
            _repository.DeleteEmployee(id);
        }

        public void EditEmployee(int id, EmployeeDetails employee)
        {
            _repository.EditEmployee(id, employee);
        }

        public List<EmployeeDetails> GetAllEmployee()
        {
            return _repository.GetAllEmployee();
        }

        public EmployeeDetails GetEmployeeById(int id)
        {
            return _repository.GetEmployeeById(id);
        }
    }
}
