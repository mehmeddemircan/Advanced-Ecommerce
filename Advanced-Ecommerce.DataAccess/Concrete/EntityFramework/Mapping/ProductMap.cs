using Advanced_Ecommerce.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.DataAccess.Concrete.EntityFramework.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", @"dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasColumnName("Description").HasMaxLength(50).IsRequired();
            builder.Property(x => x.BrandId).HasColumnName("BrandId").IsRequired();
            builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now);
            
        }
    }
}
