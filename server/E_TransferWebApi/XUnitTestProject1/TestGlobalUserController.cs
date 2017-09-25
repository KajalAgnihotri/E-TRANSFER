using System;
using Xunit;
using Moq;
using E_TransferWebApi.Services;
using E_TransferWebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using E_TransferWebApi.Models;
using E_TransferWebApi.Repository;
using System.Collections.Generic;

namespace XUnitTestProject1
{
    public class TestGlobalUserController
    {
       [Fact]
        public void Check_If_Controller_Is_Getting_Not_Null() //1
        {
            //Arrange
            var mock = new Mock<IAssetAssignedUserService>();
            
            AssetAssignedUserController controller = new AssetAssignedUserController(mock.Object);
            //Act
            List<AssetDetails> request = new List<AssetDetails>();
            mock.Setup(x => x.GetAssetListByEmpcode(2)).Returns(request);
            var result = controller.Get(2);
            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void Check_If_Get_Method_Is_Throwing_Exception() //get exception-2
        {
            //Arrange
            var mock = new Mock<IAssetAssignedUserService>();
            AssetDetails asset = new AssetDetails();

            AssetAssignedUserController controller = new AssetAssignedUserController(mock.Object);
            //Act
            List<AssetDetails> request = new List<AssetDetails>();
            request = null;
            mock.Setup(x => x.GetAssetListByEmpcode(2)).Throws(new Exception());
            var result = controller.Get(2) as StatusCodeResult;
            //Assert
            Assert.Equal(500, result.StatusCode);
        }
        [Fact]
        public void Check_If_Get_Method_Is_Getting_Null() //get null-3
        {
            //Arrange
            var mock = new Mock<IAssetAssignedUserService>();
            AssetDetails asset = new AssetDetails();

            AssetAssignedUserController controller = new AssetAssignedUserController(mock.Object);
            //Act
            List<AssetDetails> request = new List<AssetDetails>();
            request = null;
            mock.Setup(x => x.GetAssetListByEmpcode(2));
            var result = controller.Get(2) as StatusCodeResult;
            //Assert
            Assert.Equal(204, result.StatusCode);
        }
        [Fact]
        public void Check_If_Put_Method_Should_Ok_Object_Result()//5
        {
            //Arrange
            var mock = new Mock<IAssetAssignedUserService>();
            AssetDetails asset = new AssetDetails();

            AssetAssignedUserController controller = new AssetAssignedUserController(mock.Object);
            //Act
            List<AssetDetails> request = new List<AssetDetails>();
            request = null;
            mock.Setup(x => x.UpdateAssetStatus(2,asset));
            var result = controller.Put(2,asset) as ObjectResult;
            //Assert
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public void Check_If_Put_Method_Is_Throwing_Exception() //5
        {
            //Arrange
            var mock = new Mock<IAssetAssignedUserService>();
            AssetDetails asset = new AssetDetails();

            AssetAssignedUserController controller = new AssetAssignedUserController(mock.Object);
            //Act
            List<AssetDetails> request = new List<AssetDetails>();
            request = null;
            mock.Setup(x => x.UpdateAssetStatus(2, asset)).Throws(new Exception());
            var result = controller.Put(2, asset) as StatusCodeResult;
            //Assert
            Assert.Equal(500, result.StatusCode);
        }
        
    }
}
