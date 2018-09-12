using AuthQueueAppV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthQueueAppV3.Services
{
    public interface IQuoteData
    {
        FITQuote_tbl Get(Int32 QuoteNo);
        BkgActivityClient_tbl AuthQueueFix(Int32 BkgNo, string AccountCode_Client, string OwUId);
        FITQuote_tbl FindBookingNum(Int32 QuoteNo);
    }
}
