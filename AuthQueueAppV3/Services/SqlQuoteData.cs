using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthQueueAppV3.Data;
using AuthQueueAppV3.Models;
using StackExchange.Redis;
using Microsoft.EntityFrameworkCore;

namespace AuthQueueAppV3.Services
{
    public class SqlQuoteData : IQuoteData
    {
        private FITDbContext _context;
        private FITDbContext _context2;

        public SqlQuoteData(FITDbContext context)
        {
            _context = context; // dont need 2 contexts, this was done whilst trying to debug an issue, _context2 can be removed
            _context2 = context;
        }

        public FITQuote_tbl FoundQuote { get; private set; }

        public BkgActivityClient_tbl AuthQueueFix(int BkgNo, string AccountCode_Client, string OwUId)
        {
            var query2 = _context2.BkgActivityClient_tbl.FirstOrDefault(r => r.BkgNo == BkgNo);

            if (query2 == null)
            {

                BkgActivityClient_tbl BAC = new BkgActivityClient_tbl
                {
                    BkgNo = BkgNo,
                    Client_Code_Profile = AccountCode_Client,
                    ActivityCode = 13,
                    ActivityDesc = "Authorization",
		            NoOfDaysRqd = 0,
                    RefFrom = "CF",
		            RefDaysOffset = 0,
		            SerialNo = 99,
		            ToDoJobCode = String.Empty,
		            DueDate = DateTime.Now,
		            StartDate = null,
		            Notes = String.Empty,
		            CrUId = OwUId,
		            CrDate = DateTime.Today,
		            CrTime = DateTime.Now,
		            FrzInd = false,
		            UpdUId = "SUPRAS",
		            UpdDate = DateTime.Today,
		            UpdTime = DateTime.Now,
		            UpdPlace = "ABTN",
		            DoneInd = true,
		            DoneUId = "SUPRAS",
		            DoneDateTime = DateTime.Now,
		            SubmitInd = true,
		            SubmitCount = 0,
		            JobDone = false
               };
                try
                {
                    _context2.BkgActivityClient_tbl.Add(BAC);
                    _context2.SaveChanges();
                }
                catch
                {
                  throw new NotImplementedException();
                }
                return BAC;
            }

            else
            {
                query2.DoneInd = true;
                query2.SubmitInd = true;
                query2.ActivityCode = 13;
                query2.ActivityDesc = "Authorization";
                query2.UpdDate = DateTime.Now;
                query2.UpdTime = DateTime.Now;
                query2.UpdUId = "SUPRAS";
                query2.DoneUId = "SUPRAS";
                query2.DoneDateTime = DateTime.Now;

                _context.SaveChanges();
                return query2;
            }
        }

        public FITQuote_tbl Get(int QuoteNo)
        {
            var query = _context.FITQuote_tbl.Where(quote => quote.QuoteNo == QuoteNo);
            FoundQuote = query.First();
            return FoundQuote;
        }

        public FITQuote_tbl FindBookingNum(int QuoteNo)
        {
            var query = _context.FITQuote_tbl.FirstOrDefault(r => r.QuoteNo == QuoteNo);
            return query;
        }
    }
}

