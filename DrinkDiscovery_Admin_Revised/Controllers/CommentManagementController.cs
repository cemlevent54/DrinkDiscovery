using DrinkDiscovery_Admin_Revised.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrinkDiscovery_Admin_Revised.Controllers
{
    public class CommentManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private IRepository repository;
        public CommentManagementController(IRepository _repository)
        {
            repository = _repository;
        }
        
        public IActionResult ListBeverageComments()
        {
            var comments = repository.IcecekYorumlars
                .Include(i => i.yorum_icecek)
                .ToList();
            return View(comments);
        }
        
        public IActionResult DeleteBeverageComment(int id)
        {
            var comment = repository.IcecekYorumlars.FirstOrDefault(i => i.yorum_id == id);
            if (comment != null)
            {
                repository.Delete(comment);
                repository.SaveChanges();
                
            }
            return RedirectToAction("ListBeverageComments");
        }

        
        public IActionResult ConfirmBeverageComment(int id)
        {
            
            var comment = repository.IcecekYorumlars.FirstOrDefault(i => i.yorum_id == id);
            if (comment != null)
            {
                comment.yorum_onay = true;
                repository.Update(comment);
                repository.SaveChanges();
            }
            return RedirectToAction("ListBeverageComments");
        }
        
        public IActionResult RejectBeverageComment(int id)
        {
            var comment = repository.IcecekYorumlars.FirstOrDefault(i => i.yorum_id == id);
            if (comment != null)
            {
                comment.yorum_onay = false;
                repository.Update(comment);
                repository.SaveChanges();
            }
            return RedirectToAction("ListBeverageComments");
        }

        public IActionResult ListSweetComments()
        {
            var comments = repository.TatlilarYorumlars
                .Include(i => i.yorum_tatli)
                .ToList();
            return View(comments);
        }

        public IActionResult DeleteSweetComment(int id)
        {
            var comment = repository.TatlilarYorumlars.FirstOrDefault(i => i.yorum_id == id);
            if (comment != null)
            {
                repository.Delete(comment);
                repository.SaveChanges();
            }
            return RedirectToAction("ListSweetComments");
        }

        public IActionResult ConfirmSweetComment(int id)
        {
            var comment = repository.TatlilarYorumlars.FirstOrDefault(i => i.yorum_id == id);
            if (comment != null)
            {
                comment.yorum_onay = true;
                repository.Update(comment);
                repository.SaveChanges();
            }
            return RedirectToAction("ListSweetComments");
        }

        public IActionResult RejectSweetComment(int id)
        {
            var comment = repository.TatlilarYorumlars.FirstOrDefault(i => i.yorum_id == id);
            if (comment != null)
            {
                comment.yorum_onay = false;
                repository.Update(comment);
                repository.SaveChanges();
            }
            return RedirectToAction("ListSweetComments");
        }

        public IActionResult ListProductComments()
        {
            var comments = repository.UrunlerYorumlars
                .Include(i => i.yorum_urun)
                .ToList();
            return View(comments);
        }

        public IActionResult DeleteProductComment(int id)
        {
            var comment = repository.UrunlerYorumlars.FirstOrDefault(i => i.yorum_id == id);
            if (comment != null)
            {
                repository.Delete(comment);
                repository.SaveChanges();
            }
            return RedirectToAction("ListProductComments");
        }

        public IActionResult ConfirmProductComment(int id)
        {
            var comment = repository.UrunlerYorumlars.FirstOrDefault(i => i.yorum_id == id);
            if (comment != null)
            {
                comment.yorum_onay = true;
                repository.Update(comment);
                repository.SaveChanges();
            }
            return RedirectToAction("ListProductComments");
        }

        public IActionResult RejectProductComment(int id)
        {
            var comment = repository.UrunlerYorumlars.FirstOrDefault(i => i.yorum_id == id);
            if (comment != null)
            {
                comment.yorum_onay = false;
                repository.Update(comment);
                repository.SaveChanges();
            }
            return RedirectToAction("ListProductComments");
        }
    }
}
