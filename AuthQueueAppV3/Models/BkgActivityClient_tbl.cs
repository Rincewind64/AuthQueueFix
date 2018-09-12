using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthQueueAppV3.Models
{
    public class BkgActivityClient_tbl
    {
        [Key]
        public Int32 SeqNo { get; set; }

        public Int32 BkgNo { get; set; }

        public string Client_Code_Profile { get; set; }

        public Int16 ActivityCode { get; set; }

        public string ActivityDesc { get; set; }

        public Int16 NoOfDaysRqd { get; set; }

        public string RefFrom { get; set; }

        public Int16 RefDaysOffset { get; set; }

        public Int16 SerialNo { get; set; }

        public string ToDoJobCode { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DueDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? StartDate { get; set; }

        public string Notes { get; set; }

        public string CrUId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CrDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CrTime { get; set; }

        public Boolean FrzInd { get; set; }

        public string UpdUId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? UpdDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? UpdTime { get; set; }

        public string UpdPlace { get; set; }

        public Boolean DoneInd { get; set; }

        public string DoneUId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DoneDateTime { get; set; }

        public Boolean SubmitInd { get; set; }

        public Int16 SubmitCount { get; set; }

        public Boolean JobDone { get; set; }
    }
}
