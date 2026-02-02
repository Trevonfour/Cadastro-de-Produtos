using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Price).IsRequired().HasPrecision(10, 2);
            builder.Property(p => p.Stock).IsRequired();
            builder.Property(p => p.Image).HasMaxLength(250);
            builder.HasOne(e => e.Category).WithMany(e => e.Products).HasForeignKey(e => e.CategoryId);
        }
    }
}
