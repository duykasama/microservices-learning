using Microsoft.EntityFrameworkCore;

namespace NetCore.Microservices.Services.ShoppingCartApi.Interfaces;

public interface IDatabaseModelMapper
{
    void Map(ModelBuilder modelBuilder);
}
