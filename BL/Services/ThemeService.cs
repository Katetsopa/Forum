using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
                if (themeDto != null)
                {
                    var theme = ThemeMapper.Map(themeDto);
                    Database.ThemeRepository.Add(theme);
                    await Database.SaveAsync();
                    return new OperationDetails(true, "Theme created", "");
                }
                else return new OperationDetails(false, "null imput parametr", "ThemeDTO");
            }
            catch(Exception ex)
            {
                throw new BLLException("Problems with creation new theme", ex);
            }
        }


        public ThemeDTO FindByHeader(string header)
        {
            try
            {
                if (header != null)
                    return ThemeMapper.Map(Database.ThemeRepository.FindByHeader(header));
                else
                    throw new BLLException("Can't find theme by header");
            }
            catch (Exception ex)
            {
                throw new BLLException("Can't find theme by header", ex);
            }
        }

        public IEnumerable<PostDTO> GetPosts(ThemeDTO themeDto)
        {
            try
            {
                if (themeDto == null)
                    throw new BLLException("Can't get posts");
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
            catch (Exception ex)
            {
                throw new BLLException("Can't get posts", ex);
            }
        }

        public IEnumerable<ThemeDTO> GetAllTheme()
        {
            try
            {
                return ThemeMapper.Map(Database.ThemeRepository.FindAll().ToList());
            }
            catch (Exception ex)
            {
                throw new BLLException("Can't get all themes", ex);
            }
        }

        public ThemeDTO FindById(int id)
        {
            try
            {
                return ThemeMapper.Map(Database.ThemeRepository.Find(id));
            }
            catch(Exception ex)
            {
                throw new BLLException("Can't find theme by Id", ex);
            }
        }

        public void Delete(int id)
        {
            Database.ThemeRepository.Delete(id);
            Database.SaveAsync();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
