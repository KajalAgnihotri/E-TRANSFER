using E_TransferWebApi.Models;
using E_TransferWebApi.Repository;
using E_TransferWebApi.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject1
{
    public class SupervisorServiceTest
    {
        [Fact]
        public void TestAddRequestifnotsuccessful()
        {  //arrange
            var mockRequestRepo=new Mock<IRequestDetailsRepo>();
            var mockAssetRepo=new Mock<IAssetDetailsRepo>();
            List<RequestDetails> requestlist=new List<RequestDetails>();
            RequestDetails req=new RequestDetails(){EmployeeCode = 1,DateOfRequest = DateTime.Now,RequestStatus = Requeststatus.Cleared,SupervisorCode = 123,pendingWith = Pendingwith.Supervisor};
            requestlist.Add(req);
            mockRequestRepo.Setup(x => x.GetAllRequest()).Returns(requestlist);
            SupervisorService ser=new SupervisorService(mockRequestRepo.Object,mockAssetRepo.Object);

            //act
            var result = ser.AddRequest(req);

            //assert
            Assert.Contains("already exist",result); 
        }

        [Fact]
        public void TestAddRequestifsuccessful()
        {  //arrange
            var mockRequestRepo = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            List<RequestDetails> requestlist = new List<RequestDetails>();
            RequestDetails reqq=new RequestDetails() { EmployeeCode = 2, DateOfRequest = DateTime.Now, RequestStatus = Requeststatus.Cleared, SupervisorCode = 123, pendingWith = Pendingwith.Supervisor };
            RequestDetails req = new RequestDetails() { EmployeeCode = 1, DateOfRequest = DateTime.Now, RequestStatus = Requeststatus.Cleared, SupervisorCode = 123, pendingWith = Pendingwith.Supervisor };
            requestlist.Add(req);
            mockRequestRepo.Setup(x => x.GetAllRequest()).Returns(requestlist);
            SupervisorService ser = new SupervisorService(mockRequestRepo.Object, mockAssetRepo.Object);

            //act
            var result = ser.AddRequest(reqq);

            //assert
            Assert.Contains("successful",result);
            Assert.NotEqual("already exist",result);
        }

        [Fact]
        public void TestGetRejectedAssetListByEmpCodereturninglist()
        {  //arrange
            var mockRequestRepo = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            List<AssetDetails> assetlist = new List<AssetDetails>();
            List<int> assetid = new List<int>();
            assetid.Add(3);
;           AssetDetails assetobject=new AssetDetails()
            {
                AssetCode = 1,
                AssetStatus = status.Rejected,
                AssignedTo = 12343,
                EmployeeCode = 3,
                Quantity = 2
            };
            assetlist.Add(assetobject);
            mockAssetRepo.Setup(x => x.GetAssetByEmpCode(3)).Returns(assetlist);
            SupervisorService ser = new SupervisorService(mockRequestRepo.Object, mockAssetRepo.Object);

            //act
            var result = ser.GetRejectedAssetListByEmpCode(assetid);

            //assert
            Assert.NotEqual(0,result.Count);
           Assert.NotNull(result);
           Assert.IsType(typeof(List<AssetDetails>),result);
        }
        [Fact]
        public void TestGetRejectedAssetListByEmpCodereturningnull()
        {  //arrange
            var mockRequestRepo = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            List<AssetDetails> assetlist = new List<AssetDetails>();
            List<int> assetid = new List<int>();
            assetid.Add(3);
            ; AssetDetails assetobject = new AssetDetails()
            {
                AssetCode = 1,
                AssetStatus = status.Accepted,
                AssignedTo = 12343,
                EmployeeCode = 3,
                Quantity = 2
            };
            assetlist.Add(assetobject);
            mockAssetRepo.Setup(x => x.GetAssetByEmpCode(3)).Returns(assetlist);
            SupervisorService ser = new SupervisorService(mockRequestRepo.Object, mockAssetRepo.Object);

            //act
            var result = ser.GetRejectedAssetListByEmpCode(assetid);

            //assert
            Assert.Equal(0,result.Count);
            Assert.IsType(typeof(List<AssetDetails>), result);
        }

        [Fact]
        public void TestReturningGetAllPendingRequestreturnlist()
        {  //arrange
            var mockRequestRepo = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            List<RequestDetails> requestlist = new List<RequestDetails>();
            requestlist.Add(new RequestDetails() { EmployeeCode = 2, DateOfRequest = DateTime.Now, RequestStatus = Requeststatus.Cleared, SupervisorCode = 123, pendingWith = Pendingwith.Supervisor });
            requestlist.Add(new RequestDetails() { EmployeeCode = 1, DateOfRequest = DateTime.Now, RequestStatus = Requeststatus.Cleared, SupervisorCode = 123, pendingWith = Pendingwith.Supervisor });
            mockRequestRepo.Setup(x => x.GetAllRequest()).Returns(requestlist);
            SupervisorService ser = new SupervisorService(mockRequestRepo.Object, mockAssetRepo.Object);

            //act
            var result = ser.GetAllpendingRequest();

            //assert
            Assert.NotEqual(0,result.Count);
            Assert.IsType(typeof(List<RequestDetails>), result);
        }
        [Fact]
        public void TestReturningGetAllPendingRequestnotreturnlist()
        {  //arrange
            var mockRequestRepo = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            List<RequestDetails> requestlist = new List<RequestDetails>();
            requestlist.Add(new RequestDetails() { EmployeeCode = 2, DateOfRequest = DateTime.Now, RequestStatus = Requeststatus.Cleared, SupervisorCode = 123, pendingWith = Pendingwith.CSO });
            requestlist.Add(new RequestDetails() { EmployeeCode = 1, DateOfRequest = DateTime.Now, RequestStatus = Requeststatus.Cleared, SupervisorCode = 123, pendingWith = Pendingwith.CSO });
            mockRequestRepo.Setup(x => x.GetAllRequest()).Returns(requestlist);
            SupervisorService ser = new SupervisorService(mockRequestRepo.Object, mockAssetRepo.Object);

            //act
            var result = ser.GetAllpendingRequest();

            //assert
            Assert.Equal(0,result.Count);
            Assert.IsType(typeof(List<RequestDetails>), result);
        }
    }
}
