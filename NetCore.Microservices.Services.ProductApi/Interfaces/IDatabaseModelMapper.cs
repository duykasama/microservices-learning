using Microsoft.EntityFrameworkCore;

namespace NetCore.Microservices.Services.ProductApi.Interfaces;

public interface IDatabaseModelMapper
{
    void Map(ModelBuilder modelBuilder);
}