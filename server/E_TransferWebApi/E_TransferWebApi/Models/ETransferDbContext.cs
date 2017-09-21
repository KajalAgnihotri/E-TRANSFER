using Microsoft.EntityFrameworkCore;

namespace E_TransferWebApi.Models
{
    public class ETransferDbContext : DbContext
    {
        public ETransferDbContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<RequestDetails> RequestsInformation { get; set; }
        public DbSet<AssetDetails> AssetsInformation { get; set; }
        public DbSet<EmployeeDetails> EmployeeInformation { get; set; }
       
    }
}
