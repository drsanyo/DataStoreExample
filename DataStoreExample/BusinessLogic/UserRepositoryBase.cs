using DataStoreExample.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStoreExample.BusinessLogic
{
    public class UserRepositoryBase
    {
        protected RandomGenerator randomGenerator;
        public UserRepositoryBase()
        {
            randomGenerator = new RandomGenerator();
        }
        public List<User> GetTestUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    Age = 35,
                    Name = "Tomas"
                },
                new User()
                {
                    Age = 33,
                    Name = "Elisabeth"
                },

                new User()
                {
                    Age = 10,
                    Name = "Caroline"
                },

                new User()
                {
                    Age = 3,
                    Name = "Caterina"
                }
            };
        }

        public List<User> GenerateUserList(int userCount)
        {            
            List<User> users = new List<User>();
            for (int i = 0; i < userCount; i++)
            {
                User user = new User();
                user.Age = randomGenerator.Next(99);
                user.Name = Path.GetRandomFileName();
                users.Add(user);
            }
            return users;
        }
    }
}
