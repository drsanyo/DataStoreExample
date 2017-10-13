using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DataStoreExample.Tests
{
    [TestClass]
    public class Initializer
    {
        public static readonly string ResultFolder = "TestsResult";        

        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {            
            if (!Directory.Exists(ResultFolder))
            {
                Directory.CreateDirectory(ResultFolder);
            }
            else
            {
                EmptyResultFolder(ResultFolder);
            }            
        }

        private static void EmptyResultFolder(string folderName)
        {
            DirectoryInfo directory = new DirectoryInfo(folderName);
            DeleteAllFilesInDirectory(directory);
            DeleteAllDirectoriesInDirectory(directory);
        }

        private static void DeleteAllDirectoriesInDirectory(DirectoryInfo directory)
        {
            string objectName = "";
            try
            {
                foreach (DirectoryInfo dir in directory.GetDirectories())
                {
                    objectName = dir.FullName;
                    dir.Delete(true);
                }
            }
            catch (IOException io)
            {
                throw new InvalidOperationException($"Can not delete folder: {objectName}", io);
            }
        }

        private static void DeleteAllFilesInDirectory(DirectoryInfo directory)
        {
            string objectName = "";
            try
            {
                foreach (FileInfo file in directory.GetFiles())
                {
                    objectName = file.FullName;
                    file.Delete();
                }
            }
            catch (IOException io)
            {
                throw new InvalidOperationException($"Can not delete file: {objectName}", io);
            }
        }
    }
}
