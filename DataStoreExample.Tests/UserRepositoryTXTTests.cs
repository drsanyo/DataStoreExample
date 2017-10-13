﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStoreExample.BusinessLogic;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace DataStoreExample.Tests
{
    [TestClass]
    public class UserRepositoryTXTTests
    {
        private string _resultFolder = "TestsResult";
        [TestInitialize()]
        public void Initialize()
        {
            try
            {
                if (!Directory.Exists(_resultFolder))
                {
                    Directory.CreateDirectory(_resultFolder);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Cannot create folder ({0})", _resultFolder), ex);
            }
        }


        [TestMethod]
        public void SaveAllUsers_should_create_non_0_length_file()
        {
            // arrange
            string fileName = Path.Combine(_resultFolder, @"test.txt");
            UserRepositoryTXT userRepository = new UserRepositoryTXT();
            int userCount = 100000;
            int savedCount = 0;

            // act
            var users = userRepository.GenerateUserList(userCount);
            savedCount = userRepository.SaveAllUsers(users, fileName);
            

            // assert
            Assert.AreEqual(userCount, savedCount);
            Assert.IsTrue(File.Exists(fileName));
            Assert.IsTrue((new FileInfo(fileName).Length) > 0);
        }

        [TestMethod]
        public void LoadAllUsers_should_load_test_users()
        {
            // arrange
            string fileName = Path.Combine(_resultFolder, @"testUsers.txt");
            UserRepositoryTXT userRepository = new UserRepositoryTXT();
            var users = userRepository.GetTestUsers();
            userRepository.SaveAllUsers(users, fileName);
            users.Clear();

            // act            
            users = userRepository.GetAllUsers(fileName);

            // assert
            Assert.AreEqual(userRepository.GetTestUsers().Count, users.Count);
            Assert.AreEqual(userRepository.GetTestUsers()[0].Name, users[0].Name);
            Assert.AreEqual(userRepository.GetTestUsers()[0].Age, users[0].Age);
        }
    }
}
