using System.Collections.Generic;
using DAL.Entity;
using BLL.DTO;
using AutoMapper;
using System;

namespace BLL.MapperDTO
{
    public class PostMapper
    {
        public static PostDTO Map(Post entity)
        {
            return new PostDTO() {
                PostId = entity.PostId,
                MainText = entity.MainText,
                UserId = entity.UserId,
                ThemeId = entity.ThemeId
            };
        }

        public static List<PostDTO> Map(List<Post> entities)
        {
            List<PostDTO> result = new List<PostDTO>();

            foreach (var entity in entities)
            {
                PostDTO res = Map(entity);
                result.Add(res);
            }

            return result;
 
        }

        public static Post Map(PostDTO businessObject)
        {
            return new Post() {
                PostId = businessObject.PostId,
                MainText = businessObject.MainText,
                ThemeId = businessObject.ThemeId,
                UserId = businessObject.UserId
            };
  
        }

        internal static List<Post> Map(List<PostDTO> businessObject)
        {
            List<Post> result = new List<Post>();

            if (businessObject != null)
            {
                foreach (var p in businessObject)
                {
                    Post res = Map(p); 
                    result.Add(res);
                }
                return result;
            }
            else
                return null;
        }
    }
}
