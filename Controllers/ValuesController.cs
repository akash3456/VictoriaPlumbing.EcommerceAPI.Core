using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VictoriaPlumbing.EcommerceAPI.Core.Validators;

namespace VictoriaPlumbing.EcommerceAPI.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly OrderValidator orderValidator;
        public ValuesController(OrderValidator orderValidator)
        {
            
            this.orderValidator = orderValidator;
        }

        [HttpPost]
        public ActionResult Test()
        {
            return Ok();
        }
    }
}
