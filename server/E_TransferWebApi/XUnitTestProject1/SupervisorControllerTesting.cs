using System;
using Xunit;
using Moq;
using E_TransferWebApi.Controllers;
using E_TransferWebApi.Services;
using E_TransferWebApi.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel;


namespace XUnitTestProject1
{
    public class SupervisorControllerTesting
    {
        //GetRequest
        [Fact]
        public void Check_If_Controller_Is_Getting_List_Of_All_Pending_requests()
        {
            //Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            List<RequestDetails> request = new List<RequestDetails>();
            request.Add(new RequestDetails(){EmployeeCode = 122, RequestId = 3, EmployeeDetails = null, NewCcCode = "cc", NewOucode = "ou", Newpacode = "pa", RequestStatus = Requeststatus.Cleared, Newpsacode = "psa", SupervisorCode = 123, TypeOfRequest = "1/2/2000", pendingWith = Pendingwith.Approved});
            mock.Setup(x => x.GetAllpendingRequest()).Returns(request);
            var result =(OkObjectResult) controller.GetRequest();
            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Check_If_Controller_Is_Getting_List_Of_All_Pending_requests_Returns_Not_Found()
        {
            //Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            List<RequestDetails> request = new List<RequestDetails>();
            mock.Setup(x => x.GetAllpendingRequest()).Returns(request);
            var result = (NotFoundObjectResult)controller.GetRequest();
            //Assert        
            Assert.Equal(404, result.StatusCode);
        }
        [Fact]
        public void Check_If_Controller_Is_Getting_List_Of_All_Pending_requests_Returns_Exception()
        {
            //Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            List<RequestDetails> request = new List<RequestDetails>();
            mock.Setup(x => x.GetAllpendingRequest()).Throws(new Exception());
            var result =(StatusCodeResult) controller.GetRequest();
            //Assert
            Assert.Equal(500, result.StatusCode);
        }

        //GetRequestByID
        [Fact]
        public void Check_If_Controller_Is_Getting_List_Of_All_Request_By_Employee_ID()
        {
            //Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            RequestDetails request = new RequestDetails();
            mock.Setup(x => x.GetRequestById(request.RequestId)).Returns(request);
            var result = (OkObjectResult)controller.GetRequestById(request.RequestId);
            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void Check_If_Controller_Is_Getting_Request_By_Employee_ID_Returns_Not_Found()
        {
            //Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            RequestDetails request = new RequestDetails();
            int i = 0;
            request = null;
            mock.Setup(x => x.GetRequestById(i)).Returns(request);
            var result = (NotFoundObjectResult) controller.GetRequestById(i);
            //Assert        
            Assert.Equal(404, result.StatusCode);
        }
        [Fact]
        public void Check_If_Controller_Is_Getting_Request_By_Employee_ID_Returns_Exception()
        {
            //Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            RequestDetails request = new RequestDetails();
            //request = null;
            mock.Setup(x => x.GetRequestById(request.RequestId)).Throws(new Exception());
            var result = (StatusCodeResult) controller.GetRequestById(request.RequestId);
            //Assert
            Assert.Equal(500, result.StatusCode);
        }


        //PostRequest
        [Fact]
        public void Check_If_Controller_Is_Posting_Requests_Returns_Bad_Request()
        {
            //Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            var result = (BadRequestObjectResult)controller.PostRequest(null);
            //Assert
            Assert.Equal(400,result.StatusCode);           
        }

        [Fact]
        public void Check_If_Controller_Is_Posting_Requests_Successfully_And_Returns_True()
        {
            //Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            RequestDetails request = new RequestDetails();
            mock.Setup(x => x.AddRequest(request)).Returns(true);
            var result = (OkObjectResult)controller.PostRequest(request);
            //Assert        
            Assert.Equal(200,result.StatusCode);
        }

        [Fact]
        public void Check_If_Controller_Is_Posting_Requests_Unsuccessfully_And_Returns_False()
        {
            //Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            RequestDetails request = new RequestDetails();
            mock.Setup(x => x.AddRequest(request)).Returns(false);
            var result = (NotFoundObjectResult)controller.PostRequest(request);
            //Assert        
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public void Check_If_Controller_Is_Posting_Requests_Unsuccessfully_And_Throws_Exception()
        {
            //Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            RequestDetails request = new RequestDetails();
            mock.Setup(x => x.AddRequest(request)).Throws(new Exception());
            var result = (StatusCodeResult)controller.PostRequest(request);
            //Assert        
            Assert.Equal(500, result.StatusCode);
        }

        //PostAsset
        [Fact]
        public void Check_If_Controller_Is_Posting_Assets_Returns_Bad_Request()
        {
            //Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            //List<AssetDetails> assets = new List<AssetDetails>();
            var result = (BadRequestObjectResult) controller.PostAsset(null);
            //Assert
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void Check_If_Controller_Is_Posting_Assets_Successfully_And_Returns_True()
        {
           // Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            List<AssetDetails> assets=new List<AssetDetails>();
            mock.Setup(x => x.AddAsset(assets)).Returns(true);
            var result = (OkObjectResult)controller.PostAsset(assets);
           // Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void Check_If_Controller_Is_Posting_Assets_Unsuccessfully_And_Returns_False()
        {
            //Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            List<AssetDetails> assets = new List<AssetDetails>();
            mock.Setup(x => x.AddAsset(assets)).Returns(false);
            var result = (NotFoundObjectResult)controller.PostAsset(assets);
            //Assert
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public void Check_If_Controller_Is_Posting_Assets_Unsuccessfully_And_Throws_Exception()
        {
            //Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            List<AssetDetails> assets = new List<AssetDetails>();
            mock.Setup(x => x.AddAsset(assets)).Throws(new Exception());
            var result = (StatusCodeResult)controller.PostAsset(assets);
            //Assert
            Assert.Equal(500, result.StatusCode);
        }

        //PutRequest
        [Fact]
        public void Check_If_Controller_Is_Updating_A_Request_And_Returns_Bad_Request()
        {
            //Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            var result = (BadRequestObjectResult) controller.PutRequest(1, null);
            //Assert
            Assert.Equal(400, result.StatusCode);
        }
        [Fact]
        public void Check_If_Controller_Is_Updating_Request_Successfully_And_Returns_True()
        {
            //Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            RequestDetails request = new RequestDetails();
            mock.Setup(x => x.EditRequest(request.RequestId,request)).Returns(true);
            var result = (OkObjectResult) controller.PutRequest(request.RequestId, request);
            //Assert        
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void Check_If_Controller_Is_Updating_Request_Unsuccessfully_And_Returns_False()
        {
            //Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            RequestDetails request = new RequestDetails();
            mock.Setup(x => x.EditRequest(request.RequestId,request)).Returns(false);
            var result = (NotFoundObjectResult)controller.PutRequest(request.RequestId, request);
            //Assert        
            Assert.Equal(404, result.StatusCode);
        }
        [Fact]
        public void Check_If_Controller_Is_Updateing_Request_Unsuccessfully_And_Throws_Exception()
        {
            //Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            RequestDetails request = new RequestDetails();
            mock.Setup(x => x.EditRequest(request.RequestId,request)).Throws(new Exception());
            var result = (StatusCodeResult)controller.PutRequest(request.RequestId, request);
            //Assert        
            Assert.Equal(500, result.StatusCode);
        }
        //PutAsset
        [Fact]
        public void Check_If_Controller_Is_Updating_An_Asset_And_Returns_Bad_Request()
        {
            //Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            var result = (BadRequestObjectResult) controller.PutAsset(1, null);
            //Assert
            Assert.Equal(400, result.StatusCode);
        }
        [Fact]
        public void Check_If_Controller_Is_Updating_Asset_Successfully_And_Returns_True()
        {
            //Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            AssetDetails asset = new AssetDetails();
            mock.Setup(x => x.EditAssetById(asset.AssetId,asset)).Returns(true);
            var result = (OkObjectResult)controller.PutAsset(asset.AssetId,asset);
            //Assert        
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void Check_If_Controller_Is_Updating_An_Asset_Unsuccessfully_And_Returns_False()
        {
            //Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            AssetDetails asset = new AssetDetails();
            mock.Setup(x => x.EditAssetById(asset.AssetId, asset)).Returns(false);
            var result = (NotFoundObjectResult)controller.PutAsset(asset.AssetId, asset);
            //Assert        
            Assert.Equal(404, result.StatusCode);
        }
        [Fact]
        public void Check_If_Controller_Is_Updating_Request_Unsuccessfully_And_Throws_Exception()
        {
            //Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            AssetDetails asset = new AssetDetails();
            mock.Setup(x =>x.EditAssetById(asset.AssetId,asset)).Throws(new Exception());
            var result = (StatusCodeResult)controller.PutAsset(asset.AssetId, asset);
            //Assert        
            Assert.Equal(500, result.StatusCode);
        }
        //GetRejectedAssetList
        [Fact]
        public void Check_If_Controller_Is_Getting_List_Of_Asset_And_Returns_Bad_Request()
        {
            //Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            List<int> i = null;
            var result = (BadRequestObjectResult) controller.GetRejectedAssetList(i);
            //Assert
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void Check_If_Controller_Is_Getting_List_Of_Successfully_And_Returns_True()
        {
            //Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            List<AssetDetails> asset = new List<AssetDetails>();
            asset.Add(new AssetDetails(){AssetId = 1,AssetCode = 23,AssetStatus = status.Accepted, AssignToEmailId = "xyz@123", EmployeeDetails = null, EmployeeCode = 123, AssignedTo = 2, CapitalisationDate = "1/1/2000", CompanyCode = null, Description = "Laoptop", Location = "noida", Quantity = 1});
            List<int> i = new List<int>();
            mock.Setup(x => x.GetRejectedAssetListByEmpCode(i)).Returns(asset);
            var result = (OkObjectResult)controller.GetRejectedAssetList(i);
            //Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void Check_If_Controller_Is_Getting_List_Of_Asset_Unsuccessfully_And_Returns_False()
        {
            //Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            List<AssetDetails> asset = new List<AssetDetails>();
            List<int> i = new List<int>();
            mock.Setup(x => x.GetRejectedAssetListByEmpCode(i)).Returns(asset);
            var result = (NotFoundObjectResult)controller.GetRejectedAssetList(i);
            //Assert
            Assert.Equal(404, result.StatusCode);
        }
        [Fact]
        public void Check_If_Controller_Is_Getting_List_Of_Asset_Unsuccessfully_And_Throws_Exception()
        {
            //Arrange
            var mock = new Mock<ISupervisorService>();
            var controller = new SupervisorController(mock.Object);
            //Act
            AssetDetails asset = new AssetDetails();
            List<int> i = new List<int>();
            mock.Setup(x => x.EditAssetById(asset.AssetId, asset)).Throws(new Exception());
            var result = (StatusCodeResult)controller.GetRejectedAssetList(i);
            //Assert
            Assert.Equal(500, result.StatusCode);
        }
    }
}
  