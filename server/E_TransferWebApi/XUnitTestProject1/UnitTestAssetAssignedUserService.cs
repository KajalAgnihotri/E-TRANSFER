using Xunit;
using Moq;
using E_TransferWebApi.Services;
using E_TransferWebApi.Models;
using E_TransferWebApi.Repository;
using System.Collections.Generic;

namespace XUnitTestProject1
{
   public class UnitTestAssetAssignedUserService
    {
        [Fact]
        public void Check_If_GetAssetListByEmpcode_returning_empty() //5-service
        {
            List<AssetDetails> request = new List<AssetDetails>();
           
            var mockRepo = new Mock<IAssetDetailsRepo>();
          
            mockRepo.Setup(x => x.GetAllAsset()).Returns(request);
            AssetAssignedUserService obj = new AssetAssignedUserService(mockRepo.Object);
            var res = obj.GetAssetListByEmpcode(6);
    
            Assert.NotNull(res);
            Assert.IsType<List<AssetDetails>>(res);
           Assert.Equal(request, res);
           
        }
        

        }
}
