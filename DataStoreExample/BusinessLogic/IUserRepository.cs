using System.Collections.Generic;

namespace DataStoreExample.BusinessLogic
{
    public interface IUserRepository
    {
        List<User> GetAllUsers(string fileName);
        int SaveAllUsers(List<User> users, string fileName);
        List<User> GetTestUsers();
        List<User> GenerateUserList(int userCount);
    }
}