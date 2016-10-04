using BLL.Interfaces;
using DAL.Interfaces;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.MapperDTO;
using System;

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
            try
            {
                if (postDto != null)
                {
                    var post = PostMapper.Map(postDto);
                    Database.PostRepository.Add(post);
                    Database.SaveAsync();
                }
                else
                    throw new BLLException("Can't create new theme");
            }
            catch(Exception ex)
            {
                throw new BLLException("Problems with creation new theme", ex);
            }
        }


        public PostDTO GetById(int id)
        {
            try
            {
                return MapperDTO.PostMapper.Map(Database.PostRepository.Find(id));
            }
            catch(Exception ex)
            {
                throw new BLLException("Can't create new theme", ex);
            }
        }


        public void Delete(int id)
        {
            Database.PostRepository.Delete(id);
            Database.SaveAsync();
        }



        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
