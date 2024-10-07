using DrinkDiscovery_Revised.Areas.Identity.Data;
using DrinkDiscovery_Revised.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using MimeKit;
using MailKit.Net.Smtp;
using DrinkDiscovery_Revised.SMTP;
using Microsoft.Extensions.Options;

namespace DrinkDiscovery_Revised.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly SmtpSettings smtpSettings;
        private UserManager<DrinkDiscovery_Revised_User> userManager;

        private IEmailSender emailsender;
        private IRepository repository;
        public EmailController(IEmailSender _emailsender, IRepository _repository, UserManager<DrinkDiscovery_Revised_User> _userManager, IOptions<SmtpSettings> _smtpSettings)
        {
            emailsender = _emailsender;
            repository = _repository;
            userManager = _userManager;
            smtpSettings = _smtpSettings.Value;

        }
        public string getLoginedUser()
        {
            return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
        }
        public async Task<IActionResult> SendVerificationEmail()
        {
            var userId = getLoginedUser();
            // Find the user asynchronously
            var user = await userManager.FindByIdAsync(userId);
            var getuserbyusermanager = await userManager.GetUserAsync(User);
            Payment payment = repository.Payment.FirstOrDefault(p => p.PaymentUserId == userId);

            // Ensure user exists
            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Generate the email confirmation token
            var token = await userManager.GenerateEmailConfirmationTokenAsync(getuserbyusermanager);
            var email = getuserbyusermanager?.Email;
            var orderid = payment.OrderId;
            var order = repository.Order.FirstOrDefault(
                o => o.UserId == userId &&
                o.OrderId == orderid
            );
            string emailfromorder = order.Email; 
            if(order == null)
            {
                return BadRequest("Order not found.");
            }
            email = emailfromorder;

            // Ensure email is not null or empty
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email address is missing or not provided.");
            }

            // URL Encode the token
            string encodedToken = WebUtility.UrlEncode(token);

            // Construct the email content
            string subject = "Siparişinizi Doğrulayın";
            string callbackUrl = Url.Action(
                "VerifyOrder",   // Action Name
                "Email",       // Controller Name
                new { userId = userId, token = encodedToken },   // Route Values
                protocol: Request.Scheme);  // Automatically determine protocol (http/https)

            string message = $"Siparişinizi bu linke tıklayarak doğrulayın: <a href='{callbackUrl}'>Siparişi Doğrula</a>";

            // Update payment confirmation
            
            //if (payment != null)
            //{
            //    payment.PaymentConfirmation = true;
            //    repository.Update(payment);
            //}

            // Send email with MimeKit
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(smtpSettings.SenderName, smtpSettings.SenderEmail));
            emailMessage.To.Add(new MailboxAddress("User", email));
            emailMessage.Subject = subject;

            emailMessage.Body = new TextPart("html")
            {
                Text = message
            };

            // Sending email
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(smtpSettings.Host, smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(smtpSettings.UserName, smtpSettings.Password);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }

            return RedirectToAction("IndexEmail", "Email");

        }

        public IActionResult IndexEmail()
        {

           return View();
        }

        public IActionResult VerifyOrder(string userId, string token)
        {
            var payment = repository.Payment.FirstOrDefault(p => p.PaymentUserId == userId);
            if (payment != null) {
                payment.PaymentConfirmation = true;
                repository.Update(payment);
            }

            return View("VerifyOrderPage");
        }

        public IActionResult VerifyOrderPage()
        {
            return View();
        }

    }
}
