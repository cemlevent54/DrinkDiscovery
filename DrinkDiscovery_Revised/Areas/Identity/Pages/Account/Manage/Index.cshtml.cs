#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using DrinkDiscovery_Revised.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DrinkDiscovery_Revised.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<DrinkDiscovery_Revised_User> _userManager;
        private readonly SignInManager<DrinkDiscovery_Revised_User> _signInManager;

        public IndexModel(
            UserManager<DrinkDiscovery_Revised_User> userManager,
            SignInManager<DrinkDiscovery_Revised_User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Kullanıcı Adı")]
            public string ad { get; set; }

            [Display(Name = "Kullanıcı Soyadı")]
            public string soyad { get; set; }

            [Display(Name = "Kullanıcı Username")]
            public string username { get; set; }

            [Display(Name = "Kullanıcı Email")]
            public string mail { get; set; }

            [Display(Name = "Kullanıcı Telefon")]
            public string telno { get; set; }

            [Display(Name = "Kullanıcı Fotoğraf")]
            public byte[] photo { get; set; }

            public IFormFile photo_iformfile { get; set; }

            public string userid { get; set; }
            public string photo_src { get; set; }
        }

        private async Task LoadAsync(DrinkDiscovery_Revised_User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var userId = user.Id;

            var userInfos = await _userManager.FindByIdAsync(userId);
            if (userInfos == null)
            {
                throw new InvalidOperationException($"Unable to load user with ID '{userId}'.");
            }

            var kullanici_ad = userInfos.kullanici_ad;
            var kullanici_soyad = userInfos.kullanici_soyad;
            var kullanici_username = userInfos.kullanici_username;
            var kullanici_email = userInfos.kullanici_mail;
            var kullanici_tel = userInfos.kullanici_telefon;
            var kullanici_fotograf = userInfos.kullanici_fotograf;

            string imgSrc = kullanici_fotograf != null
                ? $"data:image/jpeg;base64,{Convert.ToBase64String(kullanici_fotograf)}"
                : null;

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                ad = kullanici_ad,
                soyad = kullanici_soyad,
                username = kullanici_username,
                mail = kullanici_email,
                telno = kullanici_tel,
                photo = kullanici_fotograf,
                userid = userId,
                photo_src = imgSrc
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            // Updating additional fields
            user.kullanici_ad = Input.ad;
            user.kullanici_soyad = Input.soyad;
            user.kullanici_username = Input.username;
            user.kullanici_mail = Input.mail;
            user.kullanici_telefon = Input.telno;

            // Handle the photo upload
            if (Input.photo_iformfile != null && Input.photo_iformfile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await Input.photo_iformfile.CopyToAsync(memoryStream);
                    user.kullanici_fotograf = memoryStream.ToArray();
                }
            }

            // Save the changes
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                StatusMessage = "Unexpected error when trying to update the profile.";
                return RedirectToPage();
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

        public IActionResult GetImage(string id)
        {
            var user = GetUser(id);
            var photo = user?.kullanici_fotograf;

            if (photo != null)
            {
                // Return the photo as a file with the MIME type for JPEG
                return File(photo, "image/jpeg");
            }

            // If no photo is found, you can return a default image, an empty result, or a NotFound result
            return NotFound();
        }

        private DrinkDiscovery_Revised_User GetUser(string id)
        {
            return _userManager.FindByIdAsync(id).Result;
        }
    }
}
