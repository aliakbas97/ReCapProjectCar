using Core.DataAccess.Results;
using Core.DataAccess.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper.FileUpload
{
    public static class FileHelper 
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static string _folderName = "\\images\\";

        public static IResult Upload(IFormFile file)
        {

            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();

            if (typeValid.Message != null)
            {
                return new ErrorResult(typeValid.Message);
            }

            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateImageFile(_currentDirectory + _folderName + randomName + type, file);

            return new SuccessfullResult((_folderName + randomName + type).Replace("\\", "/"));



        }
        public static IResult Update(IFormFile file, string carImage)
        {
            var fileExist = CheckFileExist(file);
            if (fileExist.Message != null)
            {
                return new ErrorResult(fileExist.Message);
            }

            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();

            if (typeValid.Message != null)
            {
                return new ErrorResult(typeValid.Message);
            }

            DeleteOldImageFile((_currentDirectory + carImage));
            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateImageFile(_currentDirectory + _folderName + randomName + type, file);

            return new SuccessfullResult((_folderName + randomName + type).Replace("\\", "/"));
        }


        private static IResult CheckFileExist(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                return new SuccessfullResult();
            }
            return new ErrorResult("Resim Dosyası Yok");
        }

        public static IResult Delete(string path)
        {
            DeleteOldImageFile((_currentDirectory + path).Replace("/", "\\"));
            return new SuccessfullResult();
        }

        private static void DeleteOldImageFile(string directory)
        {
            if (File.Exists(directory))
            {
                File.Delete(directory);
            }

        }
        private static void CreateImageFile(string directory, IFormFile file)
        {
            using (FileStream fs = File.Create(directory))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }

        private static IResult CheckFileTypeValid(string type)
        {
            if (type != ".jpeg" && type != ".png" && type != ".jpg")
            {
                return new ErrorResult("Tip uygun değil");
            }
            return new SuccessfullResult();

        }
        private static void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}
