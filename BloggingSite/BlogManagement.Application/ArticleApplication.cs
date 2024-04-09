﻿using _0_Framework.Application;
using _0_Framework.Application.Generate;
using _0_Framework.Application.Message;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Domain.ArticleAgg;

namespace BlogManagement.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository,
            IFileUploader fileUploader)
        {
            _articleRepository = articleRepository;
            _fileUploader = fileUploader;
        }

        public ArticleViewModel ArticleDetails(string slug)
        {
            return _articleRepository.ArticleDetails(slug);
        }

        public OperationResult Create(CreateArticle command)
        {
            var slug = command.Slug.Slugify();
            var operation = new OperationResult();

            #region exceptions
            if (command.Picture == null)
                return operation.Failed(ApplicationMessages.PictureCoercion);

            if (_articleRepository.Exists(x => x.Title == command.Title))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            if (_articleRepository.Exists(x => x.Slug == slug))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            #endregion

            var picturePath = $"Articles/{slug}";
            var pictureName = _fileUploader.Upload(command.Picture, picturePath);

            var course = new Article(command.Title, command.ShortDescription,
                command.Description, pictureName, command.PictureAlt,
                command.PictureTitle, slug);

            _articleRepository.Create(course);
            _articleRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditArticle command)
        {
            var slug = command.Slug.Slugify();
            var operation = new OperationResult();
            var article = _articleRepository.Get(command.Id);

            #region exceptions
            if (article == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_articleRepository
                .Exists(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            if (_articleRepository.Exists(x => x.Slug == slug && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            #endregion

            string pictureName = "";
            if (command.Picture != null)
            {
                var picturePath = $"Articles/{slug}";
                pictureName = _fileUploader.Upload(command.Picture, picturePath);
            }

            article.Edit(command.Title, command.ShortDescription,
                command.Description, pictureName, command.PictureAlt,
                command.PictureTitle, slug);

            _articleRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditArticle GetDetails(long id)
        {
            return _articleRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var article = _articleRepository.Get(id);

            if (article == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            article.Remove();
            _articleRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var article = _articleRepository.Get(id);

            if (article == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            article.Restore();
            _articleRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            return _articleRepository.Search(searchModel);
        }
    }
}