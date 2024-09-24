using DrinkDiscovery_Revised.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace DrinkDiscovery_Revised.Controllers
{
    public class ProductCardController : Controller
    {
        public IRepository repository;
        public ProductCardController(IRepository _repository)
        {
            repository= _repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        //public List<Dictionary<string, string>> ProductInformationsInCard(string userid)
        //{
        //    var urunler = repository.Urunler.ToList();

        //}
        public Dictionary<int, Dictionary<string, string>> getInfos(string userid)
        {
            // Fetch all products
            var urunler = repository.Urunler.ToList();

            // Fetch the shopping cards for the given userid
            var shoppingcards = repository.ShoppingCard
                .Where(c => c.UserId == userid)
                .ToList();

            // Create a dictionary where the key is ProductId and the value is a dictionary with product information
            Dictionary<int, Dictionary<string, string>> productInformations = new Dictionary<int, Dictionary<string, string>>();

            foreach (var card in shoppingcards)
            {
                // Find the product by ProductId
                var product = urunler.FirstOrDefault(p => p.UrunId == card.ProductId);

                if (product != null)
                {
                    // Create a dictionary to store product information
                    Dictionary<string, string> productInfo = new Dictionary<string, string>
            {
                { "UrunAd", product.UrunAd }, // Product Name
                { "UrunFiyat", product.UrunFiyat.ToString() }, // Product Price
                { "Count", card.Count.ToString() } // Quantity in the shopping card
            };

                    // Add the product information to the main dictionary with ProductId as the key
                    productInformations[card.ProductId] = productInfo;
                }
            }

            return productInformations;
        }


        [HttpGet]
        public IActionResult ViewCard()
        {
            string userid = LoginedUserId();
            // Call getInfos to retrieve product information
            var productInformations = getInfos(userid);

            // Fetch the shopping cards for the given userid (this logic remains here)
            var shoppingcards = repository.ShoppingCard
                .Where(c => c.UserId == userid)
                .ToList();

            // Pass the product information to the view using ViewBag
            ViewBag.ProductInformations = productInformations;

            // Return the view along with the shopping cards list
            return View(shoppingcards);
        }


        public string LoginedUserId()
        {
            return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
        }
        public IActionResult GetImage(int id)
        {
            //var urun = repository.Urunler.FirstOrDefault(i => i.UrunId == id);
            var cardphoto = repository.Urunler.FirstOrDefault(i => i.UrunId == id);
            if (cardphoto != null && cardphoto.UrunResim != null)
            {
                return File(cardphoto.UrunResim, "image/jpeg");
            }
            return NotFound();
        }

        public IActionResult CreateCard(int urunId)
        {
            if (User.Identity.IsAuthenticated)
            {
                string logineduserid = LoginedUserId();

                // Check if product exists
                var selectedproduct = repository.Urunler
                    .FirstOrDefault(p => p.UrunId == urunId);

                if (selectedproduct == null)
                {
                    // Handle case where product does not exist
                    ModelState.AddModelError("Error", "Ürün bulunamadı.");
                    return RedirectToAction("IndexUrunler", "Home");
                }

                // Create a new ShoppingCard object
                ShoppingCard card = new ShoppingCard
                {
                    UserId = logineduserid,
                    ProductId = urunId,
                    Count = 1
                };

                // Set category if it exists
                if (selectedproduct.UrunKategoriId.HasValue)
                {
                    card.CategoryId = selectedproduct.UrunKategoriId.Value;
                }

                // Check if the product is already in the user's shopping cart
                var existcard = repository.ShoppingCard
                    .FirstOrDefault(c => c.UserId == logineduserid && c.ProductId == urunId);

                // If the product is not in the cart, add it
                if (existcard == null)
                {
                    repository.Add(card);
                    repository.SaveChanges();
                    return RedirectToAction("ViewCard");
                }
                else
                {
                    // If the product is already in the cart, show an error message
                    ModelState.AddModelError("Error", "Bu ürün zaten sepetinizde bulunmaktadır.");

                    // Instead of redirecting, return the same view so the error can be displayed
                    var urunler = repository.Urunler.ToList(); // Make sure to get the products for the view
                    ViewBag.Urunler = urunler;
                    return RedirectToAction("IndexUrunler","Home", urunler);
                }
            }
            else
            {
                // If the user is not logged in, redirect to the login page
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
        }


        public IActionResult IncreaseCount(int id)
        {
            var card = repository.ShoppingCard.FirstOrDefault(c => c.ProductId == id);
            if (card != null)
            {
                int count = card.Count;
                count++;
                card.Count = count;
                repository.Update(card);
                repository.SaveChanges();
            }
            return RedirectToAction("ViewCard");
        }
        public IActionResult DecreaseCount(int id)
        {
            var card = repository.ShoppingCard.FirstOrDefault(c => c.ProductId == id);
            if (card != null)
            {
                int count = card.Count;
                count--;
                if(count == 0)
                {
                   // sepetten çıkar
                   // sepetten çıkarmak istediğinize emin misiniz diye sor ?

                   repository.Delete(card);
                   repository.SaveChanges();
                }
                else
                {
                    card.Count = count;
                    repository.Update(card);
                    repository.SaveChanges();
                }
                
            }
            return RedirectToAction("ViewCard");
        }

        public IActionResult DeleteCard(int id)
        {
            var card = repository.ShoppingCard.FirstOrDefault(c => c.ProductId == id);
            if (card != null)
            {
                repository.Delete(card);
                repository.SaveChanges();
            }
            return RedirectToAction("ViewCard");
        }

        public IActionResult DeleteAllCard()
        {
            string userid = LoginedUserId();
            var shoppingcards = repository.ShoppingCard
                .Where(c => c.UserId == userid)
                .ToList();
            // what next?
            if(shoppingcards.Count != 0)
            {
                foreach (var card in shoppingcards)
                {
                    repository.Delete(card);
                }
                repository.SaveChanges();
            }

            return RedirectToAction("ViewCard");
        }


        // order tablosuna ekle, buradan sil.
        // bilgileri tut, siparişi onaylamazsa ve sepette kalsın derse tekrar bu bilgileri çek.
        // siparişi onaylarsa, order tablosuna ekle, shoppingcard tablosundan sil.
        public IActionResult ConfirmCard(int id)
        {
            string userid = LoginedUserId();
            var shoppingcards = repository.ShoppingCard
                .Where(c => c.UserId == userid)
                .ToList();
            
            var order = new Order
            {
                UserId = userid,
                OrderDate = DateTime.Now,
                OrderTotalPrice = shoppingcards.Sum(c => c.Count * GetProductPrice(c.ProductId))
            };
            repository.Add(order);

            foreach (var card in shoppingcards)
            {
                var orderitem = new OrderItem
                {
                    OrderId = order.OrderId,
                    OrderProductId = card.ProductId,
                    OrderProductCategoryId = card.CategoryId,
                    OrderQuantity = card.Count,
                    OrderPrice = GetProductPrice(card.ProductId),

                };
                repository.Add(orderitem);
                repository.Delete(card);
            }

            repository.RemoveRange(shoppingcards);
            try
            {
                repository.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Handle concurrency exception here
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is ShoppingCard)
                    {
                        // Possible recovery or retry logic
                    }
                }
            }

            return View("ConfirmCard");
        }

        public float GetProductPrice(int productId)
        {
            // Logic to fetch the product price from the database
            var urunler = repository.Urunler.ToList();
            // get related product
            var relatedproducts = urunler.Where(p => p.UrunId == productId)?.ToList();
            // get price of the product
            var price = relatedproducts?.FirstOrDefault()?.UrunFiyat;
            return price ?? 0;

        }
    }
}
