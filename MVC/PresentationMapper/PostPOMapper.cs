using System.Collections.Generic;
using BLL.DTO;
using MVC.PresentationEntity;
using MVC.PresentationMapper;

namespace MVC.PresentationMapper
{
    public class PostPOMapper
    {
        public static PostPO Map(PostDTO entity)
        {
            return new PostPO() { PostId = entity.PostId, MainText = entity.MainText, UserId = entity.UserId, ThemeId = entity.ThemeId };
        }

        public static List<PostPO> Map(List<PostDTO> entities)
        {
            List<PostPO> result = new List<PostPO>();
            foreach (var entity in entities)
            {
                PostPO res = new PostPO() { PostId = entity.PostId, MainText = entity.MainText, UserId = entity.UserId, ThemeId = entity.ThemeId };
                result.Add(res);
            }
            return result;
        }

        public static PostDTO Map(PostPO businessObject)
        {
            return new PostDTO() { PostId = businessObject.PostId, MainText = businessObject.MainText, ThemeId = businessObject.ThemeId, UserId = businessObject.UserId };
        }

        internal static List<PostDTO> Map(List<PostPO> businessObject)
        {
            List<PostDTO> result = new List<PostDTO>();
            foreach (var p in businessObject)
            {
                PostDTO res = new PostDTO() { PostId = p.PostId, MainText = p.MainText, ThemeId = p.ThemeId, UserId = p.UserId };
                result.Add(res);
            }
            return result;
        }
    }
}
