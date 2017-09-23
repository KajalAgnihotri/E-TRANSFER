using E_TransferWebApi.Controllers;
using E_TransferWebApi.Models;
using E_TransferWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Xunit;

namespace XUnitTestProject1
{
    public class HRcontrollerTest
    {
        [Fact]
        public void Test_The_Return_Type_to_be_Not_Found_of_Get_Method_if_no_object_is_returned_from_service()
        {
            //Arrange
            List<RequestDetails> requestList = new List<RequestDetails>();
            var mockService = new Mock<IHRService>();
            mockService.Setup(m => m.GetAllRequest()).Returns(requestList);
            HRController obj = new HRController(mockService.Object);

            // Act
            IActionResult action1 = obj.Get();
            action1 = (NotFoundObjectResult)action1;

            // Assert
            Assert.IsType(typeof(NotFoundObjectResult), action1);
        }

        [Fact]
        public void Test_The_Return_Type_to_be_Ok_result_of_Get_Method_when_list_is_returned()
        {
            //Arranges
            List<RequestDetails> requestList = new List<RequestDetails>();
            requestList.Add( new RequestDetails { RequestId =1 , EmployeeCode = 12345678 , SupervisorCode= 12349867 , Newpacode = "noida" , Newpsacode = "h7" });
            requestList.Add(new RequestDetails { RequestId = 2, EmployeeCode = 12345678, SupervisorCode = 12349867, Newpacode = "noida", Newpsacode = "h7" });
            var mockService = new Mock<IHRService>();
            mockService.Setup(m => m.GetAllRequest()).Returns(requestList);
            HRController obj = new HRController(mockService.Object);

            // Act
            IActionResult action1 = obj.Get();
            action1 = (OkObjectResult)action1;

            // Assert
            Assert.IsType(typeof(OkObjectResult), action1);
            Assert.Equal(requestList, (action1 as OkObjectResult).Value);
        }

        [Fact]
        public void Test_The_Return_Type_to_be_StatusCode500_of_Get_Method_if_exception_is_thrown()
        {
            //Arrange
            List<RequestDetails> requestList = new List<RequestDetails>();
            var mockService = new Mock<IHRService>();
            mockService.Setup(m => m.GetAllRequest()).Throws<Exception>();
            HRController obj = new HRController(mockService.Object);

            // Act
            IActionResult action1 = obj.Get();
            action1 = (StatusCodeResult)action1;

            // Assert
            Assert.IsType(typeof(StatusCodeResult), action1);
            Assert.Equal(500, (action1 as StatusCodeResult).StatusCode);
        }

        [Fact]
        public void Test_The_Return_Type_to_be_StatusCode102_of_Get_Method_When_Timeout_exception_is_thrown()
        {
            //Arrange
            List<RequestDetails> requestList = new List<RequestDetails>();
            var mockService = new Mock<IHRService>();
            mockService.Setup(m => m.GetAllRequest()).Throws<TimeoutException>();
            HRController obj = new HRController(mockService.Object);

            // Act
            IActionResult action1 = obj.Get();
            action1 = (StatusCodeResult)action1;

            // Assert
            Assert.IsType(typeof(StatusCodeResult), action1);
            Assert.Equal(102, (action1 as StatusCodeResult).StatusCode);
        }

        [Fact]
        public void Test_Return_type_of_BadRequest_Of__PutAccepRequest_Method_When_null_object_is_passed()
        {
            //Arrange    
            RequestDetails request = null;
            var mockService = new Mock<IHRService>();
            mockService.Setup(m => m.UpdateRequest(It.IsAny<int>(), It.IsAny<RequestDetails>())).Returns(true);
            HRController obj = new HRController(mockService.Object);

            // Act
            IActionResult action1 = obj.PutAcceptRequest(1,request);
            action1 = (BadRequestResult)action1;

            // Assert
            Assert.IsType(typeof(BadRequestResult), action1);
           
        }

