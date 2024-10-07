using DrinkDiscovery_Revised.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Identity.Client;
using NuGet.Packaging.Signing;
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
        
        

        [HttpGet]
        public IActionResult ConfirmPayment()
        {
            // ödeme sayfası
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmAddress(Order order)
        {
            // Check if essential order information is missing
            if (string.IsNullOrEmpty(order.Email) ||
                string.IsNullOrEmpty(order.OrderDeliveryAddress) ||
                string.IsNullOrEmpty(order.PhoneNumber) ||
                string.IsNullOrEmpty(order.OrderPaymentMethod))
            {
                // Return a view indicating that some required information is missing
                ModelState.AddModelError("", "All required fields must be filled.");
                var orderitems = repository.OrderItem.Where(o => o.OrderId == order.OrderId);
                
                for(int i = 0; i < orderitems.Count(); i++)
                {
                    repository.Delete(orderitems.ElementAt(i));
                }
                repository.Delete(order);
                
                return RedirectToAction("Index","Home");  // Return to the same view and show validation errors
            }

            // Kullanıcıyı oturumdan al
            var user = getLoginedUser();

            if (user == null)
            {
                // Eğer kullanıcı oturumu yoksa login sayfasına yönlendir
                return RedirectToAction("Login", "Account");
            }

            // Siparişin olup olmadığını kontrol et
            int orderId = order.OrderId;
            var currentOrder = await repository.Order.SingleOrDefaultAsync(o => o.UserId == user && o.OrderId == orderId);

            if (currentOrder == null)
            {
                // Sipariş bulunamazsa 404 not found döndür
                return NotFound();
            }

            // Sipariş bilgilerini güncelle
            currentOrder.Email = order.Email;
            currentOrder.OrderDeliveryAddress = order.OrderDeliveryAddress;
            currentOrder.PhoneNumber = order.PhoneNumber;
            currentOrder.OrderPaymentMethod = order.OrderPaymentMethod;
            currentOrder.OrderPaymentStatus = "pending"; // Ödeme durumu "pending" olarak ayarlanıyor
            currentOrder.OrderStatus = "preparing";      // Sipariş durumu "preparing" olarak ayarlanıyor

            // Değişiklikleri kaydet
            await repository.UpdateAsync(currentOrder);

            // TempData'ya orderId ekle
            TempData["OrderId"] = orderId;

            // Ödeme sayfasına yönlendir
            return RedirectToAction("ConfirmPayment", new { orderId = currentOrder.OrderId });
        }




        [HttpPost]
        public async Task<IActionResult> ConfirmPayment(Payment payment)
        {
            // Check if essential payment information is missing
            if (string.IsNullOrEmpty(payment.PaymentCardNumber) ||
                string.IsNullOrEmpty(payment.PaymentCartHolderName) ||
                string.IsNullOrEmpty(payment.PaymentCardExpiryDate) ||
                string.IsNullOrEmpty(payment.PaymentCardCvv))
            {
                // Return a view indicating that some required information is missing
                ModelState.AddModelError("", "All required fields must be filled.");
                int paymentorderid = payment.OrderId;
                var paymentorder = repository.Order.SingleOrDefault(o => o.OrderId == paymentorderid);
                var orderitems = repository.OrderItem.Where(o => o.OrderId == paymentorderid);
                for (int i = 0; i < orderitems.Count(); i++)
                {
                    repository.Delete(orderitems.ElementAt(i));
                }
                repository.Delete(payment);
                repository.Delete(paymentorder);
                return View(payment);  // Return to the same view and show validation errors
            }

            var user = getLoginedUser();

            // Retrieve the order ID from TempData
            int orderid = Convert.ToInt32(TempData["OrderId"]);

            // Fetch the existing order using the order ID and user
            var order = repository.Order.SingleOrDefault(o => o.UserId == user && o.OrderId == orderid);

            if (order != null)
            {
                // Update the payment details
                payment.OrderId = order.OrderId;
                payment.PaymentAmount = (float)order.OrderTotalPrice;
                payment.PaymentUserId = user;
                payment.PaymentDate = DateTime.Now;
                payment.PaymentConfirmation = false;  // Default to false until confirmed
                payment.PaymentStatus = "pending";    // Default status
                payment.PaymentMethod = payment.PaymentMethod ?? "Kredi Kartı";  // Default to credit card if not set
                payment.OrderIdFk = order.OrderId;    // Foreign key to the order

                // Add the payment record
                await repository.AddAsync(payment);
            }

            // Save all changes, including payment and order details
            ViewData["payment"] = payment;
            ViewData["order"] = order;
            ViewBag.OrderItems = repository.OrderItem.Where(o => o.OrderId == orderid).ToList();
            await repository.SaveChangesAsync();

            return RedirectToAction("PaymentResult");
        }


        [HttpGet]
        public IActionResult PaymentResult()
        {
            // payment confirmation via email with order details
            var user = getLoginedUser();
            var ordersummary = getInfos(user);
            ViewBag.OrderSummary = ordersummary;
            //ViewBag.UserId = user;

            return View();
        }

        

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteIncompleteOrder(int orderId)
        {
            var order = repository.Order.FirstOrDefault(o=> o.OrderId == orderId);

            if (order != null && order.OrderState == "in-address")
            {
                repository.Delete(order);
                await repository.SaveChangesAsync();
                return Ok(new { success = true }); // Return success response
            }

            return BadRequest(new { success = false, message = "Order not found or invalid state." });
        }

        public Dictionary<int, Dictionary<string, string>> getInfos(string userid)
        {
            // Fetch all products
            var urunler = repository.Urunler.ToList();
            
            var payment = repository.Payment.SingleOrDefault(o => o.PaymentUserId == userid && o.PaymentConfirmation == false);
            var paymentorderid = payment.OrderId;
            var paymentorder = repository.Order.SingleOrDefault(o => o.UserId == userid && o.OrderId == paymentorderid);
            var orderitems = repository.OrderItem.Where(o => o.OrderId == paymentorderid);
            // Fetch the shopping cards for the given userid
            

            // Create a dictionary where the key is ProductId and the value is a dictionary with product information
            Dictionary<int, Dictionary<string, string>> productInformations = new Dictionary<int, Dictionary<string, string>>();

            foreach (var item in orderitems)
            {
                // Find the product by ProductId
                var product = urunler.FirstOrDefault(p => p.UrunId == item.OrderProductId);

                if (product != null)
                {
                    // Create a dictionary to store product information
                    Dictionary<string, string> productInfo = new Dictionary<string, string>
            {
                { "UrunAd", product.UrunAd }, // Product Name
                { "UrunFiyat", product.UrunFiyat.ToString() }, // Product Price
                { "Count", item.OrderQuantity.ToString() } // Quantity in the shopping card
            };

                    // Add the product information to the main dictionary with ProductId as the key
                    productInformations[item.OrderProductId] = productInfo;
                }
            }

            return productInformations;
        }

        public IActionResult ViewMyOrders()
        {
            var userid = getLoginedUser();
            var paymentinfos = repository.Payment.Where(o => o.PaymentConfirmation == true 
            && o.PaymentUserId == userid).ToList();
            var orderinfos = new List<Order>();
            foreach (var payment in paymentinfos)
            {
                var order = repository.Order.SingleOrDefault(o => o.OrderId == payment.OrderId);
                orderinfos.Add(order);
            }
            ViewBag.OrderInfos = orderinfos;

            return View();
        }

        

        

        

        
        public async Task<IActionResult> CancellingOrder(int orderId)
        {
            var payment = repository.Payment.SingleOrDefault(o => o.OrderId == orderId);
            var order = repository.Order.SingleOrDefault(o => o.OrderId == orderId);
            var orderitems = repository.OrderItem.Where(o => o.OrderId == orderId);
            if (payment != null && order != null)
            {
                repository.DeleteAsync(payment);
                repository.DeleteAsync(order);
                foreach (var item in orderitems)
                {
                    repository.DeleteAsync(item);
                }
            }

            await repository.SaveChangesAsync();
            return RedirectToAction("ViewMyOrders");
        }

        [HttpGet]
        public IActionResult ViewOrderDetails(int orderId)
        {
            var order = repository.Order.Where(o => o.OrderId == orderId).ToList();
            var orderitems = repository.OrderItem.Where(o => o.OrderId == orderId).ToList();
            var productinfooforderitems = new List<Urunler>();
            foreach (var item in orderitems)
            {
                productinfooforderitems.Add(repository.Urunler.Include(o=> o.UrunKategori).SingleOrDefault(o => o.UrunId == item.OrderProductId));
            }
            var products = repository.Urunler.ToList();

            

            ViewBag.Products = productinfooforderitems;
            ViewBag.OrderItems = orderitems;
            ViewBag.Order = order;

            

            return View();
        }

        class product
        {
            public int UrunId { get; set; }
            public string UrunAd { get; set; }
            public float UrunFiyat { get; set; }
            public string UrunKategoriId { get; set; }

        }
    }
}
