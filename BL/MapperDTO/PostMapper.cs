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
            return new PostDTO() { PostId = entity.PostId, MainText = entity.MainText, UserId = entity.UserId, ThemeId = entity.ThemeId };
            // return Mapper.Map<Post, PostDTO>(entity);
        }

        public static List<PostDTO> Map(List<Post> entities)
        {
            List<PostDTO> result = new List<PostDTO>();
            foreach (var entity in entities)
            {
                PostDTO res = new PostDTO() { PostId = entity.PostId, MainText = entity.MainText, UserId = entity.UserId, ThemeId = entity.ThemeId };
                result.Add(res);
            }
            return result;
            //return Mapper.Map<List<Post>, List<PostDTO>>(entities);
        }

        public static Post Map(PostDTO businessObject)
        {
            return new Post() { PostId = businessObject.PostId, MainText = businessObject.MainText, ThemeId = businessObject.ThemeId, UserId = businessObject.UserId };
           // return Mapper.Map<PostDTO, Post>(businessObject);
        }

        internal static List<Post> Map(List<PostDTO> businessObject)
        {
            List<Post> result = new List<Post>();
            if (businessObject != null)
            {
                foreach (var p in businessObject)
                {
                    Post res = new Post() { PostId = p.PostId, MainText = p.MainText, ThemeId = p.ThemeId, UserId = p.UserId };
                    result.Add(res);
                }
                return result;
            }
            else return null;
            
        }
    }
}
