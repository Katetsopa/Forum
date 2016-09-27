using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Entity;
using BLL.Infrastructure;
using BLL.MapperDTO;

namespace BLL.Services
{
    public class PostService : IPostService
    {
        IUnitOfWork Database { get; set; }

        public PostService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Create(PostDTO postDto)
        {
            if (postDto == null)
                throw new ValidationException("Can't create new theme", "null theme parametr");
            try
            {
                var post = PostMapper.Map(postDto);
                Database.PostRepository.Add(post);
                Database.SaveAsync();
            }
            catch { throw new ValidationException("Problems with creation new theme", ""); }
        }

        public ApplicationUser GetUser(PostDTO postDto)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        //public void Create(ThemeDTO themeDto)
        //{
        //    if (themeDto == null)
        //        throw new ValidationException("Can't create new theme", "null theme parametr");
        //    try
        //    {
        //        var theme = ThemeMapper.Map(themeDto);
        //        Database.ThemeRepository.Add(theme);
        //        Database.SaveAsync();
        //    }
        //    catch { throw new ValidationException("Problems with creation new theme", ""); }
        //}
    }
}
