using DataStoreExample.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace DataStoreExample.BusinessLogic
{
    public class UserRepositoryBIN : UserRepositoryBase, IUserRepository
    {        
        public int SaveAllUsers(List<User> users, string fileName)
        {
            using (Stream stream = File.Open(fileName, FileMode.Create))
            {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, users);
            }

            return users.Count;
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

                using (Stream stream = File.Open(fileName, FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    users = (List<User>)bformatter.Deserialize(stream);
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
