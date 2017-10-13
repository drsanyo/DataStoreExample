using DataStoreExample.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;

namespace DataStoreExample.BusinessLogic
{
    public class UserRepositoryTXT: UserRepositoryBase
    {        
        private readonly string _separator = ";";
        
        public int SaveAllUsers(List<User> users, string fileName)
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
    }
}
