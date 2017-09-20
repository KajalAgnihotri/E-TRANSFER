using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_TransferWebApi.Models
{
    public enum Requeststatus
    {
        Cleared,
        Pending
    }
    public enum Pendingwith
    {
        Supervisor,
        HR,
        User,
        CSO,
        Approved
    }
    public class RequestDetails
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId { get; set; }
        public int EmployeeCode { get; set; }
        [ForeignKey("EmployeeCode")]
        public EmployeeDetails EmployeeDetails { get; set; }
        public int SupervisorCode { get; set; }
        public string TypeOfRequest { get; set; }
        public string Newpacode { get; set; }
        public string Newpsacode { get; set; }
        public string NewOucode { get; set; }
        public string NewCcCode { get; set; }
        public DateTime DateOfRequest { get; set; }
        [EnumDataType(typeof(Requeststatus))]
        [JsonConverter(typeof(StringEnumConverter))]
        public Requeststatus RequestStatus { get; set; }
        [EnumDataType(typeof(Pendingwith))]
        [JsonConverter(typeof(StringEnumConverter))]
        public Pendingwith pendingWith { get; set; }
    }
}
