using DrinkDiscovery_Revised.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using NuGet.Protocol.Core.Types;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Claims;

namespace DrinkDiscovery_Revised.Controllers
{
    public class PaymentController : Controller
    {
        private IRepository repository;
        public PaymentController(IRepository _repository)
        {
            repository = _repository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public string getLoginedUser()
        {
            return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
        }

        

        [HttpGet]
        public IActionResult ConfirmAddress()
        {
            // adresi onaylat. viewde ise ödeme kısmı gösterilecek
            // order id, amount gibi bilgiler  gerekiyor
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> ConfirmAddress(Order order)
        {
            var user = getLoginedUser();
            int orderid = order.OrderId;
            var currentorder = repository.Order.SingleOrDefault(o => o.UserId == user && o.OrderId == orderid);
            currentorder.Email = order.Email;
            currentorder.OrderDeliveryAddress = order.OrderDeliveryAddress;
            currentorder.PhoneNumber = order.PhoneNumber;
            currentorder.OrderPaymentMethod = order.OrderPaymentMethod;
            currentorder.OrderPaymentStatus = "pending";
            currentorder.OrderStatus = "preparing";

            await repository.UpdateAsync(currentorder);
            TempData["OrderId"] = orderid;

            return RedirectToAction("ConfirmPayment",currentorder);
        }

        [HttpGet]
        public IActionResult ConfirmPayment()
        {
            // ödeme sayfası
            
            return View();
        }

        public Order getCurrentOrderInformations()
        {
            var order = ViewBag.Order;
            return order;
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmPayment(Payment payment)
        {
            var user = getLoginedUser();
            int orderid = Convert.ToInt32(TempData["OrderId"]);
            var order = repository.Order.SingleOrDefault(o => o.UserId == user && o.OrderId == orderid);
            var orderprice = order?.OrderTotalPrice;
            payment.OrderId = order.OrderId;
            payment.PaymentAmount = (float)orderprice;
            payment.PaymentUserId = user;
            payment.PaymentDate = DateTime.Now;
            payment.PaymentConfirmation = false;
            payment.PaymentStatus = "pending";
            payment.PaymentMethod = "Kredi Kartı";
            payment.OrderIdFk = order.OrderId;
            await repository.AddAsync(payment);
            await repository.SaveChangesAsync();

            return RedirectToAction("PaymentResult");
        }

        [HttpGet]
        public IActionResult PaymentResult()
        {
            return View();
        }

    }
}
