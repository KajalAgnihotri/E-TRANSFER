using E_TransferWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TransferWebApi.Repository
{
    public interface IEmployeeDetailsRepo
    {
        void AddEmployee(EmployeeDetails employee);
        void EditEmployee(int id, EmployeeDetails employee);
        void DeleteEmployee(int id);
        List<EmployeeDetails> GetAllEmployee();
        EmployeeDetails GetEmployeeById(int id);
    }
    public class EmployeeDetailsRepo : IEmployeeDetailsRepo
    {
        ETransferDbContext _context;
        public EmployeeDetailsRepo(ETransferDbContext context)
        {
            _context = context;
        }
        public void AddEmployee(EmployeeDetails employee)
        {
            _context.EmployeeInformation.Add(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            EmployeeDetails employee = _context.EmployeeInformation.FirstOrDefault(e => e.EmployeeCode == id);
            _context.EmployeeInformation.Remove(employee);
            _context.SaveChanges();
        }

        public void EditEmployee(int id, EmployeeDetails employee)
        {
            EmployeeDetails currentemployee = _context.EmployeeInformation.FirstOrDefault(e => e.EmployeeCode == id);
            _context.SaveChanges();

        }

        public List<EmployeeDetails> GetAllEmployee()
        {
            return _context.EmployeeInformation.ToList();
        }

        public EmployeeDetails GetEmployeeById(int id)
        {
            EmployeeDetails employee = _context.EmployeeInformation.FirstOrDefault(e => e.EmployeeCode == id);
            return employee;
        }
    }
}
