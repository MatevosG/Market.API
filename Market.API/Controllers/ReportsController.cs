using Market.API.Filters;
using Market.BL.Contracts;
using Market.Common.Contract;
using Market.Common.Helpers;
using Market.DAL.Models;
using System;
using System.Web.Http;

namespace Market.API.Controllers
{
    [CustomAuthorization]
    public class ReportsController : ApiController
    {
        private ILogger _loger ;
        private IReportService _reportService;

        public ReportsController(IReportService reportService, ILogger logger)
        {
            _reportService = reportService;
            _loger = logger;
        }
       
        [HttpPost]
        [ModelValidator]
        [Route("Reports/GetReportByTime")]
        public IHttpActionResult GetReportByTime([FromBody] TimeIntervalModel timeIntervalModel)
        {
            try
            {
                return Ok(_reportService.GetReport(timeIntervalModel.StartTime, timeIntervalModel.EndTime));
            }
            catch (Exception ex)
            {
                _loger.LogError(ex);
                return BadRequest();
            }
        }
        [HttpPost]
        [ModelValidator]
        [Route("Reports/GetGroupedReportByTime")]
        public IHttpActionResult GetGroupedReportByTime([FromBody] TimeIntervalModel timeIntervalModel)
        {
            try
            {
                return Ok(_reportService.GetGroupedReport(timeIntervalModel.StartTime, timeIntervalModel.EndTime));
            }
            catch (Exception ex)
            {
                _loger.LogError(ex);
                return BadRequest();
            }
        }
    }
}
