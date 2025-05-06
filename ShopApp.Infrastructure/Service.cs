using ShopApp.Core;
using ShopApp.Infrastructure;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync();
}

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllWithBsAsync();
        return entities.Select(a => new UserDto
        {
            Id = a.Id,
            Name = a.Name,
            Products = a.Products.Select(b => new ProductDto
            {
                Id = b.Id
            }).ToList()
        });
    }
}
