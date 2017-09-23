using E_TransferWebApi.Models;
using E_TransferWebApi.Repository;
using E_TransferWebApi.Services;
using Moq;
using Xunit;

namespace E_Transfer_Test_Cases
{
    public class UsererviceTest
    {
        [Fact]  //First Test Case
        public void Checking_The_TypeOf_GetUserByEmpcode_Of_When_Request_Is_Executed()
        {
            //ARRANGE
            int id = 1;
            var mockReqRepo = new Mock<IRequestDetailsRepo>();
            var mockEmpRepo = new Mock<IEmployeeDetailsRepo>();
            RequestDetails req = new RequestDetails();
            mockReqRepo.Setup(x => x.GetRequestByEmpcode(id)).Returns(req);
            var service = new UserService(mockEmpRepo.Object, mockReqRepo.Object);

            // Act
            var actionResult = service.GetUserByEmpcode(id);

            // Assert
            Assert.IsType<RequestDetails>(actionResult);
        }

        [Fact]  //Second Test Case
        public void Checking_The_TypeOf_GetUserByEmpcode_Is_Of_RequestDetails_Or_Not()
        {
            //ARRANGE
            int id = 1;
            var mockReqRepo = new Mock<IRequestDetailsRepo>();
            var mockEmpRepo = new Mock<IEmployeeDetailsRepo>();
            RequestDetails req = new RequestDetails();
            mockReqRepo.Setup(x => x.GetRequestByEmpcode(id)).Returns(req);
            var service = new UserService(mockEmpRepo.Object, mockReqRepo.Object);

            // Act
            var actionResult = service.GetUserByEmpcode(id);

            // Assert
            Assert.IsNotType<EmployeeDetails>(actionResult);
        }

        [Fact]  //Third Test Case
        public void Checking_The_TypeOf_GetUserDetails_Consists_of_RequestDetails()
        {
            //ARRANGE
            int id = 1;
            var mockReqRepo = new Mock<IRequestDetailsRepo>();
            var mockEmpRepo = new Mock<IEmployeeDetailsRepo>();
            EmployeeDetails emp = new EmployeeDetails();
            mockEmpRepo.Setup(x => x.GetEmployeeById(id)).Returns(emp);
            var service = new UserService(mockEmpRepo.Object, mockReqRepo.Object);

            // Act
            var actionResult = service.GetUserDetails(id);

            // Assert
            Assert.IsNotType<RequestDetails>(actionResult);
        }

        [Fact]  //Fourth Test Case
        public void Checking_The_TypeOf_GetUserDetails_Of_When_Request_Is_Executed()
        {
            //ARRANGE
            int id = 1;
            var mockReqRepo = new Mock<IRequestDetailsRepo>();
            var mockEmpRepo = new Mock<IEmployeeDetailsRepo>();
            EmployeeDetails emp = new EmployeeDetails();
            mockEmpRepo.Setup(x => x.GetEmployeeById(id)).Returns(emp);
            var service = new UserService(mockEmpRepo.Object, mockReqRepo.Object);

            // Act
            var actionResult = service.GetUserDetails(id);

            // Assert
            Assert.IsType<EmployeeDetails>(actionResult);
        }
        [Fact]  ////Fifth Test Case
        public void Is_GetUserDetails_Is_Getting_Any_Details_Or_Not()
        {
            //ARRANGE
            int id = 1;
            var mockReqRepo = new Mock<IRequestDetailsRepo>();
            var mockEmpRepo = new Mock<IEmployeeDetailsRepo>();
            EmployeeDetails emp = new EmployeeDetails();
            mockEmpRepo.Setup(x => x.GetEmployeeById(id)).Returns(emp);
            var service = new UserService(mockEmpRepo.Object, mockReqRepo.Object);

            // Act
            var actionResult = service.GetUserDetails(id);

            // Assert
            Assert.NotNull(actionResult);
        }
        [Fact]  //Sixth Test Case
        public void Is_GetUserByEmpcode_Is_Getting_Any_Details_Or_Not()
        {
            //ARRANGE
            int id = 1;
            var mockReqRepo = new Mock<IRequestDetailsRepo>();
            var mockEmpRepo = new Mock<IEmployeeDetailsRepo>();
            RequestDetails req = new RequestDetails();
            mockReqRepo.Setup(x => x.GetRequestByEmpcode(id)).Returns(req);
            var service = new UserService(mockEmpRepo.Object, mockReqRepo.Object);

            // Act
            var actionResult = service.GetUserByEmpcode(id);

            // Assert
            Assert.NotNull(actionResult);
        }
    }
}

