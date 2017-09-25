using E_TransferWebApi.Repository;
using System;
using Xunit;
using Moq;
using E_TransferWebApi.Models;
using System.Collections.Generic;
using E_TransferWebApi.Services;
using Microsoft.EntityFrameworkCore;

namespace AssetTestCase
{
    public class CsoServiceTestcase
    {
        [Fact]
        public void TestOnGetRequestPendingWithCsoTypeOf()
        {
            //arrange
            var mockRequestRepo = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            var mockEmployeeRepo = new Mock<IEmployeeDetailsRepo>();
            List<RequestDetails> reqdetail = new List<RequestDetails>();
            List<AssetDetails> assetDetail = new List<AssetDetails>();
            List<EmployeeDetails> empDetails = new List<EmployeeDetails>();
            reqdetail.Add(new RequestDetails() {RequestId=10,DateOfRequest=DateTime.Now,EmployeeCode=20,SupervisorCode=30, pendingWith=Pendingwith.CSO,RequestStatus=Requeststatus.Pending});
            assetDetail.Add(new AssetDetails() {AssetId=10,AssetCode=20,AssetStatus=status.Accepted,AssignedTo=20,EmployeeCode=20,Quantity=2 });          
            mockRequestRepo.Setup(x => x.GetAllRequest()).Returns(reqdetail);
            mockAssetRepo.Setup(x => x.GetAssetByEmpCode(It.IsAny<int>())).Returns(assetDetail);
            CsoService cso = new CsoService(mockRequestRepo.Object, mockAssetRepo.Object, mockEmployeeRepo.Object);

            //act
            var result = cso.GetRequestPendingWithCso();

            //Assert
            Assert.IsType(typeof(List<RequestDetails>), result);
            Assert.NotNull(result);
        }


        [Fact]
        public void TestOnEmailFromCso()
        {
            //arrange
            RequestDetails requestData = new RequestDetails();
            requestData.DateOfRequest = DateTime.Now;
            requestData.pendingWith = 0;
            requestData.RequestStatus = Requeststatus.Pending;
            requestData.SupervisorCode = 123;
            requestData.EmployeeCode = 11;
            EmployeeDetails empdata = new EmployeeDetails();
            empdata.EmployeeCode = 11;
            empdata.EmployeeName = "param";
            empdata.EmployeeEmailId = "dh@gmail.com";
            empdata.DateOfTransfer = DateTime.Now;
            empdata.Supervisor = 123;
            var mockReq = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            var mockEmp = new Mock<IEmployeeDetailsRepo>();
            List<RequestDetails> reqdetail = new List<RequestDetails>();
            List<AssetDetails> assetDetail = new List<AssetDetails>();
            List<EmployeeDetails> empDetails = new List<EmployeeDetails>();
            mockEmp.Setup(x => x.GetEmployeeById(It.IsAny<int>())).Returns(empdata);
            CsoService cso = new CsoService(mockReq.Object, mockAssetRepo.Object, mockEmp.Object);

            //act
            var result = cso.EmailbyCso(requestData);

            //Assert
            Assert.IsType(typeof(bool), result);

        }



        [Fact]
        public void TestOnGetRequestPendingWithCsoEquals()
        {
            //arrange
            var mockRequestRepo = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            var mockEmployeeRepo = new Mock<IEmployeeDetailsRepo>();
            List<RequestDetails> reqdetail = new List<RequestDetails>();
            List<AssetDetails> assetDetail = new List<AssetDetails>();
            List<EmployeeDetails> empDetails = new List<EmployeeDetails>();
            mockRequestRepo.Setup(x => x.GetAllRequest()).Returns(reqdetail);
            mockAssetRepo.Setup(x => x.GetAssetByEmpCode(It.IsAny<int>())).Returns(assetDetail);
            CsoService cso = new CsoService(mockRequestRepo.Object, mockAssetRepo.Object, mockEmployeeRepo.Object);

            //act
            var result = cso.GetRequestPendingWithCso();

            //Assert
            Assert.Equal(reqdetail, result);
        }

        [Fact]
        public void TestOnGetRequestPendingWithCsoNotTypeOf()
        {
            //arrange
            int a = 1;
            var mockRequestRepo = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            var mockEmployeeRepo = new Mock<IEmployeeDetailsRepo>();
            List<RequestDetails> reqdetail = new List<RequestDetails>();
            List<AssetDetails> assetDetail = new List<AssetDetails>();
            List<EmployeeDetails> empDetails = new List<EmployeeDetails>();
            mockRequestRepo.Setup(x => x.GetAllRequest()).Returns(reqdetail);
            mockAssetRepo.Setup(x => x.GetAssetByEmpCode(a)).Returns(assetDetail);
            CsoService cso = new CsoService(mockRequestRepo.Object, mockAssetRepo.Object, mockEmployeeRepo.Object);

            //act
            var result = cso.GetRequestPendingWithCso();

            //Assert
            Assert.IsNotType(typeof(int), result);
        }


