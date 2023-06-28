using _0_Framework.Domain;
using BlogManagement.Application.Contracts.Article;

namespace BlogManagement.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<long, Article>
    {
        EditArticle GetDetails(long id);
        ArticleViewModel ArticleDetails(string slug);
        List<ArticleViewModel> Search(ArticleSearchModel searchModel);
    }
}
