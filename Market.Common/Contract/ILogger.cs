using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Common.Contract
{
    public interface ILogger
    {
        void LogInfo(string message);
        void LogError(Exception ex);
        void LogError(string message);
    }
}
