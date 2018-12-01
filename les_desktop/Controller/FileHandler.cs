using les_desktop.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les_desktop.Controller
{
    public class FileHandler
    {
        public void CreateFileWithEncryptedDate(DomainEntity user)
        {
            var filePath = GetFilePath();
            if (user is User u)
            {
                if(File.Exists(filePath))
                { 
                    File.Delete(filePath);
                }
                using (var streamWriter = new StreamWriter(filePath, true))
                {
                    streamWriter.WriteLine(u.Email);
                    streamWriter.WriteLine(u.Password);
                    streamWriter.WriteLine(u.Authentication.Auth);
                }
            }
        }
        public User GetUserDataFromFile()
        {
            var filePath = GetFilePath();
            if (File.Exists(filePath))
            {
                using (var streamReader = new StreamReader(filePath))
                {
                    User user = new User
                    {
                        Email = streamReader.ReadLine(),
                        Password = streamReader.ReadLine(),
                        Authentication = new Authentication
                        {
                            Auth = streamReader.ReadLine(),
                        }
                    };
                    return user;
                }
            }
            return null;
        }
        private string GetFilePath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            return $@"{path}\textFile.txt";
        }
    }
}
