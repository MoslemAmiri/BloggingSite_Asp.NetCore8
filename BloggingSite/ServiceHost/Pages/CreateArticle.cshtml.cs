using BlogManagement.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class CreateArticleModel : PageModel
    {
        public CreateArticle Command;
        private readonly IArticleApplication _articleApplication;

        public CreateArticleModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(CreateArticle command)
        {
            var result = _articleApplication.Create(command);

            if (!result.IsSuccedded)
            {
                TempData["ErrorMessage"] = result.Message;
                return RedirectToPage("./CreateArticle");
            }

            return RedirectToPage("./Index");
        }
    }
}