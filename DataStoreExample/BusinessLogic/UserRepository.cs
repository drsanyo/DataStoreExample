using DataStoreExample.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;

namespace DataStoreExample.BusinessLogic
{
    public class UserRepository: UserRepositoryBase
    {        
        private readonly string _separator = ";";
        private CryptoRandom randomGenerator;

        public UserRepository()
        {
            randomGenerator = new CryptoRandom();
        }
        
        public int SaveAllUsers(List<User> users, string fileName, bool performSlowSaving = false)
        {
            int result = 0;

            using (StreamWriter file = new StreamWriter(fileName))
            {                
                foreach (var user in users)
                {
                    string[] values = { user.Age.ToString(), user.Name };
                    string line = string.Join(_separator, values);
                    file.WriteLine(line);
                    result++;
                    if (performSlowSaving)
                    {
                        this.uDelay(30);
                    }
                }
            }

            return result;
        }

        public List<User> GetAllUsers(string fileName)
        {
            List<User> users = new List<User>();

            try
            {
                if (!File.Exists(fileName))
                {
                    throw new ArgumentException(string.Format("File not exists: {0}", fileName));
                }
                
                string[] lines = File.ReadAllLines(fileName);
                foreach (var line in lines)
                {
                    string[] values = line.Split(_separator.ToArray());
                    if (values.Length != 2)
                    {
                        throw new InvalidOperationException(string.Format("Error in data: {0}", line));
                    }

                    User user = new User();
                    user.Age = int.Parse(values[0]);
                    user.Name = values[1];
                    users.Add(user);
                }                
            }
            catch
            {
                throw;
            }
            return users;
        }

        public List<User> GenerateUserList(int userCount)
        {
            var r = RandomNumberGenerator.Create();
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
