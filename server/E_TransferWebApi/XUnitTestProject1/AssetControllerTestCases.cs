using System;
using Xunit;
using E_TransferWebApi.Services;
using E_TransferWebApi.Models;
using E_TransferWebApi.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace XUnitTestProject1
{
    public class AssetControllerTestCases
    {


        [Fact]       //First Test Case
        //Check on Asset Controller method that returns a list of Asset Details
        public void Check_if_GetRequestStatus_returns_a_list_of_AssetDetails()
        {
            //Arrange
            var mockService = new Mock<IAssetControllerService>();
            AssetDetails asset = new AssetDetails { AssetId = 1, AssetCode = 124, AssetStatus = 0, AssignedTo = 122, AssignToEmailId = "dssfcv" };
            List<AssetDetails> assetList = new List<AssetDetails>();
            assetList.Add(asset);
            mockService.Setup(x => x.GetRequestStatus()).Returns(assetList);
            AssetController obj = new AssetController(mockService.Object);

            //Act
            IActionResult result = obj.Get();
            var result2 = (OkObjectResult)result;

            Assert.Equal(200, result2.StatusCode);
            //Assert.NotNull(result);
            //Assert.IsType(typeof(List<AssetDetails>), result);

        }
        [Fact]       //Second Test Case
        //Check on Asset Controller method that does not returns a list of Asset Details
        public void Check_if_GetRequestStatus_does_not_returns_a_list_of_AssetDetails()
        {
            //Arrange
            var mockService = new Mock<IAssetControllerService>();
            AssetDetails asset = new AssetDetails { AssetId = 1, AssetCode = 124, AssetStatus = 0, AssignedTo = 122, AssignToEmailId = "dssfcv" };
            List<AssetDetails> list = new List<AssetDetails>();
            //list.Add(asset);
            mockService.Setup(x => x.GetRequestStatus()).Returns(list);
            AssetController obj = new AssetController(mockService.Object);

            //Act
            IActionResult result = obj.Get();
            var result2 = (NotFoundObjectResult)result;

            //Assert
            Assert.Equal(404, result2.StatusCode);

        }

        [Fact]              //Third test case
        public void Check_if_GetRequestStatus_returns_a_badrequest()
        {
            //Arrange
            var mockService = new Mock<IAssetControllerService>();
            mockService.Setup(x => x.GetRequestStatus()).Throws(new Exception());
            AssetController obj = new AssetController(mockService.Object);

            //Act
            IActionResult result = obj.Get();
            var result2 = result as StatusCodeResult;

            //Assert
            Assert.Equal(500, result2.StatusCode);
        }

        [Fact]        //Fourth Test Case

        public void Check_if_GetAssetDetailsByEmpCode_returns_a_list_of_AssetDetails()
        {
            //Arrange
            var mockService = new Mock<IAssetControllerService>();
            AssetDetails asset = new AssetDetails { AssetId = 1, AssetCode = 124, AssetStatus = 0, AssignedTo = 122, AssignToEmailId = "dssfcv" };
            List<AssetDetails> assetList = new List<AssetDetails>();
            assetList.Add(asset);

            mockService.Setup(x => x.GetAssetDetailsByEmpcode(asset.AssetId)).Returns(assetList);
            AssetController obj = new AssetController(mockService.Object);

            //Act
            IActionResult result = obj.Get(asset.AssetId);

            var result2 = result as OkObjectResult;

            Assert.Equal(200, result2.StatusCode);
            //Assert.Equal(assetList, result2.Value);
            //Assert.NotNull(result);
            //Assert.IsType(typeof(List<AssetDetails>), result);

        }

        [Fact]           //Fifth test case
        public void Check_if_GetAssetDetailsByEmpCode_does_not_returns_a_list_of_AssetDetails()
        {
            //Arrange
            var mockService = new Mock<IAssetControllerService>();
            AssetDetails asset = new AssetDetails { AssetId = 1, AssetCode = 124, AssetStatus = 0, AssignedTo = 122, AssignToEmailId = "dssfcv" };
            List<AssetDetails> list = new List<AssetDetails>();
            mockService.Setup(x => x.GetAssetDetailsByEmpcode(asset.AssetId)).Returns(list);//.Returns(It.IsAny<List<AssetDetails>>);
            AssetController obj = new AssetController(mockService.Object);

            //Act
            IActionResult result = obj.Get(asset.AssetId);
            var result1 = (NotFoundObjectResult)result;
            Assert.Equal(404, result1.StatusCode);
            //Assert.IsType(typeof(NotFoundObjectResult),result);
            // Assert.IsNotType(typeof(List<AssetDetails>), result);

        }

        [Fact]               //sixth Test Case
        public void Check_for_GettingAssetList_ByEmployeeCode_returns_a_badrequest()
        {
            //Arrange
            var mockService = new Mock<IAssetControllerService>();
            mockService.Setup(x => x.GetAssetDetailsByEmpcode(It.IsAny<int>())).Throws(new Exception());
            AssetController obj = new AssetController(mockService.Object);

            //Act
            IActionResult result = obj.Get(It.IsAny<int>());
            var result2 = (StatusCodeResult)result;

            //Assert
            Assert.Equal(500,result2.StatusCode);
          // Assert.IsType(typeof(BadRequestResult),result2);
        }

    }
}
