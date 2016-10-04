using DAL.Entity;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entitys);
        void Delete(int id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        T Find(int id);
        IEnumerable<T> FindAll();
    }

    public interface IPostRepository : IRepository<Post>
    {

    }

    public interface IThemeRepository : IRepository<Theme>
    {
        Theme FindByHeader(string header);
        IEnumerable<Post> GetPosts(int id);
    }
}
