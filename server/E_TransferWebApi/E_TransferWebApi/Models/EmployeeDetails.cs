using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_TransferWebApi.Models
{
    public class EmployeeDetails
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmailId { get; set; }
        public string Location { get; set; }
        public string LocalHR { get; set; }
        public string LocalCSO { get; set; }
        public string Designation { get; set; }
        public int Supervisor { get; set; }
        public string SupervisorName { get; set; }
        public string SupervisorEmailId { get; set; }
        public string CompanyCode { get; set; }
        public string pacode { get; set; }
        public string psacode { get; set; }
        public string Oucode { get; set; }
        public string CcCode { get; set; }
        public DateTime DateOfTransfer { get; set; }
        public List<AssetDetails> AssetList { get; set; }
    }
}
