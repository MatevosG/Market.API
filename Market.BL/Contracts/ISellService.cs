using Market.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BL.Contracts
{
    public interface ISellService
    {
        bool Sell(OparationModel model);
    }
}
