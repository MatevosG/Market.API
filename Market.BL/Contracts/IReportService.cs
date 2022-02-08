using Market.DAL.Entities;
using Market.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BL.Contracts
{
    public interface IReportService
    {
      
        ReportModel GetReport(DateTime startTime, DateTime endTime);
        ReportModel GetGroupedReport(DateTime startTime, DateTime endTime);
    }
}
