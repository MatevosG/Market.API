using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAL.Models
{
    public class OparationModel
    {
        public OparationModel()
        {
            Operations = new List<OperationInfo>();
        }
        public List<OperationInfo> Operations { get; set; }
    }

    public class OperationInfo
    {
        public int ProductId { get; set; }
        public int ProductCount{ get; set; }
    }
}
