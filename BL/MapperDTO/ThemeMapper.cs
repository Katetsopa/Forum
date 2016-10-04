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
          return new ThemeDTO() {
              ThemeId = entity.ThemeId,
              Header = entity.Header,
              MainText = entity.MainText,
              Posts = PostMapper.Map(entity.Posts)
           };
        }

        public static List<ThemeDTO> Map(List<Theme> entities)
        {
            List<ThemeDTO> result = new List<ThemeDTO>();

            foreach (var entity in entities)
            {
                ThemeDTO temp = Map(entity);
                result.Add(temp);
            }

            return result;
        }

        public static Theme Map(ThemeDTO businessObject)
        {
            Theme result = new Theme() {
                ThemeId = businessObject.ThemeId,
                Header = businessObject.Header,
                MainText = businessObject.MainText,
                Posts = PostMapper.Map(businessObject.Posts)
            };
            return result;
        }
    }
}
