using System.Collections.Generic;
using DAL.Entity;
using BLL.DTO;
using BLL.MapperDTO;

namespace BLL.MapperDTO
{
    public class ThemeMapper
    {
        public static ThemeDTO Map(Theme entity)
        {
            if (entity != null)
            {
                ThemeDTO result = new ThemeDTO() { ThemeId = entity.ThemeId, Header = entity.Header, MainText = entity.MainText, Posts = PostMapper.Map(entity.Posts) };
                return result;
            }
            else return null;
        }

        public static List<ThemeDTO> Map(List<Theme> entities)
        {
            List<ThemeDTO> result = new List<ThemeDTO>();
            foreach (var entity in entities)
            {
                ThemeDTO res = new ThemeDTO() { ThemeId = entity.ThemeId, Header = entity.Header, MainText = entity.MainText , Posts = PostMapper.Map(entity.Posts)};
                result.Add(res);
            }
                return result;
        }

        public static Theme Map(ThemeDTO businessObject)
        {
            Theme result = new Theme() { ThemeId = businessObject.ThemeId, Header = businessObject.Header, MainText = businessObject.MainText, Posts = PostMapper.Map(businessObject.Posts) };
            return result;
        }
    }
}
