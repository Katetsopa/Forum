using BLL.DTO;
using BLL.Infrastructure;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IThemeService : IDisposable
    {
        Task<OperationDetails> Create(ThemeDTO themeDto);
        IEnumerable<PostDTO> GetPosts(ThemeDTO themeDto);
        IEnumerable<ThemeDTO> GetAllTheme();
        ThemeDTO FindByHeader(string header);
        ThemeDTO FindById(int id);
        void Delete(int id);
    }

    public interface IPostService : IDisposable
    {
        void Create(PostDTO postDto);
        PostDTO GetById(int id);
        void Delete(int id);
    }

}
