using GShop.Context.Entities;

namespace GShop.Services.ContextAccess
{
    public interface IContextAccess
    {
        Task<User> GetCurrentUser();
    }
}
