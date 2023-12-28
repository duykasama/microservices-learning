using Microsoft.EntityFrameworkCore;
using NetCore.Microservices.Services.ProductApi.Domain.Entities;
using NetCore.Microservices.Services.ProductApi.Interfaces;

namespace NetCore.Microservices.Services.ProductApi.Mappings.DatabaseMapping;

public class ProductModelMapper : IDatabaseModelMapper
{
    public void Map(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable(p => 
                p.HasCheckConstraint("CK_Product_Price", "Price >= 0 and Price <= 1000"));
            
            entity.HasKey(p => p.Id)
                .HasName("ProductId");

            entity.Property(p => p.Id)
                .HasColumnName("ProductId")
                .ValueGeneratedOnAdd();

            entity.Property(p  => p.Name)
                .IsRequired();
        });
    }
}