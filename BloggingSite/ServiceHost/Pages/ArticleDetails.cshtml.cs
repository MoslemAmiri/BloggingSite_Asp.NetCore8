using BlogManagement.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleViewModel Article;
        private readonly IArticleApplication _articleApplication;

        public ArticleDetailsModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet(string slug)
        {
            Article = _articleApplication.ArticleDetails(slug);
        }
    }
}
