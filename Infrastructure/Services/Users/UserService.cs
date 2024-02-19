using Application.Common.Interfaces.Users;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Services.Generic;

namespace Infrastructure.Services.Users
{
    public class UserService : BaseCrudService<User>, IUserService
    {
        public UserService(ProductsDbContext context) : base(context)
        {
        }
    }
}
