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

        public void Create(ThemeDTO themeDto)
        {
            if (themeDto == null)
                throw new ValidationException("Can't create new theme", "null theme parametr");
            try
            {
                var theme = ThemeMapper.Map(themeDto);
                Database.ThemeRepository.Add(theme);
                Database.SaveAsync();
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
            return PostMapper.Map(Database.ThemeRepository.GetPosts(themeDto.ThemeId).ToList());
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
            //throw new NotImplementedException();
        }
    }
}
