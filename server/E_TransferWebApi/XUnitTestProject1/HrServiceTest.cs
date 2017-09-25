using E_TransferWebApi.Models;
using E_TransferWebApi.Repository;
using E_TransferWebApi.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject1
{
    public class HrServiceTest
    {
        [Fact]
        public void Test_The_Return_Type_to_be_List_of_RequestDetails_of_GetAll_Method()
        {
            //Arrange
            List<RequestDetails> requestList = new List<RequestDetails>();
            requestList.Add(new RequestDetails() { RequestId = 1, EmployeeCode = 12345678, NewOucode = "delhi", RequestStatus = Requeststatus.Pending, pendingWith = Pendingwith.HR });
            var mockReqRepo = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            var mockEmpRepo = new Mock<IEmployeeDetailsRepo>();
            mockReqRepo.Setup(m => m.GetAllRequest()).Returns(requestList);
            HRService obj = new HRService(mockReqRepo.Object, mockEmpRepo.Object, mockAssetRepo.Object);

            // Act
            var action1 = obj.GetAllRequest();

            // Assert
            Assert.IsType(typeof(List<RequestDetails>), action1);
            Assert.Equal(1, requestList.Count);
            Assert.NotNull(action1);

        }


        [Fact]         //Second Test case
        public void Test_The_Return_Type_List_Is_Empty_of_RequestDetails_of_GetAll_Method()
        {
            //Arrange
            var mockReqRepo = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            var mockEmpRepo = new Mock<IEmployeeDetailsRepo>();
            List<RequestDetails> list = new List<RequestDetails>();
            mockReqRepo.Setup(x => x.GetAllRequest()).Returns(list);
            HRService obj = new HRService(mockReqRepo.Object, mockEmpRepo.Object, mockAssetRepo.Object);
            //Act
            var result = obj.GetAllRequest();
            //Assert
            Assert.IsType(typeof(List<RequestDetails>), result);
            Assert.Equal(0, list.Count);
        }

        [Fact]   //third test case
        public void Test_On_UpdateRequest_IsNotType()
        {
            //Arrange
            RequestDetails request = new RequestDetails();
            request.RequestId = 5;

            var mockReqRepo = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            var mockEmpRepo = new Mock<IEmployeeDetailsRepo>();
            mockReqRepo.Setup(m => m.EditRequestByHr(5, request));
            HRService obj = new HRService(mockReqRepo.Object, mockEmpRepo.Object, mockAssetRepo.Object);
            //Act
            var type = obj.UpdateRequest(2, request);

            //Assert
            Assert.IsNotType<int>(type);
            Assert.IsType<bool>(type);
            Assert.NotNull(type);
        }

        [Fact]    //fourth test
        public void Test_On_GetAssetDetailsByEmpcode_Which_Return_list()
        {
            //Arrange
            List<AssetDetails> assetDetail = new List<AssetDetails>();
            assetDetail.Add(new AssetDetails() { EmployeeCode = 77, AssetCode = 456, AssetId = 23, CompanyCode = "45" });
            var mockReq = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            var mockEmp = new Mock<IEmployeeDetailsRepo>();
            mockAssetRepo.Setup(x => x.GetAssetByEmpCode(It.IsAny<int>())).Returns(assetDetail);
            HRService obj = new HRService(mockReq.Object, mockEmp.Object, mockAssetRepo.Object);

            //act
            var result = obj.GetAssetDetailsByEmpCode(77);

            //Assert
            Assert.IsType(typeof(List<AssetDetails>), result);
            Assert.NotNull(result);
            Assert.NotEqual(0, result.Count);

        }

        [Fact]    //fifth test
        public void Test_On_GetAssetDetailsByEmpcode_Which_return_Empty_list()
        {
            //Arrange
            List<AssetDetails> assetDetail = new List<AssetDetails>();
            var mockReq = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            var mockEmp = new Mock<IEmployeeDetailsRepo>();
            mockAssetRepo.Setup(x => x.GetAssetByEmpCode(It.IsAny<int>())).Returns(assetDetail);
            HRService obj = new HRService(mockReq.Object, mockEmp.Object, mockAssetRepo.Object);

            //act
            var result = obj.GetAssetDetailsByEmpCode(77);

            //Assert
            Assert.IsType(typeof(List<AssetDetails>), result);
            Assert.NotNull(result);
            Assert.Equal(0, result.Count);
        }

        [Fact]   //sixth test case
        public void Test_On_UpdateRequestWithComment_IsNotType()
        {
            //Arrange
            RequestDetails request = new RequestDetails();
            request.RequestId = 5;

            var mockReqRepo = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            var mockEmpRepo = new Mock<IEmployeeDetailsRepo>();
            mockReqRepo.Setup(m => m.EditRequestByHr(5, request));
            HRService obj = new HRService(mockReqRepo.Object, mockEmpRepo.Object, mockAssetRepo.Object);
            //Act
            var type = obj.UpdateRequest(2, request);

            //Assert
            Assert.IsNotType<int>(type);
            Assert.IsType<bool>(type);
            Assert.NotNull(type);
        }

        [Fact]  //seventh test case
        public void TestOnEmailApprovalByHr()
        {
            //arrange
            List<AssetDetails> assets = new List<AssetDetails>();
            AssetDetails assetDetail = new AssetDetails();
            RequestDetails requestData = new RequestDetails();
            requestData.EmployeeCode = 11;
            assetDetail.EmployeeCode = 11;
            assetDetail.AssignToEmailId = "dh@gmail.com";
            assetDetail.AssignedTo = 20;
            assets.Add(assetDetail);
            var mockReq = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            var mockEmp = new Mock<IEmployeeDetailsRepo>();

            mockAssetRepo.Setup(x => x.GetAssetByEmpCode(It.IsAny<int>())).Returns(assets);
            HRService obj = new HRService(mockReq.Object, mockEmp.Object, mockAssetRepo.Object);

            //act
            var result = obj.EmailForApprovalInHr(11, requestData);

            //Assert
            Assert.IsType(typeof(bool), result);
            Assert.NotNull(result);

        }

        [Fact]  //eighth test case
        public void TestOnEmailApprovalByHr_ExceptionCase()
        {
            //arrange
            List<AssetDetails> assets = new List<AssetDetails>();
            AssetDetails assetDetail = new AssetDetails();
            RequestDetails requestData = new RequestDetails();
            requestData.EmployeeCode = 11;
            assetDetail.EmployeeCode = 11;
            assetDetail.AssignedTo = 20;
            assets.Add(assetDetail);
            var mockReq = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            var mockEmp = new Mock<IEmployeeDetailsRepo>();

            mockAssetRepo.Setup(x => x.GetAssetByEmpCode(It.IsAny<int>())).Throws(new Exception());
            HRService obj = new HRService(mockReq.Object, mockEmp.Object, mockAssetRepo.Object);

            //act
            var result = obj.EmailForApprovalInHr(11, requestData);

            //Assert
            Assert.IsType<Exception>(result);

        }

        [Fact]  //ninth test case
        public void TestOnEmailRejectionByHr()
        {
            //arrange
            EmployeeDetails emp = new EmployeeDetails();
            RequestDetails requestData = new RequestDetails();
            requestData.EmployeeCode = 11;
            emp.Supervisor = 11;
            emp.DateOfTransfer = DateTime.Now;
            emp.SupervisorName = "db";
            requestData.SupervisorCode = 11;
            var mockReq = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            var mockEmp = new Mock<IEmployeeDetailsRepo>();

            mockEmp.Setup(x => x.GetEmployeeById(It.IsAny<int>())).Returns(emp);
            HRService obj = new HRService(mockReq.Object, mockEmp.Object, mockAssetRepo.Object);

            //act
            var result = obj.EmailRejected("11", requestData);

            //Assert
            Assert.IsType<bool>(result);
            Assert.NotNull(result);

        }

        [Fact]  //tenth test case
        public void TestOnEmailRejectionByHr_Exception_Case()
        {
            //arrange
            EmployeeDetails emp = new EmployeeDetails();
            RequestDetails requestData = new RequestDetails();
            requestData.EmployeeCode = 11;
            emp.Supervisor = 11;
            emp.SupervisorName = "db";
            requestData.SupervisorCode = 11;
            var mockReq = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            var mockEmp = new Mock<IEmployeeDetailsRepo>();

            mockEmp.Setup(x => x.GetEmployeeById(It.IsAny<int>())).Throws(new Exception());
            HRService obj = new HRService(mockReq.Object, mockEmp.Object, mockAssetRepo.Object);

            //act
            var result = obj.EmailRejected("11", requestData);

            //Assert
            Assert.IsType<Exception>(result);
        }

    }
}
