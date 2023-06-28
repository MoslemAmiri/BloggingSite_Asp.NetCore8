using BlogManagement.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class IndexModel : PageModel
    {
        public List<ArticleViewModel> Articles;
        private readonly IArticleApplication _articleApplication;

        public IndexModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet(ArticleSearchModel searchModel)
        {
            Articles = _articleApplication.Search(searchModel);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _articleApplication.Remove(id);

            switch (result.IsSuccedded)
            {
                case true:
                    TempData["SuccessMessage"] = result.Message;
                    break;
                case false:
                    TempData["ErrorMessage"] = result.Message;
                    break;
            }

            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            var result = _articleApplication.Restore(id);

            switch (result.IsSuccedded)
            {
                case true:
                    TempData["SuccessMessage"] = result.Message;
                    break;
                case false:
                    TempData["ErrorMessage"] = result.Message;
                    break;
            }

            return RedirectToPage("./Index");
        }
    }
}
