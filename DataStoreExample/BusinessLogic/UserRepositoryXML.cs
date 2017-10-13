using DataStoreExample.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace DataStoreExample.BusinessLogic
{
    public class UserRepositoryXML : UserRepositoryBase, IUserRepository
    {        
        public int SaveAllUsers(List<User> users, string fileName, bool performSlowSaving = false)
        {
            int result = 0;

            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.NewLineHandling = NewLineHandling.None;
            xmlSettings.Indent = false;

            using (StreamWriter file = new StreamWriter(fileName))
            {
                foreach (var user in users)
                {
                    using (StringWriter stringWriter = new StringWriter(new StringBuilder()))
                    {
                        XmlWriter writer = XmlWriter.Create(stringWriter, xmlSettings);                        
                        XmlSerializer xmlSerializer = new XmlSerializer(user.GetType());
                        xmlSerializer.Serialize(writer, user);                        
                        file.WriteLine(stringWriter.ToString());
                        result++;
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
                    using (StringReader stringReader = new StringReader(line))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(User));
                        User user = (User)serializer.Deserialize(stringReader);
                        users.Add(user);
                    }
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
