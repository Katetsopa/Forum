using System;
using System.Collections.Generic;
using DAL.Entity;
using DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Repository
{
    public class ThemeRepository : Repository<Theme>, IThemeRepository
    {

        public ThemeRepository(ForumContext context) : base(context)
        {
        }

        public Theme FindByHeader(string header)
        {
            Theme result = new Theme();
            var allThemes = Context.Themes;
            foreach (var theme in allThemes)
            {
                if (theme.Header == header)
                {
                    result = theme;
                }
            }
            return result;
        }

        public IEnumerable<Post> GetPosts(int id)
        {
           Theme theme = Context.Themes.Find(id);
           return theme.Posts;
        }
    }
}
