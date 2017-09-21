using E_TransferWebApi.Models;
using E_TransferWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TransferWebApi.Services
{
    public interface IUserService
    {
        EmployeeDetails GetUserDetails(int id);
        RequestDetails GetUserByEmpcode(int code);
    }
    public class UserService : IUserService
    {
        IEmployeeDetailsRepo _emprepo;
        IRequestDetailsRepo _reqrepo;
        public UserService(IEmployeeDetailsRepo emprepo ,IRequestDetailsRepo reqrepo)
        {
            _emprepo = emprepo;
            _reqrepo = reqrepo;
        }
        public RequestDetails GetUserByEmpcode(int code)
        {
            return _reqrepo.GetRequestByEmpcode(code);
        }

        public EmployeeDetails GetUserDetails(int id)
        {
            return _emprepo.GetEmployeeById(id);
        }
    }
}
