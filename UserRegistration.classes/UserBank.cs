using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistration.classes
{
    public class UserBank
    {
  
        List<User> Users = new List<User>();

        public string AddUser(User user)
        {

            if (Users.Exists(u => u.UserName == user.UserName))
            {
                throw new ArgumentException("Username already exists.");
            }

            Users.Add(user);
            return $"{user.UserName} has been sucessfully created!";
        }
    }
}
