using System.Collections.Generic;
using DAL.Entity;
using BLL.DTO;

namespace BLL.MapperDTO
{
    public class UserMapper
    {
        public static UserDTO Map(ApplicationUser entity)
        {
            return new UserDTO() { Id= entity.Id, Password= entity.PasswordHash, Name = entity.Name, UserName = entity.UserName, Email = entity.Email, Posts = PostMapper.Map(entity.Posts) };
        }

        public static List<UserDTO> Map(List<ApplicationUser> entities)
        {
            List<UserDTO> result = new List<UserDTO>();
            foreach (var entity in entities)
            {
                UserDTO res = new UserDTO() { Id = entity.Id, Password = entity.PasswordHash, Name = entity.Name, UserName= entity.UserName, Email = entity.Email, Posts = PostMapper.Map(entity.Posts) };
                result.Add(res);
            }
            return result;
        }

        public static ApplicationUser Map(UserDTO businessObject)
        {
            return  new ApplicationUser() {  Id = businessObject.Id, PasswordHash = businessObject.Password, Email = businessObject.Email, UserName= businessObject.UserName, Name = businessObject.Name ,  Posts = PostMapper.Map(businessObject.Posts)};
        }
    }
}
