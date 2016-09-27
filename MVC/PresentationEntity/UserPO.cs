using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.PresentationEntity
{
    public class UserPO
    {
        public string Id { get; set; }

        [DataType (DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType (DataType.Password)]
        public string Password { get; set; }

        public string UserName { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public List<PostPO> Posts { get; set; }
    }
}