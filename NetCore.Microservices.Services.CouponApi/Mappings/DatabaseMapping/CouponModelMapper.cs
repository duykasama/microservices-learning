using Microsoft.EntityFrameworkCore;
using NetCore.Microservices.Services.CouponApi.Domain.Entities;
using NetCore.Microservices.Services.CouponApi.Interfaces;

namespace NetCore.Microservices.Services.CouponApi.Mappings.DatabaseMapping;

public class CouponModelMapper : IDatabaseModelMapper
{
    public void Map(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.ToTable(nameof(Coupon));
            
            entity.HasKey(c => c.Id)
                .HasName("CouponId");

            entity.Property(c => c.Id)
                .HasColumnName("CouponId")
                .ValueGeneratedOnAdd();

            entity.Property(c => c.CouponCode)
                .IsRequired();

            entity.Property(c => c.DiscountAmount)
                .IsRequired();
        });
    }
}