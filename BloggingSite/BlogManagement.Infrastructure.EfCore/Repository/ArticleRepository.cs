using _0_Framework.Infrastructure;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Domain.ArticleAgg;

namespace BlogManagement.Infrastructure.EfCore.Repository
{
    public class ArticleRepository : RepositoryBase<long, Article>, IArticleRepository
    {
        private readonly BlogContext _blogContext;

        public ArticleRepository(BlogContext blogContext) : base(blogContext)
        {
            _blogContext = blogContext;
        }

        public ArticleViewModel ArticleDetails(string slug)
        {
            return _blogContext.Articles
                .Select(x => new ArticleViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Description = x.Description,
                    Slug = x.Slug
                }).Single(x => x.Slug == slug);
        }

        public EditArticle GetDetails(long id)
        {
            return _blogContext.Articles
                .Select(x => new EditArticle
                {
                    Id = x.Id,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    Description = x.Description,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug
                }).Single(x => x.Id == id);
        }

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            var query = _blogContext.Articles
                .Where(x => !x.IsRemoved)
                .Select(x => new ArticleViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Slug = x.Slug,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    ShortDescription = x.ShortDescription,
                    Description = x.Description
                });

            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
