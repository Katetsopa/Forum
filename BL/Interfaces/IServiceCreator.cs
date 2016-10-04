using BLL.Intrfaces;

namespace BLL.Interfaces
{
    public interface IServiceCreator
    {
        IUserService CreateUserService(string connection);
        IThemeService CreateThemeService(string connection);
        IPostService CreatePostService(string connection);
    }
}
