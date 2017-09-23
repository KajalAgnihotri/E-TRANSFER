using E_TransferWebApi.Models;
using E_TransferWebApi.Repository;
using E_TransferWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class AssetControllerServicesTestCases
    {

        [Fact]     //First Test Case
        public void Check_if_GetAllRequest_returns_a_list()
        {
            //Arrange
            var mockRepo = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            List<RequestDetails> reqList = new List<RequestDetails>();
            RequestDetails request = new RequestDetails { RequestId = 1 };
            reqList.Add(request);
            mockRepo.Setup(x => x.GetAllRequest()).Returns(reqList);
           
            AssetControllerService obj = new AssetControllerService(mockAssetRepo.Object,mockRepo.Object);

            //Act
            List<AssetDetails> result = obj.GetRequestStatus();

            //Assert
            Assert.IsType(typeof(List<AssetDetails>), result);

        }

        [Fact]         //Second Test case
        public void Check_if_GetAllRequest_returns_an_empty_list()
        {
            //Arrange
            var mockRepo = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            List<RequestDetails> list = new List<RequestDetails>();
            
            mockRepo.Setup(x => x.GetAllRequest()).Returns(list);
            AssetControllerService obj = new AssetControllerService(mockAssetRepo.Object,mockRepo.Object);

            //Act
            var result = obj.GetRequestStatus();

            //Assert
            Assert.IsNotType(typeof(List<RequestDetails>), result);
            Assert.Equal(0, list.Count);
        }

        [Fact]           //Third Test case
        public void Check_if_GetAllRequest_does_not_returns_an_empty_list()
        {
            //Arrange
            var mockRepo = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            List<RequestDetails> list = new List<RequestDetails>();
            mockRepo.Setup(x => x.GetAllRequest()).Returns(list);
            RequestDetails request = new RequestDetails { RequestId = 1 };
            list.Add(request);

            AssetControllerService obj = new AssetControllerService(mockAssetRepo.Object, mockRepo.Object);
           
            //Act
            var result = obj.GetRequestStatus();

            //Assert
            // Assert.IsNotType(typeof(List<AssetDetails>), result);
            Assert.Equal( 1, list.Count);
            
        }

        [Fact]            //Fourth Test Case
        public void Check_if_GetAssetDetailsByEmpCode_returns_a_list()
        {
            //Arrange
            var mockReqRepo = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            //List<RequestDetails> reqList = new List<RequestDetails>();
            //RequestDetails request = new RequestDetails { RequestId = 1 };
            AssetDetails asset = new AssetDetails { AssetId = 1, AssetCode = 124, AssetStatus = 0, AssignedTo = 122, AssignToEmailId = "dssfcv" };
            List<AssetDetails> assetList = new List<AssetDetails>();
           assetList.Add(asset);
            mockAssetRepo.Setup(x => x.GetAssetByEmpCode(asset.AssetId)).Returns(assetList);

            AssetControllerService obj = new AssetControllerService(mockAssetRepo.Object, mockReqRepo.Object);

            //Act
            List<AssetDetails> result = obj.GetAssetDetailsByEmpcode(asset.AssetId);

            //Assert
            Assert.IsType(typeof(List<AssetDetails>), result);
        }

        [Fact]                 //Fifth Test Case
        public void Check_if_GetAssetDetailsByEmpCode_returns_an_empty_list()
        {
            //Arrange
            var mockReqRepo = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            //List<RequestDetails> list = new List<RequestDetails>();
            AssetDetails asset = new AssetDetails { AssetId = 1, AssetCode = 124, AssetStatus = 0, AssignedTo = 122, AssignToEmailId = "dssfcv" };
            List<AssetDetails> assetList = new List<AssetDetails>();
            //assetList.Add(asset);
            mockAssetRepo.Setup(x => x.GetAssetByEmpCode(asset.AssetId)).Returns(assetList);
            AssetControllerService obj = new AssetControllerService(mockAssetRepo.Object, mockReqRepo.Object);

            //Act
            var result = obj.GetAssetDetailsByEmpcode(asset.AssetId);

            //Assert
            Assert.IsNotType(typeof(List<RequestDetails>), result);
            Assert.Equal(0, assetList.Count);
        }

        [Fact]            //Sixth Test Case
        public void Check_if_GetAssertDetailsByEmpCode_does_not_returns_an_empty_list()
        {
            //Arrange
            var mockReqRepo = new Mock<IRequestDetailsRepo>();
            var mockAssetRepo = new Mock<IAssetDetailsRepo>();
            //List<RequestDetails> list = new List<RequestDetails>();
            AssetDetails asset = new AssetDetails { AssetId = 1, AssetCode = 124, AssetStatus = 0, AssignedTo = 122, AssignToEmailId = "dssfcv" };
            List<AssetDetails> assetList = new List<AssetDetails>();
            assetList.Add(asset);
            mockAssetRepo.Setup(x => x.GetAssetByEmpCode(asset.AssetId)).Returns(assetList);
            
            AssetControllerService obj = new AssetControllerService(mockAssetRepo.Object, mockReqRepo.Object);

            //Act
            var result = obj.GetAssetDetailsByEmpcode(asset.AssetId);

            //Assert
            Assert.Equal(1, assetList.Count);

        }


    }
}
