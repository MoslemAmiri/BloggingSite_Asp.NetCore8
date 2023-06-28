using BlogManagement.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class EditArticleModel : PageModel
    {
        public EditArticle Command;
        private readonly IArticleApplication _articleApplication;

        public EditArticleModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet(long id)
        {
            Command = _articleApplication.GetDetails(id);
        }

        public IActionResult OnPost(EditArticle command)
        {
            var result = _articleApplication.Edit(command);

            if (!result.IsSuccedded)
            {
                TempData["ErrorMessage"] = result.Message;
                return RedirectToPage("./EditArticle", new { id = command.Id });
            }

            return RedirectToPage("./Index");
        }
    }
}