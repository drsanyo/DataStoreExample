using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStoreExample.BusinessLogic;
using System.Collections.Generic;

namespace DataStoreExample.Tests
{
    [TestClass]
    public class UserRepositoryBaseTests
    {
        [TestMethod]
        public void GenerateUserList_should_generate_1000000_items()
        {
            // arrange
            UserRepositoryTXT userRepository = new UserRepositoryTXT();
            int userCount = 1000000;
            List<User> userList;

            // act
            userList = userRepository.GenerateUserList(userCount);

            // assert
            Assert.IsNotNull(userList);
            Assert.AreEqual(userCount, userList.Count);
        }
    }
}
