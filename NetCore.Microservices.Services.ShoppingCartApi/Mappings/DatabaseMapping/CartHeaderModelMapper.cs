using Microsoft.EntityFrameworkCore;
using NetCore.Microservices.Services.ShoppingCartApi.Domain.Entities;
using NetCore.Microservices.Services.ShoppingCartApi.Interfaces;

namespace NetCore.Microservices.Services.ShoppingCartApi.Mappings.DatabaseMapping;

public class CartHeaderModelMapper : IDatabaseModelMapper
{
    public void Map(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CartHeader>(entity =>
        {
            entity.ToTable(nameof(CartHeader));

            entity.HasKey(e => e.Id)
                .HasName("CartHeaderId");

            entity.Property(e => e.Id)
                .HasColumnName("CartHeaderId")
                .ValueGeneratedOnAdd();

            entity.Ignore(e => e.Discount);
            entity.Ignore(e => e.CartTotal);
        });
    }
}