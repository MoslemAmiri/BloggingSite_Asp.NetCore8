using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastructure.EfCore.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Picture).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(500).IsRequired();
            builder.Property(x => x.PictureTitle).HasMaxLength(500).IsRequired();
            builder.Property(p => p.ShortDescription).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(750).IsRequired();
            builder.Property(p => p.Description).IsRequired();
        }
    }
}