using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication1.Models;
using System.Data.Entity;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    
    public class BoardNoticeController : ApiController
    {
        private Entities db = new Entities();

        [HttpGet]
        public async Task<IHttpActionResult> GetBoardList()
        {
            var result = db.BOARD_NOTICE.Select(p => p).ToList();

            //var query = "SELECT * FROM BOARD_NOTE";
            
            //var queryResult = db.Database.SqlQuery(query.ToString(), new SqlParameter());

            return Ok(result);
        }


        [HttpPost]
        public async Task<IHttpActionResult> SaveBoardNote(BOARD_NOTICE boardNotice)
        {
            var idx = db.BOARD_NOTICE.Max(p => p.BOARD_IDX);

            idx = (idx == null) ? 0 : idx + 1;

            boardNotice.BOARD_IDX = idx;
            boardNotice.WDATE = DateTime.Now.ToString("yyyyMMdd");
            boardNotice.E_BUKRS = "KR02";
            boardNotice.E_WERKS = "TA10";

            db.BOARD_NOTICE.Add(boardNotice);
            db.SaveChanges();

            return Ok();
        }

    }
}