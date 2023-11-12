using IyzicoPaymentApp.Services;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Mvc;

namespace IyzicoPaymentApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IPaymentService _paymentService;

        public OrderController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(string? cartId)
        {
            Payment payment = _paymentService.PaymentIyzico();

            if (payment.Status != "success")
            {
                TempData["error"] = "Error";
                return View();
            }
            TempData["success"] = "Success";
            return RedirectToAction("Index", "Home");
        }
    }
}
