using Microsoft.EntityFrameworkCore;

namespace NetCore.Microservices.Services.CouponApi.Interfaces;

public interface IDatabaseModelMapper
{
    void Map(ModelBuilder modelBuilder);
}