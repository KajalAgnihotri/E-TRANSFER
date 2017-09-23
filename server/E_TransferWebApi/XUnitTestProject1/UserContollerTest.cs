using E_TransferWebApi.Controllers;
using E_TransferWebApi.Models;
using E_TransferWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace UserTest
{
     public class UserContollerTest
    {
        [Fact]

        public void  UserControllerShouldReturnBadRequestStatusForEmpDetails()
        {
           //Arrange
            int id = 50043965;
            var moqService = new Mock<IUserService>();
            EmployeeDetails empDetail = new EmployeeDetails();
            empDetail = null;
           moqService.Setup(x => x.GetUserDetails(345)).Returns(empDetail);
            UserController obj = new UserController(moqService.Object);

            //Act
            IActionResult action = obj.GetRequest(id);
            var action1 = action as StatusCodeResult;

            //Assert
            Assert.Equal(400,action1.StatusCode);
        }

        [Fact]

        public void UserControllerShouldReturnNoContentStatusForEmpDetails()
        {
            //Arrange
            int id = 50042677;
            EmployeeDetails empDetail=new EmployeeDetails();
            empDetail.EmployeeCode = 123;
            var moqService = new Mock<IUserService>();
            moqService.Setup(x=>x.GetUserDetails(7)).Returns(empDetail);
            UserController obj = new UserController(moqService.Object);

            //Act
            IActionResult action = obj.GetEmployee(id);
            var result = action as StatusCodeResult;

            //Assert
            Assert.NotEqual(204, result.StatusCode);
            
        }

        [Fact]
        public void UserControllerShouldReturnNotFoundStatusForEmpDetails()
        {
            //Arrange
            int id = 50042655;
            EmployeeDetails empDetails = new EmployeeDetails();
            
            var moqService = new Mock<IUserService>();
            moqService.Setup(x => x.GetUserDetails(6754)).Returns(empDetails);
            UserController obj = new UserController(moqService.Object);

            //Act
            IActionResult action = obj.GetEmployee(id);
            var result = action as StatusCodeResult;

            //Assert
            Assert.NotEqual(404, result.StatusCode);


        }
        [Fact]
        public void UserControllerShouldReturnOkStatusForEmployeeDetails()
        {
            //Arrange

            EmployeeDetails empDetails =new EmployeeDetails();
           

            var moqService = new Mock<IUserService>();
            moqService.Setup(x => x.GetUserDetails(It.IsAny<int>())).Returns(empDetails);
            UserController obj = new UserController(moqService.Object);

            //Act
            IActionResult action = obj.GetEmployee(12);//   var result = action as StatusCodeResult;

            var result = (OkObjectResult)action;
            //Assert
            Assert.Equal(200,result.StatusCode);

        }
        [Fact]
        public void UserControllerShouldThrowExceptionForEmpDetails()
        {
            //Arrange
            int id = 643933;
            EmployeeDetails empDetail = new EmployeeDetails();
            var moqService = new Mock<IUserService>();
            moqService.Setup(x => x.GetUserDetails(It.IsAny<int>())).Throws(new Exception());
            UserController obj = new UserController(moqService.Object);

            //Act
            IActionResult action = obj.GetEmployee(id);
            var result = (StatusCodeResult)action;

            //Assert
            Assert.Equal(500, result.StatusCode);
        }
        [Fact]
        public void UserControllerShouldReturnBadRequestStatusForRequestDetails()
        {
            //Arrange
            int id = 50043965;
            var moqService = new Mock<IUserService>();
            RequestDetails reqDetail = new RequestDetails();
            reqDetail = null;
            moqService.Setup(x => x.GetUserByEmpcode(It.IsAny<int>())).Returns(reqDetail);
            UserController obj = new UserController(moqService.Object);

            //Act
            IActionResult action = obj.GetRequest(id);
            var action1 = (StatusCodeResult)action ;

            //Assert
            Assert.Equal(400, action1.StatusCode);
        }

        [Fact]

        public void UserControllerShouldReturnNoContentStatusForRequestDetails()
        {
            //Arrange
            int id = 50042677;
            RequestDetails reqDetails = new RequestDetails();
            reqDetails = null;
            var moqService = new Mock<IUserService>();
            moqService.Setup(x => x.GetUserByEmpcode(id)).Returns(reqDetails);
            UserController obj = new UserController(moqService.Object);

            //Act
            IActionResult action = obj.GetRequest(id);
            var result = action as StatusCodeResult;

            //Assert
            Assert.NotEqual(204, result.StatusCode);

        }

        [Fact]
        public void UserControllerShouldReturnNotFoundStatusForRequestDetails()
        {
            //Arrange
            int id = 50042655;
            RequestDetails reqDetails = new RequestDetails();
            reqDetails = null;
            var moqService = new Mock<IUserService>();
            moqService.Setup(x => x.GetUserByEmpcode(id)).Returns(reqDetails);
            UserController obj = new UserController(moqService.Object);

            //Act
            IActionResult action = obj.GetRequest(id);
            var result = action as StatusCodeResult;

            //Assert
            Assert.NotEqual(404, result.StatusCode);


        }
        [Fact]
        public void UserControllerShouldReturnOkStatusForRequestDetails()
        {
            //Arrange
            int id = 50042655;
            RequestDetails reqDetails = new RequestDetails();
           reqDetails.RequestId = 12;
            

            var moqService = new Mock<IUserService>();
            moqService.Setup(x => x.GetUserByEmpcode(It.IsAny<int>())).Returns(reqDetails);
            UserController obj = new UserController(moqService.Object);

            //Act
            IActionResult action = obj.GetRequest(id);
            var result = (OkObjectResult)action ;

            //Assert
            Assert.Equal(200, result.StatusCode);

        }
        [Fact]
        public void UserControllerShouldThrowExceptionForRequestDetails()
        {
            //Arrange
            int id = 643933;
            RequestDetails empDetail = new RequestDetails();
            var moqService = new Mock<IUserService>();
            moqService.Setup(x => x.GetUserByEmpcode(It.IsAny<int>())).Throws(new Exception());
            UserController obj = new UserController(moqService.Object);

            //Act
            IActionResult action = obj.GetRequest(id);
            var result = action as StatusCodeResult;

            //Assert
            Assert.Equal(500, result.StatusCode);
        }

        



    }
}