        [Fact]
        public void Test_Return_type_of_NoContentResult_Of__PutAccepRequest_Method_When_object_passed_is_not_null_and_updated_succesfully()
        {
            //Arrange    
            RequestDetails request = new RequestDetails() { RequestId=1 , EmployeeCode=123 , NewpsaCode="Noida" , NewOucode="001234" , Newpacode="Greater noida" };
            var mockService = new Mock<IHRService>();
            mockService.Setup(m => m.UpdateRequest(It.IsAny<int>(), It.IsAny<RequestDetails>())).Returns(true);
            HRController obj = new HRController(mockService.Object);

            // Act
            IActionResult action1 = obj.PutAcceptRequest(1, request);
            action1 = (NoContentResult)action1;

            // Assert
            Assert.IsType(typeof(NoContentResult), action1);
        }

        [Fact]
        public void Test_Return_type_of_BadRequest_Of__PutAccepRequest_Method_When_object_passed_is_not_updated()
        {
            //Arrange    
            RequestDetails request = new RequestDetails() { RequestId = 1, EmployeeCode = 123, NewpsaCode = "Noida", NewOucode = "001234", Newpacode = "Greater noida" };
            var mockService = new Mock<IHRService>();
            mockService.Setup(m => m.UpdateRequest(It.IsAny<int>(), It.IsAny<RequestDetails>())).Returns(false);
            HRController obj = new HRController(mockService.Object);

            // Act
            IActionResult action1 = obj.PutAcceptRequest(1, request);
            action1 = (BadRequestResult)action1;

            // Assert
            Assert.IsType(typeof(BadRequestResult), action1);
        }

        [Fact]
        public void Test_Return_type_of_Statuscode500_Of__PutAccepRequest_Method_When_Exception_was_thrown()
        {
            //Arrange    
            RequestDetails request = new RequestDetails() { RequestId = 1, EmployeeCode = 123, NewpsaCode = "Noida", NewOucode = "001234", Newpacode = "Greater noida" };
            var mockService = new Mock<IHRService>();
            mockService.Setup(m => m.UpdateRequest(It.IsAny<int>(), It.IsAny<RequestDetails>())).Throws<Exception>();
            HRController obj = new HRController(mockService.Object);

            // Act
            IActionResult action1 = obj.PutAcceptRequest(1, request);
            action1 = (StatusCodeResult)action1;

            // Assert
            Assert.IsType(typeof(StatusCodeResult), action1);
            Assert.Equal(500, (action1 as StatusCodeResult).StatusCode);
        }

        [Fact]
        public void Test_Return_type_of_BadRequest_Of__PutAccepRequest_Method_When_Argument_Null_Exception_is_thrown()
        {
            //Arrange    
            RequestDetails request = new RequestDetails() { RequestId = 1, EmployeeCode = 123, NewpsaCode = "Noida", NewOucode = "001234", Newpacode = "Greater noida" };
            var mockService = new Mock<IHRService>();
            mockService.Setup(m => m.UpdateRequest(It.IsAny<int>(), It.IsAny<RequestDetails>())).Throws<ArgumentNullException>();
            HRController obj = new HRController(mockService.Object);

            // Act
            IActionResult action1 = obj.PutAcceptRequest(1, request);
            action1 = (BadRequestResult)action1;

            // Assert
            Assert.IsType(typeof(BadRequestResult), action1);
        }

        [Fact]
        public void Test_Return_type_of_BadRequest_Of__PutRejectRequest_Method_When_object_passed_is_null()
        {
            //Arrange    
            RequestDetails request = null;
            var mockService = new Mock<IHRService>();
            mockService.Setup(m => m.UpdateRequestWithComment(It.IsAny<string>(), It.IsAny<RequestDetails>())).Returns(false);
            HRController obj = new HRController(mockService.Object);

            // Act
            IActionResult action1 = obj.PutRejectRequest("ou code is not correct", request);
            action1 = (BadRequestResult)action1;

            // Assert
            Assert.IsType(typeof(BadRequestResult), action1);
            
          
        }

