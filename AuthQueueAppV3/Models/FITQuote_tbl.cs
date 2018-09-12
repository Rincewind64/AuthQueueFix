using System;
using System.ComponentModel.DataAnnotations;

namespace AuthQueueAppV3.Models
{
    public class FITQuote_tbl
    {
        [Key]
        public Int32 QuoteNo { get; set; }
        public Int32 BkgNo { get; set; }
        public string AccountCode_Client { get; set; }
        public string OwUId { get; set; }
    }
}