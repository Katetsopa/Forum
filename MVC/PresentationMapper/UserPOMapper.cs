using System.Collections.Generic;
using BLL.DTO;
using MVC.PresentationEntity;
using MVC.PresentationMapper;

namespace MVC.PresentationMapper
{
    public class UserPOMapper
    {
        public static UserPO Map(UserDTO entity)
        {
            return new UserPO() { Id = entity.Id, Password= entity.Password, Name = entity.Name, UserName = entity.UserName, Email = entity.Email, Posts = PostPOMapper.Map(entity.Posts) };
        }

        public static List<UserPO> Map(List<UserDTO> entities)
        {
            List<UserPO> result = new List<UserPO>();
            foreach (var entity in entities)
            {
                UserPO res = new UserPO() { Id = entity.Id, Password = entity.Password, Name = entity.Name, UserName = entity.UserName, Email = entity.Email, Posts = PostPOMapper.Map(entity.Posts) };
                result.Add(res);
            }
            return result;
        }

        public static UserDTO Map(UserPO businessObject)
        {
            return  new UserDTO() {  Id = businessObject.Id, Password = businessObject.Password, Name= businessObject.Name, Email = businessObject.Role, UserName= businessObject.UserName,  Posts = PostPOMapper.Map(businessObject.Posts)};
        }
    }
}