        [Fact]
        public void Test_Return_type_of_BadRequest_Of__PutRejectRequest_Method_When_comment_passed_is_null()
        {
            //Arrange    
            RequestDetails request = new RequestDetails() { RequestId = 1, EmployeeCode = 12345678 , NewOucode = "delhi"};
            var mockService = new Mock<IHRService>();
            mockService.Setup(m => m.UpdateRequestWithComment(It.IsAny<string>(), It.IsAny<RequestDetails>())).Returns(false);
            HRController obj = new HRController(mockService.Object);

            // Act
            IActionResult action1 = obj.PutRejectRequest("", request);
            action1 = (BadRequestResult)action1;

            // Assert
            Assert.IsType(typeof(BadRequestResult), action1);


        }

        [Fact]
        public void Test_Return_type_of_NoContentResult_Of__PutRejectRequest_Method_When_Argument_passed_is_string_object_is_not_null_and_updated_succesfully()
        {
            //Arrange    
            RequestDetails request = new RequestDetails() { RequestId = 1, EmployeeCode = 123, NewpsaCode = "Noida", NewOucode = "001234", Newpacode = "Greater noida" };
            var mockService = new Mock<IHRService>();
            mockService.Setup(m => m.UpdateRequestWithComment(It.IsAny<string>(), It.IsAny<RequestDetails>())).Returns(true);
            HRController obj = new HRController(mockService.Object);

            // Act
            IActionResult action1 = obj.PutRejectRequest("ou code not correct", request);
            action1 = (NoContentResult)action1;

            // Assert
            Assert.IsType(typeof(NoContentResult), action1);
        }

        [Fact]
        public void Test_Return_type_of_BadRequestResult_Of__PutRejectRequest_Method_When_Argument_passed_is_string_object_is_not_null_and_not_updated_succesfully()
        {
            //Arrange    
            RequestDetails request = new RequestDetails() { RequestId = 1, EmployeeCode = 123, NewpsaCode = "Noida", NewOucode = "001234", Newpacode = "Greater noida" };
            var mockService = new Mock<IHRService>();
            mockService.Setup(m => m.UpdateRequestWithComment(It.IsAny<string>(), It.IsAny<RequestDetails>())).Returns(false);
            HRController obj = new HRController(mockService.Object);

            // Act
            IActionResult action1 = obj.PutRejectRequest("ou code not correct", request);
            action1 = (BadRequestResult)action1;

            // Assert
            Assert.IsType(typeof(BadRequestResult), action1);
        }

        [Fact]
        public void Test_Return_type_of_StatusCode500_Of__PutRejectRequest_Method_When_Exception_is_thrown()
        {
            //Arrange    
            RequestDetails request = new RequestDetails() { RequestId = 1, EmployeeCode = 123, NewpsaCode = "Noida", NewOucode = "001234", Newpacode = "Greater noida" };
            var mockService = new Mock<IHRService>();
            mockService.Setup(m => m.UpdateRequestWithComment(It.IsAny<string>(), It.IsAny<RequestDetails>())).Throws<Exception>();
            HRController obj = new HRController(mockService.Object);

            // Act
            IActionResult action1 = obj.PutRejectRequest("ou code not correct", request);
            action1 = (StatusCodeResult)action1;

            // Assert
            Assert.IsType(typeof(StatusCodeResult), action1);
            Assert.Equal(500, (action1 as StatusCodeResult).StatusCode);
        }

        [Fact]
        public void Test_Return_type_of_BadRequest_Of__PutRejectRequest_Method_When_Argument_null_Exception_is_throw()
        {
            //Arrange    
            RequestDetails request = new RequestDetails() { };
            var mockService = new Mock<IHRService>();
            mockService.Setup(m => m.UpdateRequestWithComment(It.IsAny<string>(), It.IsAny<RequestDetails>())).Throws<ArgumentNullException>();
            HRController obj = new HRController(mockService.Object);

            // Act
            IActionResult action1 = obj.PutRejectRequest("ou code not correct", request);
            action1 = (BadRequestResult)action1;

            // Assert
            Assert.IsType(typeof(BadRequestResult), action1);
        }
    }
}