        [Fact]
        public void TestOnGetAssetDetailsByEmpcodeIsNotType()
        {
            //Arrange
            List<AssetDetails> assetDetail = new List<AssetDetails>();
            var mockReq = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            var mockEmp = new Mock<IEmployeeDetailsRepo>();
            mockAssetRepo.Setup(x => x.GetAssetByEmpCode(It.IsAny<int>()));
            CsoService cso = new CsoService(mockReq.Object, mockAssetRepo.Object, mockEmp.Object);

            //act
            var result = cso.GetAssetDetailsByEmpcode(77);

            //Assert
            Assert.IsNotType(typeof(int),result);
        }

        [Fact]
        public void TestOnGetAssetDetailsByEmpcodeIsType()
        {
            //Arrange
            List<AssetDetails> assetDetail = new List<AssetDetails>();
            AssetDetails assest = new AssetDetails();
            assest.AssetId = 5;
            assest.AssetCode = 1;
            assetDetail.Add(assest);
            var mockReq = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            var mockEmp = new Mock<IEmployeeDetailsRepo>();
            mockAssetRepo.Setup(x => x.GetAssetByEmpCode(It.IsAny<int>())).Returns(assetDetail);
            CsoService cso = new CsoService(mockReq.Object, mockAssetRepo.Object, mockEmp.Object);

            //act
            var result = cso.GetAssetDetailsByEmpcode(5);

            //Assert
            //Assert.IsType(typeof(List<AssetDetails>), result);
            Assert.Equal(assetDetail, result);
        }

        [Fact]
        public void TestOnGetAssetDetailsByEmpcodeEqual()
        {
            //Arrange
            List<AssetDetails> assetDetail = new List<AssetDetails>();
            AssetDetails assest = new AssetDetails();
            assest.AssetId = 5;
            assest.AssetCode = 1;
            assetDetail.Add(assest);
            var mockReq = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            var mockEmp = new Mock<IEmployeeDetailsRepo>();
            mockAssetRepo.Setup(x => x.GetAssetByEmpCode(It.IsAny<int>())).Returns(assetDetail);
            CsoService cso = new CsoService(mockReq.Object, mockAssetRepo.Object, mockEmp.Object);

            //act
            var result = cso.GetAssetDetailsByEmpcode(5);

            //Assert
            Assert.IsType(typeof(List<AssetDetails>), result);
           // Assert.Equal(assetDetail, result);
        }

        [Fact]
        public void TestOnGetAssetDetailsByEmpcodeNotNull()
        {
            //Arrange
            List<AssetDetails> assetDetail = new List<AssetDetails>();
            AssetDetails assest = new AssetDetails();
            assest.AssetId = 5;
            assest.AssetCode = 1;
            assetDetail.Add(assest);
            var mockReq = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            var mockEmp = new Mock<IEmployeeDetailsRepo>();
            mockAssetRepo.Setup(x => x.GetAssetByEmpCode(It.IsAny<int>())).Returns(assetDetail);
            CsoService cso = new CsoService(mockReq.Object, mockAssetRepo.Object, mockEmp.Object);

            //act
            var result = cso.GetAssetDetailsByEmpcode(6);

            //Assert
           // Assert.IsType(typeof(List<AssetDetails>), result);
             Assert.NotNull(result);
        }

        

        [Fact]
        public void TestOnUpdateRequestIsNotType()
        {
            //Arrange
            RequestDetails request = new RequestDetails();
            request.RequestId = 5;
            RequestDetails requests = new RequestDetails();
            requests.RequestId = 3;
            var mockReq = new Mock<IRequestDetailsRepo>();
            var mockAsset = new Mock<IAssetDetailsRepo>();
            var mockEmp = new Mock<IEmployeeDetailsRepo>();
            mockReq.Setup(m => m.EditRequestByCso(5, request));
            CsoService cso = new CsoService(mockReq.Object,mockAsset.Object,mockEmp.Object);
            //Act
            var type = cso.UpdateRequest(2,requests);

            //Assert
            Assert.IsNotType<int>(type);
        }

        [Fact]
        public void TestOnUpdateRequestIsType()
        {
            //Arrange
            RequestDetails request = new RequestDetails();
            request.RequestId = 5;
            RequestDetails requests = new RequestDetails();
            requests.RequestId = 3;
            var mockReq = new Mock<IRequestDetailsRepo>();
            var mockAsset = new Mock<IAssetDetailsRepo>();
            var mockEmp = new Mock<IEmployeeDetailsRepo>();
            mockReq.Setup(m => m.EditRequestByCso(5, request));
            CsoService cso = new CsoService(mockReq.Object, mockAsset.Object, mockEmp.Object);

            //Act
            var type = cso.UpdateRequest(2, requests);

            //Assert
            Assert.IsType<bool>(type);
        }

       
    }
}