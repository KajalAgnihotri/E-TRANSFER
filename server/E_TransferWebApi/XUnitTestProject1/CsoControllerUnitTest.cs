using System;
using E_TransferWebApi.Controllers;
using E_TransferWebApi.Models;
using E_TransferWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject1
{
    public class CsoControllerUnitTest
    {
        [Fact]
        public void TestFor_GetAllPengingRequestByCso_ThatItReturns_NotFound_While_ListIsEmpty()
        {
            //Arrange
            List<RequestDetails> requestDetails = new List<RequestDetails>();
            var mockService = new Mock<ICsoService>();
            mockService.Setup(m => m.GetRequestPendingWithCso()).Returns(requestDetails);
            CsoController csoObj = new CsoController(mockService.Object);
            //Act
            var result = csoObj.GetPendingCsoRequest();
            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void TestFor_GetAllPengingRequestByCso_ThatItReturns_OkObjectResult_whenListExits()
        {
            //Arrange
            List<RequestDetails> requestDetails = new List<RequestDetails>();
            requestDetails.Add(new RequestDetails() { RequestId = 1, EmployeeCode = 2045 });
            var mockService = new Mock<ICsoService>();
            mockService.Setup(m => m.GetRequestPendingWithCso()).Returns(requestDetails);
            CsoController csoObj = new CsoController(mockService.Object);
            //Act
            var result = csoObj.GetPendingCsoRequest();
            //Assert
            Assert.IsType<OkObjectResult>(result);

        }
        [Fact]
        public void TestFor_GetAllPengingRequestByCso_ThatItReturns_500_While_It_ThrowsException()
        {
            //Arrange
            List<RequestDetails> requestDetails = new List<RequestDetails>();
           
            var mockService = new Mock<ICsoService>();
            mockService.Setup(m => m.GetRequestPendingWithCso()).Throws<Exception>();
            CsoController csoObj = new CsoController(mockService.Object);
            //Act
            var result = csoObj.GetPendingCsoRequest();
            //Assert
            Assert.Equal(500, (result as StatusCodeResult).StatusCode);

        }

        [Fact]
        public void TestFor_GetAssetDetailsByEmpcode_ThatItReturnsStatusCodeOnException()
        {
            //Arrange
            List<AssetDetails> assetDetails = new List<AssetDetails>();
            var mockService = new Mock<ICsoService>();
            mockService.Setup(m => m.GetAssetDetailsByEmpcode(It.IsAny<int>())).Throws<Exception>();
            CsoController csoObj = new CsoController(mockService.Object);
            //Act
            var result = csoObj.GetAssetDetails(It.IsAny<int>());
            result = (StatusCodeResult)result;
            //Assert

            Assert.IsType(typeof(StatusCodeResult), result);

        }
        [Fact]
        public void TestFor_GetAssetDetailsByEmpcode_ThatItReturnsCorrectList()
        {
            //Arrange
            List<AssetDetails> assets = new List<AssetDetails>();
            AssetDetails asset = new AssetDetails();

            var mockService = new Mock<ICsoService>();
            mockService.Setup(m => m.GetAssetDetailsByEmpcode(asset.EmployeeCode)).Returns(assets);
            CsoController csoObj = new CsoController(mockService.Object);
            //Act
            var result = csoObj.GetAssetDetails(asset.EmployeeCode);
            //Assert
            Assert.NotNull(result);

        }
        [Fact]
        public void TestFor_GetAssetDetailsByEmpcode_ThatItReturns_CorrectList_With_CorrectId()
        {
            //Arrange
            List<AssetDetails> assets = new List<AssetDetails>();
            assets.Add(new AssetDetails() { EmployeeCode = 1, AssetCode = 45 });
            

            var mockService = new Mock<ICsoService>();
            mockService.Setup(m => m.GetAssetDetailsByEmpcode(It.IsAny<int>())).Returns(assets);
            CsoController csoObj = new CsoController(mockService.Object);
            //Act
            var result = csoObj.GetAssetDetails(1);
            //Assert
            Assert.IsType<OkObjectResult>(result);

        }
        [Fact]
        public void TestToCheck_HttpResponseFor_GetAssetDetailsByEmpcode_DoesNotExist()
        {
            //Arrange
            List<AssetDetails> assetDetails = new List<AssetDetails>();
            var mockService = new Mock<ICsoService>();

            mockService.Setup(m => m.GetAssetDetailsByEmpcode(It.IsAny<int>())).Returns(assetDetails);
            CsoController csoObj = new CsoController(mockService.Object);
            //Act
            IActionResult result = csoObj.GetAssetDetails(It.IsAny<int>());
            //Assert

            Assert.IsType<NotFoundObjectResult>(result);
        }





        [Fact]
        public void TestToCheck_HttpResponseForCso_PutRequest()
        {
            //Arrange
            RequestDetails requestDetails = new RequestDetails();
            var mockService = new Mock<ICsoService>();
            mockService.Setup(m => m.UpdateRequest(It.IsAny<int>(), It.IsAny<RequestDetails>())).Returns(false);
            CsoController csoObj = new CsoController(mockService.Object);

            //Act
            var updateRequest = csoObj.Put(123, requestDetails);
          
            //Asset

           Assert.IsType(typeof(BadRequestResult), updateRequest);
            


        }
        [Fact]
        public void TestToCheck_HttpResponseForCso_PutRequest_When_Id_Exists()
        {
            //Arrange
            RequestDetails requestDetails = new RequestDetails() { EmployeeCode = 2, pendingWith=Pendingwith.CSO };
         
            var mockService = new Mock<ICsoService>();
            mockService.Setup(m => m.UpdateRequest(It.IsAny<int>(), It.IsAny<RequestDetails>())).Returns(true);
            CsoController csoObj = new CsoController(mockService.Object);

            //Act
            var updateRequest = csoObj.Put(2, requestDetails);
            updateRequest = (NoContentResult)updateRequest;
            //Asset

            Assert.IsType(typeof(NoContentResult), updateRequest);


        }

        [Fact]
        public void TestToCheck_HttpResponseForCso_PutRequest_For_NullArgumentException()
        {
            //Arrange
            RequestDetails requestDetails = new RequestDetails();
            var mockService = new Mock<ICsoService>();
            mockService.Setup(m => m.UpdateRequest(It.IsAny<int>(), It.IsAny<RequestDetails>())).Throws<ArgumentNullException>();
            CsoController csoObj = new CsoController(mockService.Object);

            //Act
            IActionResult updateRequest = csoObj.Put(1, requestDetails);
            updateRequest = (BadRequestResult)updateRequest;

            //Assert
            Assert.IsType(typeof(BadRequestResult), updateRequest);
            Assert.Equal(400, (updateRequest as BadRequestResult).StatusCode);



        }
        [Fact]
        public void TestToCheck_HttpResponseForCso_PutRequest_For_Exception()
        {
            //Arrange
            RequestDetails requestDetails = new RequestDetails();
            var mockService = new Mock<ICsoService>();
            mockService.Setup(m => m.UpdateRequest(It.IsAny<int>(), It.IsAny<RequestDetails>())).Throws<Exception>();
            CsoController csoObj = new CsoController(mockService.Object);

            //Act
            IActionResult updateRequest = csoObj.Put(1, requestDetails);
        

            //Assert
          
            Assert.Equal(500, (updateRequest as StatusCodeResult).StatusCode);



        }
        [Fact]
        public void TestToCheck_HttpResponseForCso_PutRequest_isNotNull()
        {
            //Arrange
            RequestDetails requestDetails = new RequestDetails();
            var mockService = new Mock<ICsoService>();
            mockService.Setup(m => m.UpdateRequest(It.IsAny<int>(), It.IsAny<RequestDetails>())).Returns(true);
            CsoController csoObj = new CsoController(mockService.Object);

            //Act
            var updateRequest = csoObj.Put(123, requestDetails);

            //Asset
            Assert.NotNull(updateRequest);

        }
    
    }
}
