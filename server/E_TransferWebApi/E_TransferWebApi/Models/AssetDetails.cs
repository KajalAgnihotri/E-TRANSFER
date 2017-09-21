using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_TransferWebApi.Models
{
    public enum status
    {
        Pending,
        Accepted,
        Rejected
    }
    public class AssetDetails
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssetId { get; set; }
        public int AssetCode { get; set; }
        public int EmployeeCode { get; set; }
        [ForeignKey("EmployeeCode")]
        public EmployeeDetails EmployeeDetails { get; set; }
        public string CompanyCode { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }
        public string CapitalisationDate { get; set; }
        [EnumDataType(typeof(status))]
        [JsonConverter(typeof(StringEnumConverter))]
        public status AssetStatus { get; set; }
        public int AssignedTo { get; set; }
        public string AssignToEmailId { get; set; }
    }
}
