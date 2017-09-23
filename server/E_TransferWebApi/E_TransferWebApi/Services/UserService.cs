using E_TransferWebApi.Models;
using E_TransferWebApi.Repository;

namespace E_TransferWebApi.Services
{
    public interface IUserService
    {
        EmployeeDetails GetUserDetails(int id);
        RequestDetails GetUserByEmpcode(int code);
    }
    public class UserService : IUserService
    {
        IEmployeeDetailsRepo _empRepo;
        IRequestDetailsRepo _reqRepo;
        public UserService(IEmployeeDetailsRepo empRepo, IRequestDetailsRepo reqRepo)
        {
            _empRepo = empRepo;
            _reqRepo = reqRepo;
        }

        //Method for getting Request Details for particular employee code
        public RequestDetails GetUserByEmpcode(int code)
        {
            return _reqRepo.GetRequestByEmpcode(code);
        }

        //Method for getting Employee details for particular Id
        public EmployeeDetails GetUserDetails(int id)
        {
            return _empRepo.GetEmployeeById(id);
        }
    }
}
