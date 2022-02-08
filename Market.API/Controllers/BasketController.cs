using Market.API.Filters;
using Market.BL.Contracts;
using Market.Common.Contract;
using Market.DAL.Models;
using Newtonsoft.Json;
using System;
using System.Web.Http;

namespace Market.API.Controllers
{
    public class BasketController : ApiController
    {
        private ISellService _sellService;
        private ILogger _loger;
        public BasketController(ISellService sellService,ILogger logger)
        {
            _sellService = sellService;
            _loger = logger;
        }

        [HttpPost]
        [ModelValidator]
        [Route("Basket/Sell")]
        public IHttpActionResult Sell([FromBody] OparationModel model)
        {
            try
            {
                return Ok(_sellService.Sell(model));
            }
            catch (Exception ex)
            {
                _loger.LogError(ex);
                return BadRequest("lav ban chi exel");
            }
        }
        public IHttpActionResult Get()
        {
            TimeIntervalModel model = new TimeIntervalModel();
            model.EndTime = DateTime.UtcNow;
            model.StartTime = DateTime.UtcNow.AddDays(-5);
            string data = JsonConvert.SerializeObject(model);
            return Ok();
        }
    }
}
