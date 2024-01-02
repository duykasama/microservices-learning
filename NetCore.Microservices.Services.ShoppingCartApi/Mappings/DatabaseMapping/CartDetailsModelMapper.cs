using Microsoft.EntityFrameworkCore;
using NetCore.Microservices.Services.ShoppingCartApi.Domain.Entities;
using NetCore.Microservices.Services.ShoppingCartApi.Interfaces;

namespace NetCore.Microservices.Services.ShoppingCartApi.Mappings.DatabaseMapping;

public class CartDetailsModelMapper : IDatabaseModelMapper
{
    public void Map(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CartDetails>(entity =>
        {
            entity.ToTable(nameof(CartDetails));

            entity.HasKey(e => e.Id)
                .HasName("CartDetailsId");

            entity.Property(e => e.Id)
                .HasColumnName("CartDetailsId")
                .ValueGeneratedOnAdd();
            
            entity.HasOne<CartHeader>(e => e.CartHeader)
                .WithMany(e => e.CartDetails)
                .HasForeignKey(e => e.CartHeaderId);
            
            entity.Ignore(e => e.Product);
        });
    }
}