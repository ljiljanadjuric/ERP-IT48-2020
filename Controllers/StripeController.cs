using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProdavnicaObuce.Interface;
using ProdavnicaObuce.UnitOfWorkConfig;
using Stripe;
using Stripe.Checkout;

namespace ProdavnicaObuce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IUnitOfWork unitOfWork;

        public StripeController(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            this.configuration = configuration;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("webhook")]
        public async Task<ActionResult> StripeWebhook()
        {
            var json = await new StreamReader(Request.Body).ReadToEndAsync();
            var stripeEvent = EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"], "whsec_aed053f741f47b2d95d822e9ca501c278efaec8666f762a7de171f36016491e6");

            Session session;

            switch (stripeEvent.Type)
            {
                case "checkout.session.completed":
                    session = (Session)stripeEvent.Data.Object;
                    var orderId = Convert.ToInt32(session.Metadata["order_id"]);
                    var prodaja = await unitOfWork.Prodaje.GetById(orderId);
                    prodaja.Placeno = true;
                    await unitOfWork.Save();
                    break;

                case "payment_intent.payment_failed":
                    session = (Session)stripeEvent.Data.Object;
                    break;
            }
            return new EmptyResult();
        }
    }
}
