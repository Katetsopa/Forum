using System.Collections.Generic;
using BLL.DTO;
using MVC.PresentationEntity;

namespace MVC.PresentationMapper
{
    public class ThemePOMapper
    {
        public static ThemePO Map(ThemeDTO entity)
        {
            return new ThemePO() {
                ThemeId = entity.ThemeId,
                Header = entity.Header,
                MainText = entity.MainText,
                Posts = PostPOMapper.Map(entity.Posts)
            };
        }

        public static List<ThemePO> Map(List<ThemeDTO> entities)
        {
            List<ThemePO> result = new List<ThemePO>();
            
            foreach (var entity in entities)
            {
                ThemePO res = Map(entity);
                result.Add(res);
            }
            return result;
        }

        public static ThemeDTO Map(ThemePO businessObject)
        {
            return new ThemeDTO() {
                ThemeId = businessObject.ThemeId,
                Header = businessObject.Header,
                MainText = businessObject.MainText,
                Posts = PostPOMapper.Map(businessObject.Posts)
            };
        }


        public static List<ThemeDTO> Map(List<ThemePO> businessObjects)
        {
            List<ThemeDTO> result = new List<ThemeDTO>();

            foreach (var businessObject in businessObjects)
            {
                ThemeDTO temp = Map(businessObject);
                result.Add(temp);
            }
            return result;
        }
    }
}
