using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthQueueAppV3.ViewModels
{
    public class FindBookingNumModel
    {
        [Required, Key]
        public Int32 QuoteNo { get; set; }
    }
}
