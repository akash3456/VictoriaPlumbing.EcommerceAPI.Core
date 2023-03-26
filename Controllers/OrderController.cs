using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VictoriaPlumbing.EcommerceAPI.Core.Delegates;
using VictoriaPlumbing.EcommerceAPI.Core.Interfaces;
using VictoriaPlumbing.EcommerceAPI.Core.Validators;

namespace VictoriaPlumbing.EcommerceAPI.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly OrderValidator _orderValidator;
        private readonly ValidateDelegate _validate;
        private readonly IOrderConfirmedHandler _orderConfirmedHandler;

        public OrderController(ILogger<OrderController> logger, OrderValidator orderValidator, IOrderConfirmedHandler orderConfirmed, ValidateDelegate validate)
        {
            _logger = logger;
            _orderValidator = orderValidator;
            _orderConfirmedHandler = orderConfirmed;
            _validate = validate;
        }

        //the reason i went with the handler approach

        [HttpPost]
        public ActionResult Post([FromBody] Order order)
        {
            var validationResult = _validate(order);

            if (!validationResult.Result)
            {
                //perhaps log the info here too.
                return BadRequest(validationResult.Messages[0]);
            }

            var handleResult = _orderConfirmedHandler.Handle(order);
            return handleResult.IsSuccess ? Ok() : BadRequest(handleResult.Message);
        }
    }
}
