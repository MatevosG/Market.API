using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAL.Models
{
    public class ReportModel
    {
        public ReportModel()
        {
            Products = new List<ReportInfoModel>();
        }
        public double Summary { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<ReportInfoModel> Products { get; set; }
    }

    public class ReportInfoModel
    {
        public string ProductName { get; set; }
        public int ProductCount { get; set; }
        public double ProductPrice { get; set; }
    }
}
