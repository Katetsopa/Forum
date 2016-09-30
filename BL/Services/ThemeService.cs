using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Infrastructure;
using DAL.Interfaces;
using BLL.MapperDTO;

namespace BLL.Services
{
    public class ThemeService : IThemeService
    {
        IUnitOfWork Database { get; set; }

        public ThemeService(IUnitOfWork uow)
        {
            Database = uow;
        }
        
        public async Task<OperationDetails> Create(ThemeDTO themeDto)
        {
            try
            {
                if (themeDto == null)
                    return new OperationDetails(false, "null imput parametr", "ThemeDTO");
                else
                {
                    var theme = ThemeMapper.Map(themeDto);
                    Database.ThemeRepository.Add(theme);
                    await Database.SaveAsync();
                    return new OperationDetails(true, "Theme created", "");
                }
            }
            catch { throw new ValidationException("Problems with creation new theme", ""); }
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public ThemeDTO FindByHeader(string header)
        {
            if (header == null)
                throw new ValidationException("Can't find theme by header", "null parametr");
            return ThemeMapper.Map(Database.ThemeRepository.FindByHeader(header));
        }

        public IEnumerable<PostDTO> GetPosts(ThemeDTO themeDto)
        {
            if (themeDto == null)
                throw new ValidationException("Can't get posts", "null parametr");
            var posts = PostMapper.Map(Database.ThemeRepository.GetPosts(themeDto.ThemeId).ToList());
            foreach (var post in posts)
            {
                var tempUsers = Database.UserManager.Users.Where(u => u.Id == post.UserId).ToList();   
                var tempUser = UserMapper.Map(tempUsers[0]);
                post.UserName = tempUser.Name;
                post.UserEmail = tempUser.Email;
            }
            return posts;
        }

        public IEnumerable<ThemeDTO> GetAllTheme()
        {
            return ThemeMapper.Map(Database.ThemeRepository.FindAll().ToList());
        }

        public ThemeDTO FindById(int id)
        {
            return ThemeMapper.Map(Database.ThemeRepository.Find(id));
        }

        public void Delete(int id)
        {
            Database.ThemeRepository.Delete(id);
            Database.SaveAsync();
        }
    }
}
